namespace cinema.Dtos
{
    public class UpdateMovieRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Duration { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
