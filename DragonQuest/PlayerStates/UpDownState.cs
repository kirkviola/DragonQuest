using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest.PlayerStates
{
    public class UpDownState : State
    {
        public UpDownState (Player player)
        {
            this.Player = player;
        }

        public override void Battle()
        {
            throw new NotImplementedException();
        }

        public override void WhichWay()
        {
            throw new NotImplementedException();
        }
    }
}
