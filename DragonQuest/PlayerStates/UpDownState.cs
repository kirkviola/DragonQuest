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

        public override void WhichWay()
        {
            IsChest();
            Console.WriteLine("You can currently go BACKWARD or FORWARD. Type 'backward'" +
                 " to go back, 'forward' to go forward, 'status' " +
                                            "to see your current status, or 'use' to use an item");

            var command = Console.ReadLine().ToLower();

            if (command == "backward")
            {
                MoveBackward();
            }
            else if (command == "forward")
            {
                MoveForward();
            }
            else if (command == "status")
            {
                Status();
            }
            else if (command == "use")
            {
                UseItem();
            }
            else
            {
                Console.WriteLine("You cannot go that way.");
                WhichWay();
            }
        }

        public override void Battle()
        {
            throw new NotImplementedException();
        }

    }
}
