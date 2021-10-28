using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest
{
    public class Dragon : Monster
    {
        public Dragon()
        {
            this.Name = "Dragon";
            this.Strength = 15;
            this.HealthPoints = 100;
        }
    }
}
