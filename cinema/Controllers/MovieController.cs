using cinema.Abstractions.Movies;
using cinema.Dtos;
using cinema.Services;
using Microsoft.AspNetCore.Mvc;

namespace cinema.Controllers
{
    [ApiController]
    [Route("api/movie")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieServices _movieServices;
        public MovieController(IMovieServices movieServices)
        {
            _movieServices = movieServices;
        }
        /// <summary>
        /// Получение всех фильмов
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Список всех фильмов</response>
        /// <response code="400">Ошибка при получении всех фильмов</response>
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _movieServices.GetAllMovies();

            if (!result.IsSuccess)
                return BadRequest(new { Message = result.Error });

            return Ok(result.Value);
        }
        /// <summary>
        /// Создание фильма
        /// </summary>
        /// <param name="addMovieRequest"></param>
        /// <returns></returns>
        /// <remarks>
        /// 
        /// POST  {
        ///         "title": "string",
        ///         "description": "string",
        ///         "duration": 0,
        ///         "photoUrl": "string"
        ///       }
        /// 
        /// 
        /// </remarks>
        /// <response code="200">Возвращает созданный фильм</response>
        /// <response code="400">Ошибка при создании фильма</response>
        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] AddMovieRequest addMovieRequest)
        {
            var result = await _movieServices.AddMovie(addMovieRequest);
            if (!result.IsSuccess)
                return BadRequest(new { Message = result.Error });

            return Ok(result.Value);
        }

        /// <summary>
        /// Обновление данных о фильме
        /// </summary>
        /// <param name="updateMovieRequest"></param>
        /// <returns></returns>
        /// <response code="200">Обновленный фильм</response>
        /// <response code="400">Ошибка при обновлении фильма</response>
        [HttpPatch]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieRequest updateMovieRequest)
        {
            var result = await _movieServices.UpdateMovie(updateMovieRequest);
            if (!result.IsSuccess)
                return BadRequest(new { Message = result.Error });

            return Ok("success");
        }
        /// <summary>
        /// Удаление фильма
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Возвращает id фильма</response>
        /// <response code="400">Ошибка при удалении залов</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            var result = await _movieServices.DeleteMovie(id);
            if (!result.IsSuccess)
                return BadRequest(new {Message = result.Error});

            return Ok(result.Value);
        }
    }
}
