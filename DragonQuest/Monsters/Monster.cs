using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest
{
    public abstract class Monster
    {
        public string Name { get; set; }
        public int Attack { get; set; }
        public int HealthPoints { get; set; }
        public Item Item { get; set; }

        public Monster() { }


        public abstract List<Item> DropLoot();
        

    }
}
