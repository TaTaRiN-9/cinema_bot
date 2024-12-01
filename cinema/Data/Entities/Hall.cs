using System.ComponentModel.DataAnnotations.Schema;

namespace cinema.Data.Entities
{
    [Table("tbl_hall")]
    public class Hall
    {
        public Guid id { get; set; }
        public string name { get; set; } = null!;
        public Session? session { get; set; }
        public List<Row> rows { get; set; }
    }
}
