using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest
{
    public class Room
    {
        public Chest Chest { get; set; }
        public Monster Monster { get; set; }
        public bool Gem { get; set; } = false;
        public List<int> Doors { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Forward { get; set; }
        public bool Backward { get; set; }


        public Room() { }

        public Room(bool left, bool right, bool forward, bool backward)
        {
            this.Left = left;
            this.Right = right;
            this.Forward = forward;
            this.Backward = backward;
        }

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
