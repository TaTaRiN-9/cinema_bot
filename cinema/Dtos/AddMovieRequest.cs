namespace cinema.Dtos
{
    public class AddMovieRequest
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Duration { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
