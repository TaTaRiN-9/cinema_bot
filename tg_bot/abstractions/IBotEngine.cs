using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tg_bot.abstractions
{
    public interface IBotEngine
    {
        Task ListenForMessagesAsync();
    }
}
