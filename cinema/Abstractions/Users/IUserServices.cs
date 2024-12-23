using cinema.Data.Entities;
using cinema.Dtos;

namespace cinema.Abstractions.Users
{
    public interface IUserServices
    {
        Task<User?> Add(AddUserRequest userRequest);
        Task<User?> GetByChatId(long chat_id);
        Task<User?> GetByPhone(string phone_number);
        Task<User?> GetById(Guid id);
        Task<bool> Update(Guid id, string phone_number);
    }
}