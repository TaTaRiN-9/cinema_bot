namespace cinema.Dtos
{
    /// <summary>
    /// Модель запроса для создания сеанса
    /// </summary>
    public class AddSessionRequest
    {
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public decimal price { get; set; }
        public string hall_name { get; set; } = null!;
        public string movie_title { get; set; } = null!;
    }
}
