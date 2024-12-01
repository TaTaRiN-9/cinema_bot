using cinema.Data.Entities;

namespace cinema.Abstractions
{
    public interface ISessionRepository
    {
        Task<Session> Add(Session session);
        Task<bool> Delete(Guid id);
        Task<List<Session>> GetByDate(DateTime start_time, DateTime end_time);
        Task<Session?> GetById(Guid id);
        Task<bool> Update(Session session);
        Task<List<Session>> GetAvailableSessions(DateTime currentDateTime);
    }
}