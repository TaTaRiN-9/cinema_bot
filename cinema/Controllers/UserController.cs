using cinema.Abstractions.Helpers;
using cinema.Abstractions.Users;
using cinema.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace cinema.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IJwtServices _jwtServices;
        public UserController(IUserServices userServices, IJwtServices jwtServices) 
        {
            _userServices = userServices;
            _jwtServices = jwtServices;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserRequest userRequest)
        {
            var checkUser = await _userServices.GetByChatId(userRequest.chat_id);

            if (checkUser != null) return BadRequest("Такой пользователь уже существует!");

            var user = await _userServices.Add(userRequest);

            string jwtToken = _jwtServices.Generate(user.chat_id);

            var response = new
            {
                user,  
                access_token = jwtToken,
            };

            return Created("Success", response);
        }

        [HttpGet("{chat_id}")]
        public async Task<IActionResult> GetUserByChatId(string chat_id)
        {
            var user = await _userServices.GetByChatId(chat_id);
            
            if (user != null) return Ok(user);
            
            return NotFound();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePhoneNumberUser([FromBody] CreateUserRequest userRequest)
        {
            var user = await _userServices.GetByChatId(userRequest.chat_id);

            if (user == null) return NotFound();

            bool result = await _userServices.Update(user.id, userRequest.phone_number);

            if (!result) return BadRequest("Что-то пошло не так :(");
            return Ok(user);
        }
    }
}
