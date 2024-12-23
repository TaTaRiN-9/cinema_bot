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
        public async Task<IActionResult> Add([FromBody] AddUserRequest userRequest)
        {
            var checkUser = await _userServices.GetByPhone(userRequest.phone_number);

            if (checkUser != null) return Ok("Такой номер уже зарегистрирован");

            checkUser = await _userServices.GetByChatId(userRequest.chat_id);

            if (checkUser != null) return Ok("Такой пользователь уже существует!");

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
        public async Task<IActionResult> GetUserByChatId(long chat_id)
        {
            var user = await _userServices.GetByChatId(chat_id);
            
            if (user != null) return Ok(user);
            
            return NotFound();
        }

        [HttpPatch("{chat_id}")]
        public async Task<IActionResult> UpdatePhoneNumberUser(long chat_id, [FromBody] UpdateUserRequest userRequest)
        {
            var user = await _userServices.GetByChatId(chat_id);

            if (user == null) return NotFound();

            bool result = await _userServices.Update(user.id, userRequest.phone_number);

            if (!result) return BadRequest("Что-то пошло не так :(");
            return Ok(user);
        }
    }
}
