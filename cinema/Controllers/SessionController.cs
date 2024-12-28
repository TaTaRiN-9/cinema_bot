using cinema.Abstractions.Sessions;
using cinema.Dtos;
using cinema.Services;
using Microsoft.AspNetCore.Mvc;

namespace cinema.Controllers
{
    [ApiController]
    [Route("api/session")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionServices _sessionServices;
        public SessionController(ISessionServices sessionServices)
        {
            _sessionServices = sessionServices;
        }
        /// <summary>
        /// Получение всех сеансов
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Список всех сеансов</response>
        /// <response code="400">Ошибка при получении сеансов</response>
        [HttpGet("all")]
        public async Task<IActionResult> GetAllSessions()
        {
            var result = await _sessionServices.GetAllSession();

            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result.Error });
            }

            return Ok(result.Value);
        }
        /// <summary>
        /// Получение всех доступных сеансов
        /// </summary>
        /// <returns>Возвращает все сеансы, на которые можно купить билет</returns>
        /// <response code="200">Список доступных сеансов</response>
        /// <response code="404">Нет доступных сеансов на данный момент</response>
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableMovies()
        {
            var currentDateTime = DateTime.UtcNow;
            var availableMovies = await _sessionServices.GetAvailableMovies(currentDateTime);

            if (!availableMovies.Any())
                return NotFound(new { Message = "На данный момент нет доступных фильмов." });

            return Ok(availableMovies);
        }
        /// <summary>
        /// Получение полной информации о сеансе
        /// </summary>
        /// <param name="session_id"></param>
        /// <returns>Возвращает полную информацию о сеансе</returns>
        /// <response code="200">Подробная информация о сеансе</response>
        /// <response code="404">Не найден такой сеанс</response>
        [HttpGet("{session_id}")]
        public async Task<IActionResult> GetSessionDetails(Guid session_id)
        {
            var result = await _sessionServices.GetSessionDetails(session_id);

            if (!result.IsSuccess) return NotFound(new { Message = result.Error });
            
            return Ok(result.Value);
        }
        /// <summary>
        /// Создание сеанса
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Созданный зал</returns>
        /// <response code="200">Созданный сеанс</response>
        /// <response code="400">Ошибка при создание сеанса</response>
        [HttpPost]
        public async Task<IActionResult> AddSession([FromBody] AddSessionRequest request)
        {
            var result = await _sessionServices.AddSession(request.start_time, request.end_time, 
                request.price, request.hall_name, request.movie_title);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return BadRequest(new { error = result.Error });
        }
        /// <summary>
        /// Обновление данных в сеансе
        /// </summary>
        /// <param name="session_id"></param>
        /// <param name="request"></param>
        /// <returns>Обновленный сеанс</returns>
        /// <response code="200">Обновленный сеанс</response>
        /// <response code="400">Ошибка при обновлении сеанса</response>
        [HttpPut("{session_id}")]
        public async Task<IActionResult> UpdateSession(Guid session_id, [FromBody] UpdateSessionRequest request)
        {
            var result = await _sessionServices.UpdateSession(session_id, request.start_time, request.end_time,
                request.price, request.hall_name, request.movie_title);

            if (!result.IsSuccess)
                return BadRequest(new { Message = result.Error });

            return Ok(result.Value);
        }
        /// <summary>
        /// Удаление сеанса
        /// </summary>
        /// <param name="session_id"></param>
        /// <returns>Возвращает id сеанса</returns>
        /// <response code="200">id сеанса</response>
        /// <response code="404">Нет такого сеанса</response>
        [HttpDelete("{session_id}")]
        public async Task<IActionResult> DeleteSession(Guid session_id)
        {
            var result = await _sessionServices.DeleteSession(session_id);

            if (!result.IsSuccess)
                return NotFound(new { Message = "Не удалось удалить сеанс" });

            return Ok(result.Value);
        }
    }
}
