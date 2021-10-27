using DragonQuest.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest
{
    public class Potion : Item
    {
        public Potion()
        {
            var Rand = new Random();
            this.Name = "Potion";
            this.Description = "Potions restore a portion of your health points.";
            this.Value = Rand.Next(8, 16);
        }
    }
}
