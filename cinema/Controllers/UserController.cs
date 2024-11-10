using cinema.Abstractions;
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
        public async Task<IActionResult> Add([FromBody] UserRequest userRequest)
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


    }
}
