using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest.PlayerStates
{
    public class BattleState : State
    {


        public BattleState(Player player, Monster monster) {
            this.Player = player;
            this.Monster = monster;
        }

        public override void Battle()
        {
            
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
                    Player.IsDead = true;
                    break;
                }
                if(Monster.HealthPoints <= 0)
                {
                    // Fix this, make sure the player obtains the items.
                    Console.WriteLine($"With a devastating blow, the {Monster.Name} was defeated!");
                    this.Monster.DropLoot();
                    if (Monster.Potions != null)
                        foreach (var potion in this.Monster.Potions)
                            Player.Potions.Add(potion);

                    if (Monster.Tonics != null)
                        foreach (var tonic in this.Monster.Tonics)
                            Player.Tonics.Add(tonic);

                    Player.Dungeon.Dimensions[Player.X, Player.Y].Monster = null;
                    break;
                }
            }
                Player.StateSelector();
        }


        public override void WhichWay()
        {
            throw new NotImplementedException();
        }

    }
}
