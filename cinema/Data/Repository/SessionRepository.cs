using cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace cinema.Data.Repository
{
    public class SessionRepository
    {
        private readonly CinemaDbContext _context;
        public SessionRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<Session> Add(Session session)
        {
            await _context.sessions.AddAsync(session);
            await _context.SaveChangesAsync();

            return session;
        }

        public async Task<Session?> GetById(Guid id)
        {
            return await _context.sessions.FirstOrDefaultAsync(s => s.id == id);
        }

        // Пользователю будем только предлагать выбрать день.
        public async Task<List<Session>> GetByDate(DateTime start_time, DateTime end_time)
        {
            return await _context.sessions.Where(s => s.start_time >= start_time && s.start_time <= end_time).ToListAsync();
        }

        public async Task<bool> Update(Session session)
        {
            Session? sessionUpdate = await _context.sessions.FirstOrDefaultAsync(s => s.id == session.id);

            if (sessionUpdate == null) return false;

            sessionUpdate.price = session.price;
            sessionUpdate.start_time = session.start_time;
            sessionUpdate.end_time = session.end_time;
            sessionUpdate.movie_id = session.movie_id;
            sessionUpdate.hall_id = session.hall_id;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            Session? session = await _context.sessions.FirstOrDefaultAsync(s => s.id == id);

            if (session == null) return false;

            _context.sessions.Remove(session);
            
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
