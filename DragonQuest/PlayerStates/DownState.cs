using DragonQuest.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest.PlayerStates
{
    class DownState : State
    {
        public DownState(Player player)    
        {
            this.Player = player;
        }

        public override void WhichWay()
        {
            IsChest();
            Console.WriteLine("You can currently go BACKWARD. Type 'backward' to go back, 'status' " +
                                            "to see your current status, or 'use' to use an item");

            var command = Console.ReadLine().ToLower();

            if(command == "backward")
            {
                MoveBackward();
            }
            else if(command == "status")
            {
                Status();
            }
            else if(command == "use")
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