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
        public HallController(IHallServices hallServices)
        {
            _hallServices = hallServices;
        }

        /// <summary>
        /// Получение всех залов
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _hallServices.GetAllWithDetails();

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
        /// <response code="400">Если что-то пошло не так, например, такой зал уже существует</response>
        [HttpPost]
        public async Task<IActionResult> AddHall(AddHallRequest addHallRequest)
        {
            var result = await _hallServices.AddHall(addHallRequest);
            if (!result.IsSuccess)
                return BadRequest(new { Message = result.Error });

            return Ok(result.Value);
        }

        /// <summary>
        /// Обновление зала
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateHallRequest"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHall(Guid id, [FromBody] UpdateHallRequest updateHallRequest)
        {
            updateHallRequest.Id = id;
            var result = await _hallServices.UpdateHall(updateHallRequest);

            if (!result.IsSuccess)
                return BadRequest(new { Message = result.Error });

            return Ok(result);
        }

        /// <summary>
        /// Удаление зала
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHall(Guid id)
        {
            var result = await _hallServices.DeleteHall(id);
            
            if (!result.IsSuccess)
                return BadRequest(new { Message = result.Error });

            return Ok(result.Value);
        }
    }
}
