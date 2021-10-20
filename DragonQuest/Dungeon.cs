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
        public int Layout { get; set; }
        public string WelcomeTxt { get; set; }

        public Dungeon()
        { 
            this.Dimensions = new Room[4,4];
            Random rand = new Random();

            this.Layout = rand.Next(1, 4);

            foreach(var room in this.Dimensions)
            {
                room.RoomCreater(rand.Next(1, 3));
            }
            this.WelcomeTxt = "You awaken in the darkness with nothing but you wits, " +
                               "your trusty sword and shield, and your own luck, however much or little " +
                               "that may be. To escape, find three magical gems hidden within the dungeon " +
                               "and use their power to transport yourself back to the Kingdom of Langorr.";
            GemAlg();
        }

        private void GemAlg()
        {
            Random rand = new Random();
            var xCord = rand.Next(1, 5);
            var yCord = rand.Next(1, 5);

            this.Dimensions[xCord, yCord].Gem = true;
            var x2Cord = xCord switch
            {
                1 => 3,
                2 => 4,
                3 => 1,
                4 => 2,
                _ => 1
            };
            var y2Cord = yCord switch
            {
                1 => 2,
                2 => 3,
                3 => 4,
                4 => 1,
                _ => 2
            };

            this.Dimensions[x2Cord, y2Cord].Gem = true;

            var y3Cord = y2Cord switch
            {
                1 => 4,
                2 => 1,
                3 => 2,
                4 => 3,
                _ => 3
            };

            this.Dimensions[x2Cord, y3Cord].Gem = true;
        }


    }
}
