using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest
{
    class Monster
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int HealthPoints { get; set; }
        public Random Roll { get; set; }
        public Item Item { get; set; }

        public Monster() { }

        public int Attack (int lower, int upper)
        {
            var damage = Roll.Next(lower, upper);
            return damage;
        }

        public bool IsDead()
        {
            if (HealthPoints <= 0)
                return true;
            else
                return false;
        }
    }
}
