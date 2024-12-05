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

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableMovies()
        {
            var currentDateTime = DateTime.UtcNow;
            var availableMovies = await _sessionServices.GetAvailableMovies(currentDateTime);

            if (!availableMovies.Any())
                return NotFound(new { Message = "На данный момент нет доступных фильмов." });

            return Ok(availableMovies);
        }

        [HttpGet("{session_id}")]
        public async Task<IActionResult> GetSessionDetails(Guid session_id)
        {
            var result = await _sessionServices.GetSessionDetails(session_id);

            if (!result.IsSuccess) return NotFound(new { Message = result.Error });
            
            return Ok(result.Value);
        }

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

        [HttpPut("{session_id}")]
        public async Task<IActionResult> UpdateSession(Guid session_id, [FromBody] UpdateSessionRequest request)
        {
            var result = await _sessionServices.UpdateSession(session_id, request.start_time, request.end_time,
                request.price, request.hall_name, request.movie_title);

            if (!result.IsSuccess)
                return BadRequest(new { Message = result.Error });

            return Ok(result.Value);
        }

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
