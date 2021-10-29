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
            this.Attack = 15;
            this.HealthPoints = 100;
        }

        public override List<Item> DropLoot()
        {
            throw new NotImplementedException();
        }
    }
}
