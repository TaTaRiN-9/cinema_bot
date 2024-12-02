using cinema.Abstractions.Halls;
using cinema.Data.Entities;
using cinema.Dtos;
using cinema.Helpers;

namespace cinema.Services
{
    public class HallServices : IHallServices
    {
        private readonly IHallRepository _hallRepository;
        public HallServices(IHallRepository hallRepository)
        {
            _hallRepository = hallRepository;
        }

        public async Task<Result<List<HallWithDetailsResponse>>> GetAllWithDetails()
        {
            var halls = await _hallRepository.GetAllWithDetails();

            if (halls == null || !halls.Any())
                return Result<List<HallWithDetailsResponse>>.Failure("No halls found");

            var response = halls.Select(hall => new HallWithDetailsResponse
            {
                hall_id = hall.id,
                hall_name = hall.name,
                rows = hall.rows.Select(row => new RowWithDetailsResponse
                {
                    row_id = row.id,
                    number = row.number,
                    seats = row.seats.Select(seat => new SeatResponse
                    {
                        id = seat.id,
                        number = seat.number,
                        status = seat.status
                    }).ToList()
                }).ToList()
            }).ToList();

            return Result<List<HallWithDetailsResponse>>.Success(response);
        }

        public async Task<Result<Guid>> AddHall(AddHallRequest addHallRequest)
        {
            var hall = new Hall
            {
                id = Guid.NewGuid(),
                name = addHallRequest.name,
                rows = new List<Row>()
            };

            // Добавляем ряды, если они есть
            if (addHallRequest.rows != null && addHallRequest.rows.Any())
            {
                foreach (var rowRequest in addHallRequest.rows)
                {
                    var row = new Row
                    {
                        id = Guid.NewGuid(),
                        number = rowRequest.number,
                        hall_id = hall.id,
                        seats = new List<Seat>()
                    };

                    // Добавляем места, если они есть
                    if (rowRequest.seats != null && rowRequest.seats.Any())
                    {
                        foreach (var seatRequest in rowRequest.seats)
                        {
                            var seat = new Seat
                            {
                                id = Guid.NewGuid(),
                                row_id = row.id,
                                number = seatRequest.number,
                                status = seatRequest.status
                            };

                            row.seats.Add(seat);
                        }
                    }

                    hall.rows.Add(row);
                }
            }

            // Сохраняем зал с рядами и местами
            await _hallRepository.Add(hall);

            return Result<Guid>.Success(hall.id);
        }

        public async Task<Result<Guid>> UpdateHall(UpdateHallRequest request)
        {
            // Получаем зал с рядами и местами
            var hall = await _hallRepository.GetHallWithDetails(request.Id);

            if (hall == null)
                return Result<Guid>.Failure("Зал не найден");

            // Обновляем имя зала
            hall.name = request.Name;

            // Обрабатываем ряды
            foreach (var rowRequest in request.Rows)
            {
                var existingRow = hall.rows.FirstOrDefault(r => r.id == rowRequest.Id);
                
                // проверяем существующий ряд
                if (existingRow != null)
                {
                    // Обновление существующего ряда
                    existingRow.number = rowRequest.Number;

                    // Обрабатываем места в ряду
                    foreach (var seatRequest in rowRequest.Seats)
                    {
                        var existingSeat = existingRow.seats.FirstOrDefault(s => s.id == seatRequest.Id);

                        if (existingSeat != null)
                        {
                            // Обновляем место
                            existingSeat.number = seatRequest.Number;
                            existingSeat.status = seatRequest.Status;
                        }
                        else
                        {
                            // Добавляем новое место
                            existingRow.seats.Add(new Seat
                            {
                                id = Guid.NewGuid(),
                                number = seatRequest.Number,
                                status = seatRequest.Status,
                                row_id = existingRow.id
                            });
                        }
                    }
                }
                else
                {
                    // Добавляем новый ряд с местами
                    var newRow = new Row
                    {
                        id = Guid.NewGuid(),
                        number = rowRequest.Number,
                        hall_id = hall.id,
                        seats = rowRequest.Seats.Select(s => new Seat
                        {
                            id = Guid.NewGuid(),
                            number = s.Number,
                            status = s.Status,
                        }).ToList()
                    };
                    hall.rows.Add(newRow);
                }
            }

            // Удаляем отсутствующие ряды и места
            var rowIdsToKeep = request.Rows.Select(r => r.Id).ToList();
            hall.rows.RemoveAll(r => !rowIdsToKeep.Contains(r.id));

            foreach (var row in hall.rows)
            {
                var seatIdsToKeep = request.Rows
                    .FirstOrDefault(r => r.Id == row.id)?
                    .Seats
                    .Select(s => s.Id)
                    .ToList();

                if (seatIdsToKeep != null)
                    row.seats.RemoveAll(s => !seatIdsToKeep.Contains(s.id));
            }

            // Сохраняем изменения
            await _hallRepository.Update(hall);

            return Result<Guid>.Success(hall.id);
        }

        public async Task<Result<Guid>> DeleteHall(Guid id)
        {
            var result = await _hallRepository.Delete(id);
            if (result) return Result<Guid>.Success(id);

            return Result<Guid>.Failure("Не удалось удалить зал.");
        }
    }
}
