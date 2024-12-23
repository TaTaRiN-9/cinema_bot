using System;
using cinema.Abstractions.Halls;
using cinema.Abstractions.Movies;
using cinema.Abstractions.Sessions;
using cinema.Data.Entities;
using cinema.Dtos;
using cinema.Helpers;

namespace cinema.Services
{
    public class SessionServices : ISessionServices
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IHallRepository _hallRepository;
        private readonly IMovieRepository _movieRepository;
        public SessionServices(ISessionRepository sessionRepository, IHallRepository hallRepository, 
            IMovieRepository movieRepository)
        {
            _sessionRepository = sessionRepository;
            _hallRepository = hallRepository;
            _movieRepository = movieRepository;
        }

        public async Task<Result<List<Session>>> GetAllSession()
        {
            var sessions = await _sessionRepository.GetAll();

            if (sessions == null || !sessions.Any())
            {
                return Result<List<Session>>.Failure("Сеансы не были найдены.");
            }

            return Result<List<Session>>.Success(sessions);
        }

        public async Task<List<AvailableMovieDto>> GetAvailableMovies(DateTime currentDateTime)
        {
            var sessions = await _sessionRepository.GetAvailableSessions(currentDateTime);

            return sessions.Select(s => new AvailableMovieDto
            {
                id = s.id,
                title = s.movie?.title ?? "Неизвестно",
                description = s.movie?.description ?? "Нет описания",
                start_time = s.start_time,
                duration = s.movie?.duration ?? 0,
                hall_name = s.hall?.name ?? "Неизвестно",
                Price = s.price
            }).ToList();
        }

        public async Task<Result<SessionDetailsDto>> GetSessionDetails(Guid session_id)
        {
            // получаем сеанс
            var session = await _sessionRepository.GetSessionDetails(session_id);

            // проверяем, есть ли такой
            if (session == null) return Result<SessionDetailsDto>.Failure("Такого сеанса не существует.");

            if (session.movie == null || session.hall == null)
                return Result<SessionDetailsDto>.Failure("К сожалению, нет возможности выбрать этот сеанс.");

            // нужны только свободные места и свободные ряды соответсвенно
            var availableRows = session.hall.rows.Select(row => new RowSeatsDto
            {
                row_number = row.number,
                available_seats = row.seats
                    .Where(seat => !seat.status) 
                    .Select(seat => seat.number)
                    .ToList()
            }).Where(row => row.available_seats.Any())
            .ToList();

            var result = new SessionDetailsDto
            {
                id = session_id,
                movie_title = session.movie.title,
                movie_description = session.movie.description,
                session_start_time = session.start_time,
                movie_duration = session.movie.duration,
                price = session.price,
                available_rows = availableRows
            };

            return Result<SessionDetailsDto>.Success(result);
        }

        public async Task<Result<Session>> AddSession(DateTime startTime, DateTime endTime, decimal price, string hallName, string movieTitle)
        {
            if (startTime >= endTime)
                return Result<Session>.Failure("Время начало фильма не должно быть меньше, чем конечное.");

            if (price <= 0)
                return Result<Session>.Failure("Цена не может быть ниже нуля.");

            try
            {
                // Проверяем, существует ли зал с таким названием
                var hall = await _hallRepository.GetByName(hallName);
                if (hall == null)
                    return Result<Session>.Failure($"Зал с именем '{hallName}' не существует.");

                // Проверяем, существует ли фильм с таким названием
                var movie = await _movieRepository.GetByTitle(movieTitle);
                if (movie == null)
                    return Result<Session>.Failure($"Фильм с таким названием '{movieTitle}' не существует.");

                // Проверяем, не пересекается ли время нового сеанса с существующими в этом зале
                var overlappingSession = await _sessionRepository.CheckingSessionOverlap(hall.id, startTime, endTime);
                if (overlappingSession != null)
                    return Result<Session>.Failure($"Сеанс уже существует в зале '{hallName}' в такое время.");

                // Создаём и сохраняем новый сеанс
                var newSession = new Session
                {
                    id = Guid.NewGuid(),
                    start_time = startTime,
                    end_time = endTime,
                    price = price,
                    hall_id = hall.id,
                    hall = hall,
                    movie_id = movie.id,
                    movie = movie,
                    tickets = new List<Ticket>()
                };

                var result = await _sessionRepository.Add(newSession);

                return Result<Session>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<Session>.Failure($"Ошибка, которая появилась во время создания сеанса: {ex.Message}");
            }
        }

        public async Task<Result<Session>> UpdateSession(Guid session_id, DateTime start_time, DateTime end_time, decimal price, string hall_name, string movie_title)
        {
            if (start_time >= end_time)
                return Result<Session>.Failure("Время начало сеанса не может быть позже, чем время окончания");

            if (price <= 0)
                return Result<Session>.Failure("Цена не может быть отрицательной");

            try
            {
                // проверяем, есть ли такой сеанс
                var exist_session = await _sessionRepository.GetById(session_id);
                if (exist_session == null)
                    return Result<Session>.Failure("Такого сеанса не существует.");

                // проверяем, существует ли зал с таким именем
                var exist_hall = await _hallRepository.GetByName(hall_name);
                if (exist_hall == null)
                    return Result<Session>.Failure("Такого зала не существует.");

                // проверяем, существует ли фильм с таким названием
                var exist_movie = await _movieRepository.GetByTitle(movie_title);
                if (exist_movie == null)
                    return Result<Session>.Failure("Такого фильма не существует.");

                // Проверяем, не пересекается ли время нового сеанса с существующими в этом зале
                var overlappingSession = await _sessionRepository.CheckingSessionOverlap(exist_hall.id, start_time, end_time);
                if (overlappingSession != null)
                    return Result<Session>.Failure($"Сеанс уже существует в зале '{hall_name}' в такое время.");

                var result = await _sessionRepository.Update(exist_session, start_time, end_time, price, exist_hall, exist_movie);
                if (!result)
                    return Result<Session>.Failure("Что-то пошло не так..");

                return Result<Session>.Success(exist_session);


            } catch (Exception ex)
            {
                return Result<Session>.Failure($"Что-то пошло не так во время обновления сеанса: {ex.Message}");
            }
        }

        public async Task<Result<Guid>> DeleteSession(Guid session_id)
        {
            var result = await _sessionRepository.Delete(session_id);
            if (!result)
                return Result<Guid>.Failure("Что-то пошло не так..");

            return Result<Guid>.Success(session_id);
        }
    }
}
