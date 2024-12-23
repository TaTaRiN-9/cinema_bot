namespace cinema.Dtos
{
    public class AvailableMovieDto
    {
        public Guid id { get; set; }
        public string title { get; set; } = null!;
        public string description { get; set; } = null!;
        public DateTime start_time { get; set; }
        public int duration { get; set; }
        public string hall_name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
