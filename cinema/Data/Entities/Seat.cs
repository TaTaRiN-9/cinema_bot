﻿using System.ComponentModel.DataAnnotations.Schema;

namespace cinema.Data.Entities
{
    [Table("tbl_seat")]
    public class Seat
    {
        public Guid id { get; set; }
        public Guid row_id { get; set; }
        public Row? row { get; set; }
        public int number { get; set; }
        public bool status { get; set; }
        public Ticket? ticket { get; set; }
    }
}
