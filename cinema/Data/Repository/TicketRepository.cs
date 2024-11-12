using cinema.Data.Entities;

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
            await _context.AddAsync(ticket);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
