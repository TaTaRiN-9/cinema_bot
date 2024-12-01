using cinema.Abstractions;
using cinema.Data.Repository;
using cinema.Dtos;

namespace cinema.Services
{
    public class SessionServices : ISessionServices
    {
        private readonly ISessionRepository _sessionRepository;
        public SessionServices(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
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
    }
}
