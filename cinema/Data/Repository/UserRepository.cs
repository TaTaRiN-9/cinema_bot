using cinema.Abstractions.Users;
using cinema.Data.Entities;
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

        public async Task<User?> GetByChatId(string chat_id)
        {
            return await _context.users.FirstOrDefaultAsync(u => u.chat_id == chat_id);
        }

        public async Task<User?> GetById(Guid id)
        {
            return await _context.users.FirstOrDefaultAsync(u => u.id == id);
        }

        public async Task<bool> Update(Guid id, string phone_number)
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
