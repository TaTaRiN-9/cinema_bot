using cinema.Abstractions.Halls;
using cinema.Dtos;
using cinema.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace cinema.Controllers
{
    [ApiController]
    [Route("api/hall")]
    public class HallController : ControllerBase
    {
        private readonly IHallServices _hallServices;
        private readonly ILogger<HallController> _logger;
        public HallController(IHallServices hallServices, ILogger<HallController> logger)
        {
            _hallServices = hallServices;
            _logger = logger;
        }

        /// <summary>
        /// Получение всех залов
        /// </summary>
        /// <returns>Список залов</returns>
        /// <response code="200">Список залов</response>
        /// <response code="400">Ошибка при получении залов</response>
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _hallServices.GetAllWithDetails();

            _logger.LogInformation("Получение всех залов");
            if (!result.IsSuccess)
                return BadRequest(new { Message = result.Error });

            return Ok(result.Value);
        }
        /// <summary>
        /// Создание зала
        /// </summary>
        /// <param name="addHallRequest"></param>
        /// <returns>Созданный зал с рядами и местами</returns>
        /// <remarks>
        /// Запрос создания зала:
        /// 
        ///     POST /hall
        ///       {
        ///         "name": "Название зала",
        ///         "rows": [
        ///           {
        ///             "number": 1,
        ///             "seats": [
        ///               {
        ///                 "number": 1,
        ///                 "status": false
        ///               },
        ///               {
        ///                 "number": 2,
        ///                 "status": false
        ///               }
        ///             ]
        ///           }
        ///         ]
        ///       }
        /// </remarks>
        /// <response code="200">Возвращает созданный зал</response>
        /// <response code="400">Что-то пошло не так</response>
        [HttpPost]
        public async Task<IActionResult> AddHall(AddHallRequest addHallRequest)
        {
            var result = await _hallServices.AddHall(addHallRequest);

            _logger.LogInformation("Добавление зала");
            if (!result.IsSuccess)
                return BadRequest(new { Message = result.Error });

            return Ok(result.Value);
        }

        /// <summary>
        /// Обновление зала
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateHallRequest"></param>
        /// <returns>Обновленный зал</returns>
        /// <response code="200">Обновленный зал</response>
        /// <response code="400">Ошибка при обновлении зала</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHall(Guid id, [FromBody] UpdateHallRequest updateHallRequest)
        {
            updateHallRequest.Id = id;
            var result = await _hallServices.UpdateHall(updateHallRequest);

            _logger.LogInformation("Обновление зала");
            if (!result.IsSuccess)
                return BadRequest(new { Message = result.Error });

            return Ok(result);
        }

        /// <summary>
        /// Удаление зала
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Возвращает id зала</returns>
        /// <response code="200">id зала</response>
        /// <response code="400">Ошибка при удалении зала</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHall(Guid id)
        {
            var result = await _hallServices.DeleteHall(id);

            _logger.LogInformation("Удаление зала");
            
            if (!result.IsSuccess)
                return BadRequest(new { Message = result.Error });

            return Ok(result.Value);
        }
    }
}
