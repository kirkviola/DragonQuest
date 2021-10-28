using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest.PlayerStates
{
    public class BattleState : State
    {


        public BattleState() { }

        public override void Battle()
        {
            Monster = Player.Dungeon.Dimensions[Player.X, Player.Y].Monster;
            Console.WriteLine($"You encounter a {Monster.Name}. Press < Enter > to attack!");

            while (this.Player.HealthPoints > 0 && this.Monster.HealthPoints > 0)
            {
                Console.WriteLine($"Current health -- {Player.Name}: {Player.HealthPoints} | {Monster.Name}: {Monster.HealthPoints}");
                var key = Console.ReadKey().Key;
                var pDamage = 0;
                var mDamage = 0;
                var rand = new Random();
                if (key != ConsoleKey.Enter) {
                    Console.WriteLine("Invalid key, try again.");
                    continue;
                }
                pDamage = rand.Next(Player.Attack - 3, Player.Attack + 4);
                mDamage = rand.Next(Monster.Attack - 3, Monster.Attack + 3);

                Console.WriteLine($"{Player.Name} hit for {pDamage} damage, {Monster.Name} hit for {mDamage} damage.");
                Player.HealthPoints -= mDamage;
                Monster.HealthPoints -= pDamage;

                if (Player.HealthPoints <= 0)
                {
                    Console.WriteLine($"{Player.Name} lost the battle!");
                    break;
                }
                if(Monster.HealthPoints <= 0)
                {
                    Console.WriteLine($"With a devastating blow, the {Monster.Name} was defeated!");
                    Monster = null;
                    break;
                }
            }
        }

        public override void WhichWay()
        {
            throw new NotImplementedException();
        }


        public override List<Item> ChestOpen()
        {
            throw new NotImplementedException();
        }

        public override void UseItem()
        {
            throw new NotImplementedException();
        }


    }
}
