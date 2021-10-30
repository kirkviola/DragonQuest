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
        public List<Potion> Potions { get; set; }
        public List<Tonic> Tonics { get; set; }

        public Monster() { }


        public abstract void DropLoot();

        public void LootContents(List<Potion> potions, List<Tonic> tonics)
        {
            
            Console.Write("You obtained ");
            Console.WriteLine($"potions: {potions.Count} | tonics: {tonics.Count}");
            
        }    
        
        public void LootContents(List<Potion> potions) // For loot drops that are potions only
        {            
            Console.Write("You obtained ");
            Console.WriteLine($"potions: {potions.Count}");    
        }

        public void LootContents(List<Tonic> tonics) // For loot drops that are tonics only
        {
            Console.Write("You obtained ");
            Console.WriteLine($"tonics: {tonics.Count}");
        }
    }
}
