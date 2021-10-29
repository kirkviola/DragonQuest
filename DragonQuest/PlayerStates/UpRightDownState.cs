using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest.PlayerStates
{
    public class UpRightDownState : State
    {
        public UpRightDownState (Player player)
        {
            this.Player = player;
        }


        public override void WhichWay()
        {
            IsChest();
            Console.WriteLine("You can currently go BACKWARD, FORWARD, or RIGHT. Type 'backward'" +
                 " to go back, 'forward' to go forward, 'right' to go right, 'status' " +
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
            else if (command == "right")
            {
                MoveRight();
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
