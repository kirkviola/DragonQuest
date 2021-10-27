using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest
{
    class Spider : Monster
    {
        public Spider()
        {
            this.Name = "Spider";
            this.Strength = 5;
            this.HealthPoints = 20;
            this.Item = new Potion();
        }
    }
}
