using System.ComponentModel.DataAnnotations.Schema;

namespace cinema.Data.Models
{
    [Table("tbl_hall")]
    public class Hall
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public Session? session { get; set; }
        public List<Row> rows { get; set; }
    }
}
