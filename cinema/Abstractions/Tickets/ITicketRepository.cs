using cinema.Data.Entities;
using cinema.Dtos;
using cinema.Helpers;

namespace cinema.Abstractions.Tickets
{
    public interface ITicketRepository
    {
        Task<bool> Add(Ticket ticket);
        Task<bool> Add(List<Ticket> tickets);
        Task<List<Ticket>> GetAll();
        Task<List<Ticket>> GetBySessionId(Guid id);
        Task<Ticket?> GetBySessionIdAndSeatId(Guid session_id, Guid seat_id);
        Task<Result<List<Ticket>>> GetByUserId(Guid id);
        Task<List<Ticket>> GetByUserIdAndSessionId(Guid user_id, Guid session_id);
    }
}