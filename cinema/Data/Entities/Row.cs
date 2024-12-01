using System.ComponentModel.DataAnnotations.Schema;

namespace cinema.Data.Entities
{
    [Table("tbl_row")]
    public class Row
    {
        public Guid id { get; set; }
        public int number { get; set; }
        public Guid hall_id { get; set; }
        public Hall? hall { get; set; }
        public List<Seat> seats { get; set; }
    }
}
