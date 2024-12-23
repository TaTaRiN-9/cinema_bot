using cinema.Abstractions.Seats;
using cinema.Data.Entities;
using cinema.Helpers;
using Microsoft.EntityFrameworkCore;

namespace cinema.Data.Repository
{
    public class SeatRepository : ISeatRepository
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

        public async Task UpdateSeatStatus(List<Guid> seat_ids)
        {
            var seats = await _context.seats
                .Where(s => seat_ids.Contains(s.id))
                .ToListAsync();

            foreach (var seat in seats)
            {
                seat.status = true; // Место занято
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<Seat>> AreSeatsAvailable(List<Guid> seatIds)
        {
            return await _context.seats
                .Where(s => seatIds.Contains(s.id))
                .ToListAsync();
        }

        public async Task<Seat?> GetById(Guid id)
        {
            return await _context.seats.FirstOrDefaultAsync(s => s.id == id);
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

        public async Task Update(Seat seat)
        {
            _context.seats.Update(seat);
            await _context.SaveChangesAsync();
        }
    }
}
