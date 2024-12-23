using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tg_bot.dtos;
using static System.Collections.Specialized.BitVector32;

namespace tg_bot.state
{
    public class UserState
    {
        public string current_state { get; set; } = "default";
        public Stack<string> state_history { get; private set; } = new();
        public int CurrentSessionPage { get; set; } = 0; // конкретная страница фильмов
        public List<AvailableSessionDto> CachedSessions { get; set; } = new List<AvailableSessionDto>();

        public void SetState(string newState)
        {
            if (!string.IsNullOrEmpty(current_state))
            {
                state_history.Push(current_state);
            }
            current_state = newState;
        }

        public string GoBack()
        {
            if (state_history.Count > 0)
            {
                current_state = state_history.Pop();
            }
            return current_state;
        }
    }
}
