namespace cinema.Dtos
{
    public class SessionDetailsDto
    {
        public string movie_title { get; set; } = null!;
        public string movie_description { get; set; } = null!;
        public DateTime session_start_time { get; set; }
        public int movie_duration { get; set; }
        public decimal price { get; set; }
        public List<RowSeatsDto> available_rows { get; set; } = new();
    }
}
