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

        

        public override void MoveBackward()
        {
            Player.Coordinate.Y -= 1;
        }

        public override void UseItem()
        {
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
            Console.WriteLine($"Which item would you like to use? You currently have: {PotionCounter} potions" +
                                    $" and {TonicCounter} tonics");
            var inventoryItem = Console.ReadLine().ToLower();
            if(inventoryItem == "potion")
            {
                Potion UsedPotion;
                foreach(var item in Player.Inventory)
                {
                    var potion = typeof(Potion);
                    if (item.GetType() == potion)
                    {
                        UsedPotion = (Potion)item;
                        Player.Inventory.Remove(item);
                        break;
                    }
                }
                if(Player.HealthPoints + UsedPotion.Value > Player.MaxHealth)
                {

                }
            }
        }
    }
}