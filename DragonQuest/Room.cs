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
        public bool Gem { get; set; } = false;

        public Room() { }

        public void RoomCreater(int num)
        {
            if(num == 1)
            {
                // Put initializers in here
                this.Chest = new Chest();
            }
            else
            {
                // Put initializers in
                this.Monster = new Monster();
            }
        }
    }
}
