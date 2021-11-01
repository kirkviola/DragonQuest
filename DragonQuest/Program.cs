using DragonQuest.PlayerStates;
using System;

namespace DragonQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            var dungeon = new Dungeon();
            var player = new Player(dungeon);



            while (!player.IsDead)
            {
                player.Play();
                if (player.DragonIsDead)
                    break;
            }

            if (player.DragonIsDead)
            {
                Console.WriteLine($"Congratulations {player.Name}, you have successfully escaped the dungeon " +
                    $"and returned to your home. Your people will sing of your triumph over the dragon for many " +
                    $"years to come!");
            }
            else
            {
                Console.WriteLine("Despite your best effors, you have been slain. Your corpse will rot on the floor of the " +
                    "dungeon for many years to come until nothing remains but a skeleton.");
            }
        }
    }
}
