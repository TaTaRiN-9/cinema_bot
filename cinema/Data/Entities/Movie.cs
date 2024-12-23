using System.ComponentModel.DataAnnotations.Schema;

namespace cinema.Data.Entities
{
    [Table("tbl_movie")]
    public class Movie
    {
        public Guid id { get; set; }
        public string title { get; set; } = null!;
        public string description { get; set; } = null!;
        // на первое время будем использовать int в минутах. Потом можно будет применить тип duration в postgres
        public int duration { get; set; }
        public string? photo_url { get; set; }
        public ICollection<Session> sessions { get; set; } = new List<Session>();

        public Movie() { }

        private Movie(string title, string description, int duration, string photo_url)
        {
            this.title = title;
            this.description = description;
            this.duration = duration;
            this.photo_url = photo_url;
        }

        public static Movie Create(string title, string description, int duration, string photo_url)
        {
            return new Movie(title, description, duration, photo_url);
        }
    }
}
