using cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace cinema.Data.Repository
{
    public class RowRepository
    {
        private readonly CinemaDbContext _context;
        public RowRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<Row> Create(Row row)
        {
            await _context.rows.AddAsync(row);
            await _context.SaveChangesAsync();
            
            return row;
        }

        public async Task<List<Row>> GetByHallId(Guid hall_id)
        {
            return await _context.rows.Where(h => h.hall_id == hall_id).ToListAsync();
        }

        public async Task<Row?> GetByNumber(int number)
        {
            return await _context.rows.FirstOrDefaultAsync(h => h.number == number);
        }
    }
}
