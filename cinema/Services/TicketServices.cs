using cinema.Abstractions;
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

        public async Task<Result<Guid>> AddTicket(AddTicketRequest addTicketRequest)
        {
            User? user = await _userRepository.GetById(addTicketRequest.user_id);
            if (user == null) return Result<Guid>.Failure("Пользователь не найден");

            Seat? seat = await _seatRepository.GetById(addTicketRequest.seat_id);
            if (seat == null) return Result<Guid>.Failure("Такого места не существует");

            // Проверяем статус места
            if (seat.status)
                return Result<Guid>.Failure("Это место уже занято!");

            Session? session = await _sessionRepository.GetById(addTicketRequest.session_id);
            if (session == null) return Result<Guid>.Failure("Такого сеанса не существует");

            Ticket? ticket = Ticket.Create(addTicketRequest.seat_id, addTicketRequest.user_id,
                addTicketRequest.session_id, seat, user, session);

            seat.status = true;
            await _seatRepository.Update(seat);

            await _ticketRepository.Add(ticket);

            return Result<Guid>.Success(ticket.id);
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
