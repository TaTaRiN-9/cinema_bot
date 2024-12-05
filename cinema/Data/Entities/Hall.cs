using System.ComponentModel.DataAnnotations.Schema;

namespace cinema.Data.Entities
{
    [Table("tbl_hall")]
    public class Hall
    {
        public Guid id { get; set; }
        public string name { get; set; } = null!;
        public ICollection<Session> sessions { get; set; } = new List<Session>();
        public List<Row> rows { get; set; }
    }
}
