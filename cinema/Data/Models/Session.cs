namespace cinema.Data.Models
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public decimal price { get; set; }
        public int hall_id { get; set; }
        public int movie_id { get; set; }
    }
}
