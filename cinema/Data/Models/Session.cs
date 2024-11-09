using System.ComponentModel.DataAnnotations.Schema;

namespace cinema.Data.Models
{
    [Table("tbl_session")]
    public class Session
    {
        public int id { get; set; }
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public decimal price { get; set; }

        public int hall_id { get; set; }
        public Hall? hall { get; set; }
        public int movie_id { get; set; }
        public Movie? movie { get; set; }
        public List<Ticket> tickets { get; set; }
    }
}
