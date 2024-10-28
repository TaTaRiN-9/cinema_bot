using cinema.Data.Models;

namespace cinema.Abstractions
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User> GetByChatId(string chat_id);
        Task<User> GetById(int id);
        Task<bool> UpdateData(int id, string phone_number);
    }
}