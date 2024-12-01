using cinema.Abstractions;
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

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableMovies()
        {
            var currentDateTime = DateTime.UtcNow;
            var availableMovies = await _sessionServices.GetAvailableMovies(currentDateTime);

            if (!availableMovies.Any())
                return NotFound(new { Message = "На данный момент нет доступных фильмов." });

            return Ok(availableMovies);
        }
    }
}
