using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tg_bot.dtos
{
    public class AvailableSessionDto
    {
        public Guid id {  get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime start_time { get; set; }
        public int duration { get; set; }
        public string hall_name { get; set; }
        public decimal price { get; set; }  
    }
}
