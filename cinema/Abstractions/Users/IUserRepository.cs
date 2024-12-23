using cinema.Data.Entities;

namespace cinema.Abstractions.Users
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User?> GetByPhone(string phone_number);
        Task<User?> GetByChatId(long chat_id);
        Task<User?> GetById(Guid id);
        Task<bool> Update(Guid id, string phone_number);
    }
}