using cinema.Abstractions.Seats;
using cinema.Abstractions.Sessions;
using cinema.Abstractions.Tickets;
using cinema.Abstractions.Users;
using cinema.Data.Entities;
using cinema.Dtos;
using cinema.Helpers;

namespace cinema.Services
{
    public class TicketServices : ITicketServices
    {
        private readonly IUserRepository _userRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly ISessionRepository _sessionRepository;
        public TicketServices(IUserRepository userRepository, ITicketRepository ticketRepository,
            ISeatRepository seatRepository, ISessionRepository sessionRepository)
        {
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
            _seatRepository = seatRepository;
            _sessionRepository = sessionRepository;
        }

        public async Task<Result<List<Ticket>>> GetAllTickets()
        {
            List<Ticket> tickets = await _ticketRepository.GetAll();
            return Result<List<Ticket>>.Success(tickets);
        }

        public async Task<Result<List<Guid>>> AddTicket(AddTicketRequest addTicketRequest)
        {
            User? user = await _userRepository.GetById(addTicketRequest.user_id);
            if (user == null) return Result<List<Guid>>.Failure("Пользователь не найден");

            Session? session = await _sessionRepository.GetById(addTicketRequest.session_id);
            if (session == null) return Result<List<Guid>>.Failure("Такого сеанса не существует");

            var seats = await _seatRepository.AreSeatsAvailable(addTicketRequest.seat_ids);

            if (seats.Count != addTicketRequest.seat_ids.Count)
                return Result<List<Guid>>.Failure("Один или несколько мест не найдено.");

            // Проверяем, что все места свободны
            if (seats.Any(s => s.status))
                return Result<List<Guid>>.Failure("Одно или несколько мест заняты");

            // Создаем билеты
            var tickets = seats.Select(seat => Ticket.Create(seat.id, 
                addTicketRequest.user_id, addTicketRequest.session_id, seat, user, session)).ToList();

            await _ticketRepository.Add(tickets);
            await _seatRepository.UpdateSeatStatus(addTicketRequest.seat_ids);

            return Result<List<Guid>>.Success(tickets.Select(t => t.id).ToList());
        }

        public async Task<Result<List<UserTicketDto>>> GetTicketsByUserId(Guid userId)
        {
            var ticketsResult = await _ticketRepository.GetByUserId(userId);

            if (!ticketsResult.IsSuccess)
                return Result<List<UserTicketDto>>.Failure(ticketsResult.Error ?? "Unknown error");

            var tickets = ticketsResult.Value!;

            var result = tickets.Select(t => new UserTicketDto
            {
                session_start_time= t.session?.start_time ?? DateTime.MinValue,
                movie_title = t.session?.movie?.title ?? "Неизвестный фильм",
                hall_name = t.session?.hall?.name ?? "Неизвестно",
                row_number = t.seat?.row?.number ?? 0,
                seat_number = t.seat?.number ?? 0
            }).ToList();

            return Result<List<UserTicketDto>>.Success(result);
        }
    }
}
