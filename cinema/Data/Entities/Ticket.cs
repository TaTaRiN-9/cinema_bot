﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;

namespace cinema.Data.Entities
{
    [Table("tbl_ticket")]
    public class Ticket
    {
        public Guid id { get; set; }
        public Guid seat_id { get; set; }
        public Seat? seat { get; set; }
        // Тут будет использоваться каскадное удаление, так как тип int дает понять,
        // что свойство должно быть связано, в то время как само свойство может иметь nullable-тип
        public Guid user_id { get; set; }
        public User? user { get; set; }

        public Guid session_id { get; set; }
        public Session? session { get; set; }
    }
}
