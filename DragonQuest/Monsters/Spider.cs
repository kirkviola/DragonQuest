using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest
{
    public class Spider : Monster
    {
        public Spider()
        {
            this.Name = "Spider";
            this.Attack = 5;
            this.HealthPoints = 20;
            this.Item = new Potion();
        }

        public override List<Item> DropLoot()
        {
            var rand = new Random();
            var counter = rand.Next(1, 3);
            var loot = new List<Item>();
            for(var i = 1; i <= counter; i++)
            {
                loot.Add(new Potion());
            }
            return loot;
        }
    }
}
