using DragonQuest.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest
{
    class Dungeon
    {
        public Room[,] Dimensions { get; set; }
        public int Layout { get; set; }
        public List<string> DungeonTexts { get; set; }

        /* GUIDE TO DUNGEON TEXTS
         * DungeonTexts[0] is the welcome text
         * DungeonTexts[1] is moving through a doorway
         * DungeonTexts[2] is encountering a monster
         * DungeonTexts[3] is finding a chest
         * DungeonTexts[4] is the Dragon ambush
         * DungeonTexts[5] is a victory message
         * DungeonTexts[6] is a loss message
         */

        public Dungeon()
        {
            RoomTexts();
            this.Dimensions = new Room[5, 5];
            
            Random rand = new Random();

            // this.Layout = rand.Next(1, 4); -- To be addressed for procedural generation in future releases

            
            RoomInitializer();
            MonsterOrChest();
            GemAlg();
            Console.WriteLine(DungeonTexts[0]);
        }

        private void GemAlg()
        {
            Random rand = new Random();
            var xCord = rand.Next(1, 5);
            var yCord = rand.Next(1, 5);

            this.Dimensions[xCord, yCord].Gem = true;
            var x2Cord = xCord switch
            {
                1 => 3,
                2 => 4,
                3 => 1,
                4 => 2,
                _ => 1
            };
            var y2Cord = yCord switch
            {
                1 => 2,
                2 => 3,
                3 => 4,
                4 => 1,
                _ => 2
            };

            this.Dimensions[x2Cord, y2Cord].Gem = true;

            var y3Cord = y2Cord switch
            {
                1 => 4,
                2 => 1,
                3 => 2,
                4 => 3,
                _ => 3
            };

            this.Dimensions[x2Cord, y3Cord].Gem = true;
        }

        // Update this method as new monsters are added to the game
        private void MonsterOrChest()
        {
            var rand = new Random();
            foreach(var room in this.Dimensions)
            {
                var num = rand.Next(0, 2);
                if(num == 0)
                {
                    room.Chest = new Chest();
                }
                else
                {
                    var num2 = rand.Next(0, 2);
                    if (num2 == 0)
                        room.Monster = new Spider();
                    else
                        room.Monster = new Goblin();
                }
            }
        }

        private void RoomInitializer()
        {
            this.Dimensions[0, 0] = new Room(false, true, true, false);
            this.Dimensions[1, 0] = new Room(true, true, false, false);
            this.Dimensions[2, 0] = new Room(true, false, true, false);
            this.Dimensions[3, 0] = new Room(false, true, true, false);
            this.Dimensions[4, 0] = new Room(true, false, true, false);
            this.Dimensions[0, 1] = new Room(false, true, false, true);
            this.Dimensions[1, 1] = new Room(true, false, true, false);
            this.Dimensions[2, 1] = new Room(false, true, false, true);
            this.Dimensions[3, 1] = new Room(true, true, false, true);
            this.Dimensions[4, 1] = new Room(true, false, true, true);
            this.Dimensions[0, 2] = new Room(false, true, true, false);
            this.Dimensions[1, 2] = new Room(true, true, true, true);
            this.Dimensions[2, 2] = new Room(true, false, false, false);
            this.Dimensions[3, 2] = new Room(false, true, false, false);
            this.Dimensions[4, 2] = new Room(true, false, true, true);
            this.Dimensions[0, 3] = new Room(false, true, true, true);
            this.Dimensions[1, 3] = new Room(true, false, false, true);
            this.Dimensions[2, 3] = new Room(false, true, true, false);
            this.Dimensions[3, 3] = new Room(true, false, true, false);
            this.Dimensions[4, 3] = new Room(false, false, true, true);
            this.Dimensions[0, 4] = new Room(false, true, false, true);
            this.Dimensions[1, 4] = new Room(true, true, false, false);
            this.Dimensions[2, 4] = new Room(true, false, false, true);
            this.Dimensions[3, 4] = new Room(false, false, false, true);
            this.Dimensions[4, 4] = new Room(false, false, false, true);

        }

        private void RoomTexts()
        {
            this.DungeonTexts = new List<string>() { "You awaken in the darkness with nothing but you wits, " +
                               "your trusty sword and shield, and your own luck, however much or little " +
                               "that may be. To escape, find three magical gems hidden within the dungeon " +
                               "and use their power to transport yourself back to the Kingdom of Langorr.",
                               "You step through the door and into the room.",
                               "You encounter a monster!", "There is a chest in the room.", 
                               "You have obtained all of the gems -- the Dragon attacks!!!",
                               "Game Over -- you are the winner and have escaped the dungeon! The Dragon will" +
                               "not trouble anyone ever again.",
                               "Game Over -- you have been slain!"
                                };
        }

    }
}
