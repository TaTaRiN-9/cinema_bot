using System.ComponentModel.DataAnnotations.Schema;

namespace cinema.Data.Models
{
    [Table("tbl_user")]
    public class User
    {
        public int id { get; set; }
        public string chat_id { get; set; }
        public string phone_number { get; set; }
    }
}
