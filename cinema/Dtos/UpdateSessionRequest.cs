namespace cinema.Dtos
{
    public class UpdateSessionRequest
    {
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public decimal price { get; set; }
        public string hall_name { get; set; } = null!;
        public string movie_title { get; set; } = null!;
    }
}
