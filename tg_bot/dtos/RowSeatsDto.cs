using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tg_bot.dtos
{
    public class RowSeatsDto
    {
        public int row_number { get; set; }
        public List<int> available_seats { get; set; } = new();
    }
}
