using tg_bot.dtos;

namespace tg_bot.abstractions
{
    public interface IBookingServices
    {
        Task<bool> RegisterUser(long chat_id, string phone_number);
        Task<List<TicketsDto>> GetTicketByChatId(long chatId);
        Task<List<AvailableSessionDto>> GetAvailableSession();
        Task<SessionDetailsDto?> GetSessionDetails(Guid id);
    }
}