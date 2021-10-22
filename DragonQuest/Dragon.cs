using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest
{
    class Dragon : Monster
    {
        public Dragon()
        {
            this.Name = "Dragon";
            this.Strength = 12;
            this.HealthPoints = 100;
        }
    }
}
