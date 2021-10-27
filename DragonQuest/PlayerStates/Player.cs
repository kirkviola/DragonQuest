using DragonQuest.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest
{
    public class Player
    {
        public string Name { get; set; }
        public int Luck { get; set; }
        public int Attack { get; set; }
        public int HealthPoints { get; set; }
        public List<Item> Inventory { get; set; }
        public int GemCount { get; set; }

        public Player () 
        {
            GetName();
            var build = GetBuild();
            var rand = new Random();
            // Invalid numbers are handled in the GetBuild method
            if(build == 1)
            {
                this.Luck = rand.Next(11, 20);
                this.Attack = rand.Next(5, 12);
                this.HealthPoints = rand.Next(40, 46);
            }
            else if(build == 2)
            {
                this.Luck = rand.Next(5, 12);
                this.Attack = rand.Next(16, 24);
                this.HealthPoints = rand.Next(30, 36);
            }
            else
            {
                this.Luck = rand.Next(8, 15);
                this.Attack = rand.Next(8, 15);
                this.HealthPoints = rand.Next(50, 56);
            }

            this.Inventory = new List<Item>();
            
        }

        public void GetName()
        {
            Console.Write("Enter your name, adventurer: ");
            this.Name = Console.ReadLine();
            
        }
        public int GetBuild()
        {
            Console.WriteLine("Would you like 1.) an adventure of great luck, 2.) an adventure " +
                            "of great strength, or 3.) an adventure of great stamina? ");
            Console.Write("Please enter 1, 2, or 3: ");
            var build = Convert.ToInt32(Console.ReadLine());
            if(build != 1 && build != 2 && build != 3)
            {
                Console.WriteLine("What was that? Please try again.");
                GetBuild();
            }
            return build;
        }

        // Update this method as items are added to the game.
        public void Status()
        {
            Console.Write("Your inventory contains: ");
         
            var PotionCounter = 0;
            var TonicCounter = 0;

            foreach(var item in this.Inventory)
            {
                if(item.GetType() == typeof(Potion))
                {
                    PotionCounter += 1;
                }
                if(item.GetType() == typeof(Tonic))
                {
                    TonicCounter += 1;
                }

        
            }
            Console.Write($"{PotionCounter} potions, and {TonicCounter} tonics, and {GemCount} gems.");
            Console.WriteLine($"Your current stats are {HealthPoints} healthpoints, {Luck} luck, and " +
                                  $"{Attack} attack.");
        }

        public bool IsDead()
        {
            if (HealthPoints <= 0)
                return true;

            return false;
        }

    }
}
