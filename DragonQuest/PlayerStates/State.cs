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
        protected Monster Monster { get; set; }

        public abstract void WhichWay();
        public abstract void Battle();
        
        public void IsChest()
        {
            var loot = new List<Item>();
            if (Player.Dungeon.Dimensions[Player.X, Player.Y].Chest != null)
            {
                Console.WriteLine("You come upon a chest and open it to reveal the loot inside.");
                Open();
            }
               
        }
        public void Open()
        {
            var roll = Player.Luck;
            var Contents = new List<Item>();
            if (roll <= 5)
            {
                Contents.Add(new Potion());
            }
            else if (roll > 5 && roll <= 10)
            {
                Contents.Add(new Potion());
                Contents.Add(new Tonic());
            }
            else if (roll > 10 && roll <= 15)
            {
                for (var i = 0; i < 2; i++)
                    Contents.Add(new Potion());
                
                Contents.Add(new Tonic());
            }
            else if (roll > 15 && roll <= 20)
            {
                for (var i = 0; i < 2; i++)
                    Contents.Add(new Potion());
                for (var i = 0; i < 2; i++)
                    Contents.Add(new Tonic());
            }
            else
            {
                for (var i = 0; i < 3; i++)
                    Contents.Add(new Potion());

                for (var i = 0; i < 2; i++)
                    Contents.Add(new Tonic());
            }
            InventoryStatus(Contents);
            foreach (var item in Contents)
                Player.Inventory.Add(item);
        }

        // This needs a fix for there being 0 of an item in the inventory.
        public void UseItem()
        {
            InventoryStatus();
            Console.WriteLine("Which item would you like to use, POTION or TONIC?");
            var item = Console.ReadLine().ToLower();
            if (item == "potion")
                UsePotion();
            else if (item == "tonic")
                UseTonic();
            else
            {
                Console.WriteLine("You do not have that item, please try again.");
                UseItem();
            }
                
        }
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
            InventoryStatus();
            Console.WriteLine($"Your current stats are {Player.HealthPoints} healthpoints, {Player.Luck} luck, and " +
                                  $"{Player.Attack} attack.");
        }

        public void InventoryStatus()
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
        }

        public void InventoryStatus(List<Item> loot)
        {
            Console.Write("In the chest you find: ");

            var PotionCounter = 0;
            var TonicCounter = 0;

            foreach (var item in loot)
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
            Console.Write($"{PotionCounter} potions, and {TonicCounter} tonics.");
        }
    }
}
