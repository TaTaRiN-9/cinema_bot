using cinema.Abstractions.Tickets;
using cinema.Broker;
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
        private readonly IRabbitMqService _rabbitMqService;
        private readonly ILogger<TicketController> _logger;
        public TicketController(ITicketServices ticketServices, IRabbitMqService rabbitMqService, ILogger<TicketController> logger)
        {
            _ticketServices = ticketServices;
            _rabbitMqService = rabbitMqService;
            _logger = logger;
        }
        /// <summary>
        /// Создание билета, то есть его покупка
        /// </summary>
        /// <param name="addTicketRequest"></param>
        /// <returns>Создание билета</returns>
        /// <response code="200">Созданный билет</response>
        /// <response code="400">Ошибка при формировании билета</response>
        [HttpPost("add")]
        public async Task<IActionResult> AddTicket([FromBody] AddTicketRequest addTicketRequest)
        {
            Result<List<Guid>> result = await _ticketServices.AddTicket(addTicketRequest);

            if (!result.IsSuccess)
                return BadRequest(new { Message = result.Error });

            _logger.LogInformation("Создание билета");
            _rabbitMqService.SendMessage(result.Value ?? new object());
            return Ok(new { Message = "Билет(ы) успешно добавлен(ы)", ticket_ids = result.Value });
        }
        /// <summary>
        /// Получение всех билетов
        /// </summary>
        /// <returns>Возвращаются все билеты</returns>
        /// <response code="200">Список билетов</response>
        /// <response code="400">Произошла ошибка при получении билетов</response>
        [HttpGet("get-all")]
        public async Task<IActionResult> GetTickets()
        {
            var result = await _ticketServices.GetAllTickets();

            if (!result.IsSuccess)
                return BadRequest(new {Message = result.Error});

            _logger.LogInformation("Получение всех билетов успешно");

            return Ok(new { Message = "Билеты успешно получены", tickets = result.Value });
        }

        /// <summary>
        /// Получение билетов определенного пользователя
        /// </summary>
        /// <param name="chat_id"></param>
        /// <returns>Билеты пользователя</returns>
        /// <response code="200">Список билетов определенного пользователя</response>
        /// <response code="400">Ошибка при получении билетов пользователя</response>
        [HttpGet("user-tickets/{chat_id}")]
        public async Task<IActionResult> GetUserTickets(long chat_id)
        {
            var result = await _ticketServices.GetTicketsByChatId(chat_id);

            if (!result.IsSuccess)
                return BadRequest(new { Message = result.Error });

            _logger.LogInformation("Получение билетов пользователя: " + chat_id);
            return Ok(result.Value);
        }
    }
}
