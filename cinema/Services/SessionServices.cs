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
                MovieId = s.movie?.id ?? Guid.Empty,
                Title = s.movie?.title ?? "Неизвестно",
                Description = s.movie?.description ?? "Нет описания",
                SessionStartTime = s.start_time,
                SessionEndTime = s.end_time,
                HallName = s.hall?.name ?? "Неизвестно",
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
    }
}
