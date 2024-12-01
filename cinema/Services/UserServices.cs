using cinema.Abstractions;
using cinema.Data.Entities;
using cinema.Dtos;

namespace cinema.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Add(CreateUserRequest userRequest)
        {
            User? user = User.Create(userRequest.chat_id, userRequest.phone_number);

            if (user == null) return null;

            return await _userRepository.Create(user);
        }

        public async Task<User?> GetById(Guid id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<User?> GetByChatId(string chat_id)
        {
            return await _userRepository.GetByChatId(chat_id);
        }

        public async Task<bool> Update(Guid id, string phone_number)
        {
            return await _userRepository.Update(id, phone_number);
        }
    }
}
