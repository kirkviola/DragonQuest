using DragonQuest.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest
{
    public class Chest
    {
        public List<Item> Contents { get; set; }

        public Chest() { }

        public List<Item> Open(int roll)
        {
            if(roll <= 5)
            {
                Contents.Add(new Potion());
            }
            else if(roll > 5 && roll <= 10)
            {
                Contents.Add(new Potion());
                Contents.Add(new Tonic());
            }
            else if(roll > 10 && roll <= 15)
            {
                for(var i = 0; i < 2; i++)
                    Contents.Add(new Potion());
;
                Contents.Add(new Tonic());
            }
            else if(roll > 15 && roll <= 20)
            {
                for(var i = 0; i < 2; i++)
                    Contents.Add(new Potion());
                for (var i = 0; i < 2; i++)
                    Contents.Add(new Tonic());
            }
            else
            {
                for( var i = 0; i < 3; i++)
                    Contents.Add(new Potion());
                
                for (var i = 0; i < 2; i++)
                    Contents.Add(new Tonic());
            }
            var Loot = new List<Item>();
            foreach (var item in Contents)
                Loot.Add(item);

            return Loot;
        }

    }
}
