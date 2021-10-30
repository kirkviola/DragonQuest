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
            var Potions = new List<Potion>();
            var Tonics = new List<Tonic>();
            if (roll <= 5)
            {
                Potions.Add(new Potion());
            }
            else if (roll > 5 && roll <= 10)
            {
                Potions.Add(new Potion());
                Tonics.Add(new Tonic());
            }
            else if (roll > 10 && roll <= 15)
            {
                for (var i = 0; i < 2; i++)
                    Potions.Add(new Potion());
                
                Tonics.Add(new Tonic());
            }
            else if (roll > 15 && roll <= 20)
            {
                for (var i = 0; i < 2; i++)
                    Potions.Add(new Potion());
                for (var i = 0; i < 2; i++)
                    Tonics.Add(new Tonic());
            }
            else
            {
                for (var i = 0; i < 3; i++)
                    Potions.Add(new Potion());

                for (var i = 0; i < 2; i++)
                    Tonics.Add(new Tonic());
            }
            InventoryStatus(Potions, Tonics);
            foreach (var potion in Potions)
                Player.Potions.Add(potion);

            foreach (var tonic in Tonics)
                Player.Tonics.Add(tonic);


                

            Player.Dungeon.Dimensions[Player.X, Player.Y].Chest = null;
        }

        // This needs a fix for there being 0 of an item in the inventory.
        public void UseItem()
        {
            if(Player.Potions.Count == 0 && Player.Tonics.Count == 0)
            {
                Console.WriteLine("Inventory empty!");
                return;
            }
            InventoryStatus();
            Console.WriteLine("Which item would you like to use, POTION or TONIC?");
            var item = Console.ReadLine().ToLower();
            if (item == "potion")
            {
                if(Player.Potions.Count == 0)
                {
                    Console.WriteLine("You are out of potions.");
                }
                else
                    UsePotion();
            }
            else if (item == "tonic")
            {
                if(Player.Tonics.Count == 0)
                {
                    Console.WriteLine("You are out of tonics.");
                }
                else
                    UseTonic();
            }
            else
            {
                Console.WriteLine("You do not have that item, please try again.");
                UseItem();
            }
                
        }
        public void UsePotion()
        {
            var PotionStrength = Player.Potions[0].Value;
            Player.Potions.RemoveAt(0);
            
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
                Player.Tonics.RemoveAt(0);
            }
            else if (tonic == "attack")
            {
                Player.Attack += 1;
                Console.WriteLine("Attack increased!");
                Player.Tonics.RemoveAt(0);
            }
            else if (tonic == "luck")
            {
                Player.Luck += 1;
                Console.WriteLine("Luck increased!");
                Player.Tonics.RemoveAt(0);
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
            Console.WriteLine($"Your current stats are: {Player.HealthPoints} healthpoints | {Player.Luck} luck | " +
                                  $"{Player.Attack} attack");
        }

        public void InventoryStatus()
        {
            Console.Write("Your inventory contains: ");

            
            Console.WriteLine($"potions: {Player.Potions.Count} | tonics: {Player.Tonics.Count} | gems: {Player.GemCount}");
        }

        public void InventoryStatus(List<Potion> potions, List<Tonic> tonics)
        {
            Console.Write("In the chest you find ");

            Console.WriteLine($"potions: {potions.Count}, Tonics: {tonics.Count}");
        }
    }
}
