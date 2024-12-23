using cinema.Data.Entities;
using cinema.Dtos;
using cinema.Helpers;

namespace cinema.Abstractions.Sessions
{
    public interface ISessionServices
    {
        Task<Result<List<Session>>> GetAllSession();
        Task<List<AvailableMovieDto>> GetAvailableMovies(DateTime currentDateTime);
        Task<Result<SessionDetailsDto>> GetSessionDetails(Guid session_id);
        Task<Result<Session>> AddSession(DateTime startTime, DateTime endTime, 
            decimal price, string hallName, string movieTitle);
        Task<Result<Session>> UpdateSession(Guid session_id, DateTime start_time, 
            DateTime end_time, decimal price, string hall_name, string movie_title);
        Task<Result<Guid>> DeleteSession(Guid session_id);
    }
}