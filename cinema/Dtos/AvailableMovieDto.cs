namespace cinema.Dtos
{
    public class AvailableMovieDto
    {
        public Guid MovieId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime SessionStartTime { get; set; }
        public DateTime SessionEndTime { get; set; }
        public string HallName { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
