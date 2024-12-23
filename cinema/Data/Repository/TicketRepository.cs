using cinema.Abstractions.Tickets;
using cinema.Data.Entities;
using cinema.Helpers;
using Microsoft.EntityFrameworkCore;

namespace cinema.Data.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly CinemaDbContext _context;

        public TicketRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ticket>> GetAll()
        {
            return await _context.tickets
                .ToListAsync();
        }

        public async Task<bool> Add(Ticket ticket)
        {
            await _context.tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Add(List<Ticket> tickets)
        {
            await _context.tickets.AddRangeAsync(tickets);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Result<List<Ticket>>> GetByUserId(Guid id)
        {
            var tickets = await _context.tickets
                    .Include(t => t.session)
                        .ThenInclude(s => s.movie)
                    .Include(t => t.session)
                        .ThenInclude(s => s.hall)
                    .Include(t => t.seat)
                        .ThenInclude(s => s.row)
                    .Where(t => t.user_id == id)
                    .ToListAsync();

            if (!tickets.Any())
                return Result<List<Ticket>>.Failure("У пользователя нет билетов.");

            return Result<List<Ticket>>.Success(tickets);
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
