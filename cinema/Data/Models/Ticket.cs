using System.ComponentModel.DataAnnotations.Schema;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;

namespace cinema.Data.Models
{
    [Table("tbl_ticket")]
    public class Ticket
    {
        public int id { get; set; }
        // Переделать?
        public NpgsqlHstoreTypeMapping seat_number { get; set; }
        public int user_id { get; set; }
        public int session_id { get; set; }
    }
}
