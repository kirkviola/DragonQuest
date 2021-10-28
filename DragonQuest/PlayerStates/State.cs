using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest.PlayerStates
{
    public abstract class State
    {
        protected Player Player;
        protected Dungeon Dungeon { get; set; }
        protected Chest Chest { get; set; }
        protected Item Item { get; set; }
        protected Monster Monster { get; set; }

        public abstract void Battle();
        public abstract List<Item> ChestOpen();
        public abstract void UseItem();
        public abstract void WhichWay();
        public abstract void MoveLeft();
        public abstract void MoveRight();
        public abstract void MoveForward();
        public abstract void MoveBackward();
        public abstract void Status();


    }
}
