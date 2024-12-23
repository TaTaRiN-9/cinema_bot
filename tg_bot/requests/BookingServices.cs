using System.Text;
using System.Text.Json;
using tg_bot.abstractions;
using tg_bot.dtos;
using System.Net.Http.Json;
using Microsoft.Extensions.Caching.Memory;

namespace tg_bot.requests
{
    public class BookingServices : IBookingServices
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        public BookingServices(HttpClient httpClient, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _cache = cache;
        }

        public async Task<bool> RegisterUser(long chat_id, string phone_number)
        {
            var payload = new
            {
                chat_id,
                phone_number
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("api/user", jsonContent);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отправке запроса: {ex.Message}");
                return false;
            }
        }

        public async Task<List<TicketsDto>> GetTicketByChatId(long chatId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/ticket/user-tickets/{chatId}");
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadFromJsonAsync<List<TicketsDto>>();
                    return result.Result;
                }
                else
                {
                    Console.WriteLine($"Что-то пошло не так при отправке запроса: {response.Content.ReadAsStringAsync()}");
                }
                return new List<TicketsDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отправке запроса: {ex.Message}");
                return new List<TicketsDto>();
            }
        }

        public async Task<List<AvailableSessionDto>> GetAvailableSession()
        {
            try
            {
                if (!_cache.TryGetValue("sessions", out List<AvailableSessionDto>? sessions))
                {
                    var response = await _httpClient.GetAsync("api/session/available");
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadFromJsonAsync<List<AvailableSessionDto>>();
                        
                        _cache.Set("sessions", result.Result, TimeSpan.FromMinutes(10));
                        
                        sessions = result.Result;
                    }
                    else
                    {
                        Console.WriteLine($"Что-то пошло не так при отправке запроса: {response.Content.ReadAsStringAsync()}");
                    }
                }
                return sessions;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отправке запроса: {ex.Message}");
            }
            return new List<AvailableSessionDto>();
        }

        public async Task<SessionDetailsDto?> GetSessionDetails(Guid id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/session/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadFromJsonAsync<SessionDetailsDto>();

                    return result.Result;
                }
                else
                {
                    Console.WriteLine($"Что-то пошло не так при отправке запроса: {response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отправке запроса: {ex.Message}");
            }
            return null;
        }
    }
}
