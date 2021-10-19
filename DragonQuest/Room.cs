using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest
{
    class Room
    {
        public Chest Chest { get; set; }
        public Monster Monster { get; set; }
        public Gem Gem { get; set; }

        public Room(int init) {

            if (init == 1)
            {

                this.Gem = new Gem();
                // Add initializer later
                this.Monster = new Monster();
            }
            else if (init == 2)
            {
                // Add initializer later
                this.Monster = new Monster();
            }
            else
                this.Chest = new Chest();
        }
    }
}
