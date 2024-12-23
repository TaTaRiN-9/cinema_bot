using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tg_bot.dtos;

namespace tg_bot.helpers
{
    public class ParseHelper
    {
        public static bool TryParsePair(string input, out SelectTicketsDto ticket)
        {
            ticket = null;

            var parts = input.Split('-');
            if (parts.Length == 2 &&
                int.TryParse(parts[0], out int field1) &&
                int.TryParse(parts[1], out int field2))
            {
                ticket = new SelectTicketsDto { row = field1, seat = field2 };
                return true;
            }

            return false;
        }
    }
}
