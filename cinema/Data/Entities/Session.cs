using System.ComponentModel.DataAnnotations.Schema;

namespace cinema.Data.Entities
{
    [Table("tbl_session")]
    public class Session
    {
        public Guid id { get; set; }
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public decimal price { get; set; }

        public Guid hall_id { get; set; }
        public Hall? hall { get; set; }
        public Guid movie_id { get; set; }
        public Movie? movie { get; set; }
        public List<Ticket> tickets { get; set; }
    }
}
