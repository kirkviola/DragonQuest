using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest.PlayerStates
{
    public class LeftUpRightState : State
    {
        public LeftUpRightState(Player player)
        {
            this.Player = player;
        }

        public override void WhichWay()
        {
            IsChest();
            Console.WriteLine("You can currently go FORWARD, LEFT, or RIGHT. Type'" +
                 " 'forward' to go forward, 'left' to go left, 'right' to go right, 'status' " +
                                            "to see your current status, or 'use' to use an item");

            var command = Console.ReadLine().ToLower();


            if (command == "forward")
            {
                MoveForward();
            }
            else if (command == "left")
            {
                MoveLeft();
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
