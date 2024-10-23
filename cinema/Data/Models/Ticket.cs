using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;

namespace cinema.Data.Models
{
    public class Ticket
    {
        public int id { get; set; }
        public NpgsqlHstoreTypeMapping seat_number { get; set; }

        public int user_id { get; set; }
    }
}
