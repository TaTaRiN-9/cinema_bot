using cinema.Data.Entities;
using cinema.Dtos;
using cinema.Helpers;

namespace cinema.Abstractions.Tickets
{
    public interface ITicketServices
    {
        Task<Result<List<Ticket>>> GetAllTickets();
        Task<Result<List<UserTicketDto>>> GetTicketsByUserId(Guid userId);
        Task<Result<List<Guid>>> AddTicket(AddTicketRequest addTicketRequest);
    }
}