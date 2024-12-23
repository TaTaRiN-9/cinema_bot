using cinema.Abstractions.Tickets;
using cinema.Dtos;
using cinema.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace cinema.Controllers
{
    [ApiController]
    [Route("api/ticket")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketServices _ticketServices;
        public TicketController(ITicketServices ticketServices)
        {
            _ticketServices = ticketServices;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTicket([FromBody] AddTicketRequest addTicketRequest)
        {
            Result<List<Guid>> result = await _ticketServices.AddTicket(addTicketRequest);

            if (!result.IsSuccess)
                return BadRequest(new { Message = result.Error });

            return Ok(new { Message = "Билет(ы) успешно добавлен(ы)", ticket_ids = result.Value });
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetTickets()
        {
            var result = await _ticketServices.GetAllTickets();

            if (!result.IsSuccess)
                return BadRequest(new {Message = result.Error});

            return Ok(new { Message = "Билеты успешно получены", tickets = result.Value });
        }

        [HttpGet("user-tickets/{userId}")]
        public async Task<IActionResult> GetUserTickets(Guid userId)
        {
            var result = await _ticketServices.GetTicketsByUserId(userId);

            if (!result.IsSuccess)
                return BadRequest(new { Message = result.Error });

            return Ok(result.Value);
        }
    }
}
