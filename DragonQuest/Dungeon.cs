using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest
{
    class Dungeon
    {
        public Room[,] Dimensions { get; set; }

        public Dungeon()
        {
            this.Dimensions = new Room[4,4];
        }
    }
}
