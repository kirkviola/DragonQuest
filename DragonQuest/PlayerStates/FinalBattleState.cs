using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest.PlayerStates
{
    public class FinalBattleState : State
    {
        public FinalBattleState(Player player)
        {
            this.Player = player;
            this.Monster = new Dragon();
        }

        public override void Battle()
        {
            Console.WriteLine("You have begun your final conflict with the dragon to escape the dungeon!");
            Console.WriteLine("Prepare yourself for battle!");
            Console.WriteLine("Press < Enter > to attack, < Spacebar > to use one of your items");
            while (this.Player.HealthPoints > 0 && this.Monster.HealthPoints > 0)
            {
                Console.WriteLine($"Current health -- {Player.Name}: {Player.HealthPoints} | {Monster.Name}: {Monster.HealthPoints}");
                var key = Console.ReadKey().Key;
                var pDamage = 0;
                var mDamage = 0;
                var rand = new Random();
                
                if (key == ConsoleKey.Spacebar)
                {
                    UseItem();
                    continue;
                }
                else if (key != ConsoleKey.Enter)
                {
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
                    Player.IsDead = true;
                    break;
                }
                if (Monster.HealthPoints <= 0)
                {
                    Console.WriteLine($"With one final thrust from {Player.Name}'s sword, the {Monster.Name} was defeated!");
                    Monster = null;
                    Player.DragonIsDead = true;
                    break;
                }

            }
        }

        public override void WhichWay()
        {
            throw new NotImplementedException();
        }
    }
}
