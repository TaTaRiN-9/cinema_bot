using System.ComponentModel.DataAnnotations.Schema;

namespace cinema.Data.Entities
{
    [Table("tbl_movie")]
    public class Movie
    {
        public int id { get; set; }
        public string title { get; set; } = null!;
        public string description { get; set; } = null!;
        // на первое время будем использовать int в минутах. Потом можно будет применить тип duration в postgres
        public int duration { get; set; }
        public string? photo_url { get; set; }
        public Session? session { get; set; }
    }
}
