using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest
{
    public class Monster
    {
        public string Name { get; set; }
        public int Attack { get; set; }
        public int HealthPoints { get; set; }
        public Item Item { get; set; }

        public Monster() { }


        public bool IsDead()
        {
            if (HealthPoints <= 0)
                return true;
            else
                return false;
        }
    }
}
