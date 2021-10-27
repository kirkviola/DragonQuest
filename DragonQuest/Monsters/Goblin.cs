using DragonQuest.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest.Monsters
{
    class Goblin : Monster
    {
        public Goblin ()
        {
            this.Name = "Goblin";
            this.Strength = 10;
            this.Item = new Tonic();
            this.HealthPoints = 30;
        }
    }
}
