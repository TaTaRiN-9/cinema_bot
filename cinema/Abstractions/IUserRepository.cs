using cinema.Data.Entities;

namespace cinema.Abstractions
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User?> GetByChatId(string chat_id);
        Task<User?> GetById(Guid id);
        Task<bool> Update(Guid id, string phone_number);
    }
}