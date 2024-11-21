using cinema.Data.Entities;

namespace cinema.Abstractions
{
    public interface ITicketRepository
    {
        Task<bool> Create(Ticket ticket);
        Task<List<Ticket>> GetBySessionId(Guid id);
        Task<Ticket?> GetBySessionIdAndSeatId(Guid session_id, Guid seat_id);
        Task<List<Ticket>> GetByUserId(Guid id);
        Task<List<Ticket>> GetByUserIdAndSessionId(Guid user_id, Guid session_id);
    }
}