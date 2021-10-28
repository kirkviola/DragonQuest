using DragonQuest.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest.PlayerStates
{
    public abstract class State
    {
        protected Player Player;
        protected Dungeon Dungeon { get; set; }
        protected Chest Chest { get; set; }
        protected Item Item { get; set; }
        protected Monster Monster { get; set; }

        public abstract void Battle();
        public abstract List<Item> ChestOpen();
        public abstract void UseItem();
        public void UsePotion()
        {
            var PotionStrength = 0;
            foreach (var item in Player.Inventory)
            {
                var potion = typeof(Potion);
                if (item.GetType() == potion)
                {
                    PotionStrength = item.Value;
                    Player.Inventory.Remove(item);
                    break;
                }
            }
            if (Player.HealthPoints + PotionStrength > Player.MaxHealth)
            {
                Player.HealthPoints = Player.MaxHealth;
                Console.WriteLine($"Your health is replenished! Current HP: {Player.HealthPoints}");
            }
            else
            {
                Player.HealthPoints += PotionStrength;
                Console.WriteLine($"Your health is replenished! Current HP: {Player.HealthPoints}");
            }
        }
        public void UseTonic()
        {
            Console.WriteLine("Would you like to improve your Health, Attack, or Luck by 1 point?");
            var tonic = Console.ReadLine().ToLower();

            if (tonic == "health")
            {
                Player.HealthPoints += 1;
                Player.MaxHealth += 1;
                Console.WriteLine("Max health increased!");
            }
            else if (tonic == "attack")
            {
                Player.Attack += 1;
                Console.WriteLine("Attack increased!");
            }
            else if (tonic == "luck")
            {
                Player.Luck += 1;
                Console.WriteLine("Luck increased!");
            }
            else
            {
                Console.WriteLine("Not an attribute; try again.");
                UseTonic();
            }
        }
        public abstract void WhichWay();
   
        public void MoveLeft()
        {
            Player.X -= 1;
        }
        public void MoveRight()
        {
            Player.X += 1;
        }
        public void MoveForward()
        {
            Player.Y += 1;
        }
        public void MoveBackward()
        {
            Player.Y -= 1;
        }
        public void Status()
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


    }
}
