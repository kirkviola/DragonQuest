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
            this.Potions = new List<Potion>();
        }

        public override void DropLoot()
        {
            var rand = new Random();
            var counter = rand.Next(1, 3);
            for(var i = 1; i <= counter; i++)
            {
                this.Potions.Add(new Potion());
            }
            LootContents(this.Potions);

        }
    }
}
