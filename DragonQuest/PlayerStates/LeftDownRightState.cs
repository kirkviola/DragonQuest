﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest.PlayerStates
{
    public class LeftDownRightState : State
    {
        public LeftDownRightState(Player player)
        {
            this.Player = player;
        }


        public override void WhichWay()
        {
            IsChest();
            Console.WriteLine("You can currently go BACKWARD, LEFT, or RIGHT. Type 'backward'" +
                 " to go back, 'left' to go left, 'right' to go right, 'status' " +
                                            "to see your current status, or 'use' to use an item");

            var command = Console.ReadLine().ToLower();

            if (command == "backward")
            {
                MoveBackward();
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
