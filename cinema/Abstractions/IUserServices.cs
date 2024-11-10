using cinema.Data.Entities;
using cinema.Dtos;

namespace cinema.Abstractions
{
    public interface IUserServices
    {
        Task<User> Add(UserRequest userRequest);
        Task<User?> GetByChatId(string chat_id);
        Task<User?> GetById(Guid id);
        Task<bool> Update(Guid id, string phone_number);
    }
}