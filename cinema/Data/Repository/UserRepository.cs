using cinema.Abstractions;
using cinema.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace cinema.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CinemaDbContext _context;
        public UserRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetByChatId(string chat_id)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.chat_id == chat_id);
            return user;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.id == id);
            return user;
        }

        public async Task<bool> UpdateData(int id, string phone_number)
        {
            var users = await _context.users.Where(u => u.id == id).ToListAsync();

            if (users.Count == 0) return false;

            var user = users[0];
            user.phone_number = phone_number;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
