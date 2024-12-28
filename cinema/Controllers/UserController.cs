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
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns>Объект пользователя</returns>
        /// <response code="200">Созданный пользователь</response>
        /// <response code="400">Такой номер уже зарегистрирован</response>
        /// <response code="400">Такой пользователь уже существует</response>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddUserRequest userRequest)
        {
            var checkUser = await _userServices.GetByPhone(userRequest.phone_number);

            if (checkUser != null) return BadRequest("Такой номер уже зарегистрирован");

            checkUser = await _userServices.GetByChatId(userRequest.chat_id);

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
        /// <summary>
        /// Получение информации о пользователе
        /// </summary>
        /// <param name="chat_id"></param>
        /// <returns></returns>
        /// <response code="200">Получение информации о пользователе</response>
        /// <response code="404">Пользователь не найден</response>
        [HttpGet("{chat_id}")]
        public async Task<IActionResult> GetUserByChatId(long chat_id)
        {
            var user = await _userServices.GetByChatId(chat_id);
            
            if (user != null) return Ok(user);
            
            return NotFound();
        }
        /// <summary>
        /// Обновление номера телефона пользователя
        /// </summary>
        /// <param name="chat_id"></param>
        /// <param name="userRequest"></param>
        /// <returns>Обновленный пользователь</returns>
        /// <response code="200">Возвращается пользователь</response>
        /// <response code="404">Пользователь не найден</response>
        /// <response code="400">Ошибка при изменении данных</response>
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
