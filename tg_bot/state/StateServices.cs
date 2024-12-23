using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tg_bot.state
{
    public class StateServices
    {
        private readonly Dictionary<long, UserState> _userStates = new();

        public UserState GetUserState(long userId)
        {
            if (!_userStates.ContainsKey(userId))
            {
                _userStates[userId] = new UserState();
            }
            return _userStates[userId];
        }
    }
}
