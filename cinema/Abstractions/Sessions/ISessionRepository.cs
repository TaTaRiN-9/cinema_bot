using cinema.Data.Entities;

namespace cinema.Abstractions.Sessions
{
    public interface ISessionRepository
    {
        Task<Session> Add(Session session);
        Task<List<Session>> GetAll();
        Task<bool> Delete(Guid id);
        Task<List<Session>> GetByDate(DateTime start_time, DateTime end_time);
        Task<Session?> GetById(Guid id);
        Task<bool> Update(Session session, DateTime start_time, DateTime end_time, decimal price, Hall hall, Movie movie);
        Task<List<Session>> GetAvailableSessions(DateTime currentDateTime);
        Task<Session?> GetSessionDetails(Guid id);
        Task<Session?> CheckingSessionOverlap(Guid id, DateTime start_time, DateTime end_time);
    }
}