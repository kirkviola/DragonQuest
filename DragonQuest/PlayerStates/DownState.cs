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
        public DownState() { }

        public override void WhichWay()
        {
            Console.WriteLine("You can currently go BACKWARD. Type 'backward' to go back, 'status' " +
                                            "to see your current status, or 'use' to use an item");

            var command = Console.ReadLine().ToLower();

            if(command == "backward")
            {
                MoveBackward();
            }

        }

        public override void Status()
        {
            Console.Write("Your inventory contains: ");

            var PotionCounter = 0;
            var TonicCounter = 0;

            foreach (var item in Player.Inventory)
            {
                if (item.GetType() == typeof(Potion))
                {
                    PotionCounter += 1;
                }
                if (item.GetType() == typeof(Tonic))
                {
                    TonicCounter += 1;
                }


            }
            Console.Write($"{PotionCounter} potions, and {TonicCounter} tonics, and {Player.GemCount} gems.");
            Console.WriteLine($"Your current stats are {Player.HealthPoints} healthpoints, {Player.Luck} luck, and " +
                                  $"{Player.Attack} attack.");
        }

        public override void MoveBackward()
        {
            Player.Coordinate.Y -= 1;
        }

        public override void UseItem()
        {
            
            Console.WriteLine("Which item would you like to use? ");
        }
    }
}
