using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tg_bot.dtos
{
    public class TicketsDto
    {
        public DateTime session_start_time { get; set; }
        public string movie_title { get; set; } = null!;
        public string hall_name { get; set; } = null!;
        public int row_number { get; set; }
        public int seat_number { get; set; }
    }
}
