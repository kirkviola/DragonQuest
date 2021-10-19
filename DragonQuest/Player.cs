using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest
{
    class Player
    {
        public string Name { get; set; }
        public int Luck { get; set; }
        public int Attack { get; set; }
        public int HealthPoints { get; set; }
        public List<Item> Inventory { get; set; }
        public List<Gem> Gems { get; set; }

        public Player (string name, int build) 
        {
            this.Name = name;
            var rand = new Random();
            //Invalid Random numbers will be handled in the main method
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


    }
}
