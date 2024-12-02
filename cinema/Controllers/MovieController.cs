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

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _movieServices.GetAllMovies();

            if (!result.IsSuccess)
                return BadRequest(new { Message = result.Error });

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] AddMovieRequest addMovieRequest)
        {
            var result = await _movieServices.AddMovie(addMovieRequest);
            if (!result.IsSuccess)
                return BadRequest(new { Message = result.Error });

            return Ok(result.Value);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieRequest updateMovieRequest)
        {
            var result = await _movieServices.UpdateMovie(updateMovieRequest);
            if (!result.IsSuccess)
                return BadRequest(new { Message = result.Error });

            return Ok("success");
        }

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
