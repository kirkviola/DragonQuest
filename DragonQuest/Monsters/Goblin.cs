using DragonQuest.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest.Monsters
{
    public class Goblin : Monster
    {
        public Goblin ()
        {
            this.Name = "Goblin";
            this.Attack = 10;
            this.HealthPoints = 30;
            this.Potions = new List<Potion>();
            this.Tonics = new List<Tonic>();
        }

        public override void DropLoot()
        {
            var rand = new Random();
            var counter = rand.Next(1, 4);
            for (var i = 1; i <= counter; i++)
            {
                Potions.Add(new Potion());
            }
            Tonics.Add(new Tonic());
            LootContents(this.Potions, this.Tonics);
        }
    }
}
