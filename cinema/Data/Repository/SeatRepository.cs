using cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace cinema.Data.Repository
{
    public class SeatRepository
    {
        private readonly CinemaDbContext _context;
        public SeatRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<Seat> Create(Seat seat)
        {
            await _context.AddAsync(seat);
            await _context.SaveChangesAsync();

            return seat;
        }

        public async Task<List<Seat>> GetSeatsByRowId(Guid row_id)
        {
            return await _context.seats.Where(s => s.row_id == row_id).ToListAsync();
        }

        public async Task<List<Seat>> GetByRowIdAndFree(Guid row_id)
        {
            return await _context.seats.Where(s => s.row_id == row_id && s.status == false).ToListAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            Seat? seat = await _context.seats.FirstOrDefaultAsync(s => s.id == id);
            
            if (seat == null) return false;

            _context.seats.Remove(seat);
            await _context.SaveChangesAsync();
            
            return true;
        }
    }
}
