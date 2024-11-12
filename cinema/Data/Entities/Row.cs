using System.ComponentModel.DataAnnotations.Schema;

namespace cinema.Data.Entities
{
    [Table("tbl_row")]
    public class Row
    {
        public int id { get; set; }
        public int number { get; set; }
        public int hall_id { get; set; }
        public Hall? hall { get; set; }
        public List<Seat> seats { get; set; }
    }
}
