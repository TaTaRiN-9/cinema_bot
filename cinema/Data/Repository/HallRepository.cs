using cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace cinema.Data.Repository
{
    public class HallRepository
    {
        private readonly CinemaDbContext _context;
        public HallRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<Hall> Add(Hall hall)
        {
            await _context.halls.AddAsync(hall);
            await _context.SaveChangesAsync();

            return hall;
        }

        public async Task<Hall?> GetById(Guid id)
        {
            return await _context.halls.FirstOrDefaultAsync(h => h.id == id);
        }

        public async Task<Hall?> GetByName(string name)
        {
            return await _context.halls.FirstOrDefaultAsync(h => h.name == name);
        }

        public async Task<bool> Update(Hall hall)
        {
            Hall? hallUpdate = await _context.halls.FirstOrDefaultAsync(h => h.id == hall.id);

            if (hallUpdate == null) return false;

            hallUpdate.name = hall.name;
            
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            Hall? hall = await _context.halls.FirstOrDefaultAsync(h => h.id == id);
            if (hall == null) return false;

            _context.halls.Remove(hall);
            
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
