using cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace cinema.Data.Repository
{
    public class TicketRepository
    {
        private readonly CinemaDbContext _context;

        public TicketRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Ticket ticket)
        {
            await _context.tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Ticket>> GetByUserId(Guid id)
        {
            return await _context.tickets.Where(t => t.user_id == id).ToListAsync();
        }

        public async Task<List<Ticket>> GetBySessionId(Guid id)
        {
            return await _context.tickets.Where(t => t.session_id == id).ToListAsync();
        }

        public async Task<Ticket?> GetBySessionIdAndSeatId(Guid session_id, Guid seat_id)
        {
            return await _context.tickets
                .FirstOrDefaultAsync(t => t.session_id == session_id && t.seat_id == seat_id);
        }

        public async Task<List<Ticket>> GetByUserIdAndSessionId(Guid user_id, Guid session_id)
        {
            return await _context.tickets.Where(t => t.user_id == user_id && t.session_id == session_id).ToListAsync();
        }
    }
}
