using DragonQuest.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest.Monsters
{
    public class Goblin : Monster
    {
        public Goblin ()
        {
            this.Name = "Goblin";
            this.Attack = 10;
            this.Item = new Tonic();
            this.HealthPoints = 30;
        }

        public override List<Item> DropLoot()
        {
            var rand = new Random();
            var counter = rand.Next(1, 4);
            var loot = new List<Item>();
            for (var i = 1; i <= counter; i++)
            {
                loot.Add(new Potion());
            }
            loot.Add(new Tonic());
            LootContents(loot);
            return loot;
        }
    }
}
