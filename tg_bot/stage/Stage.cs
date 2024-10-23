using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tg_bot.helpers;

namespace tg_bot.stage
{
    public class Stage
    {
        public static readonly Stage NOT_AUTHORIZED = 
            new Stage("Тебя приветствует бот кинотеатра \"Смотрилка\"!" + EmojiHelpers.GREETING);

        private readonly string _stage;

        public Stage(string stage)
        {
            _stage = stage;
        }
    }
}
