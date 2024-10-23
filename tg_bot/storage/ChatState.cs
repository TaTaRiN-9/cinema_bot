using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tg_bot.stage;

namespace tg_bot.storage
{
    internal class ChatState
    {
        private long chatId;

        private string phone;

        private DateTime startDate;

        private DateTime endDate;

        private Stage currentStage;

    }
}
