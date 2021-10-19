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
            Random rand = new Random();

            for( var i = 0; i < 3; i++)
            {
                Dimensions[rand.Next(1, 5), rand.Next(1, 5)] = new Room(1);
            }
        }
    }
}
