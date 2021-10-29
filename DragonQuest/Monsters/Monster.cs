using DragonQuest.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest
{
    public abstract class Monster
    {
        public string Name { get; set; }
        public int Attack { get; set; }
        public int HealthPoints { get; set; }
        public Item Item { get; set; }

        public Monster() { }


        public abstract List<Item> DropLoot();

        public void LootContents(List<Item> loot)
        {
            
            Console.Write("You obtained ");

            var PotionCounter = 0;
            var TonicCounter = 0;

            foreach (var item in loot)
            {
                if (item.GetType() == typeof(Potion))
                {
                    PotionCounter += 1;
                }
                if (item.GetType() == typeof(Tonic))
                {
                    TonicCounter += 1;
                }
            }
            Console.WriteLine($"potions: {PotionCounter} | tonics: {TonicCounter}");
            
        }        
    }
}
