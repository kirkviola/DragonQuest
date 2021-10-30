using DragonQuest.Items;
using DragonQuest.PlayerStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest
{
    public class Player
    {
        private State state;

        public string Name { get; set; }
        public int Luck { get; set; }
        public int Attack { get; set; }
        public int HealthPoints { get; set; }
        public int MaxHealth { get; set; }
        public List<Potion> Potions { get; set; }
        public List<Tonic> Tonics { get; set; }
        public Dungeon Dungeon { get; set; }
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int GemCount { get; set; }
        public bool IsDead { get; set; } = false;
        public bool DragonIsDead { get; set; } = false;

        public Player (Dungeon dungeon) 
        {
            GetName();
            var build = GetBuild();
            var rand = new Random();
            // Invalid numbers are handled in the GetBuild method
            if(build == 1)
            {
                this.Luck = rand.Next(11, 20);
                this.Attack = rand.Next(5, 12);
                this.HealthPoints = rand.Next(40, 46);
            }
            else if(build == 2)
            {
                this.Luck = rand.Next(5, 12);
                this.Attack = rand.Next(16, 24);
                this.HealthPoints = rand.Next(30, 36);
            }
            else
            {
                this.Luck = rand.Next(8, 15);
                this.Attack = rand.Next(8, 15);
                this.HealthPoints = rand.Next(50, 56);
            }

            this.MaxHealth = this.HealthPoints;
            this.Potions = new List<Potion>();
            this.Tonics = new List<Tonic>();
            this.Dungeon = dungeon;
        }

        public void GetName()
        {
            Console.Write("Enter your name, adventurer: ");
            this.Name = Console.ReadLine();
            
        }
        public int GetBuild()
        {
            Console.WriteLine("Would you like 1.) an adventure of great luck, 2.) an adventure " +
                            "of great strength, or 3.) an adventure of great stamina? ");
            Console.Write("Please enter 1, 2, or 3: ");
            
            var build = 0;
            try
            {
            build = Convert.ToInt32(Console.ReadLine());

            } catch (System.FormatException)
            {
                Console.WriteLine("Please enter a valid number.");
                GetBuild();
            }

            if(build != 1 && build != 2 && build != 3)
            {
                Console.WriteLine("What was that? Please try again.");
                GetBuild();
            }
            return build;
        }


        public Room GetLocation(Dungeon dungeon)
        {
            return dungeon.Dimensions[X, Y];
        }

        public void StateSelector()
        {
            
            var room = GetLocation(this.Dungeon);
            GemChecker();
            if (room.Monster != null)
            {
                this.state = new BattleState(this, this.Dungeon.Dimensions[X, Y].Monster);
            } 
            else if(room.Backward && room.Forward && room.Left && room.Right)
            {
                this.state = new LeftRightUpDownState(this);
            }
            else if(room.Backward && room.Forward && room.Left && !room.Right)
            {
                this.state = new LeftUpDown(this);
            }
            else if(room.Backward && room.Forward && !room.Left && room.Right)
            {
                this.state = new UpRightDownState(this);
            }
            else if(room.Backward && !room.Forward && room.Left && room.Right)
            {
                this.state = new LeftDownRightState(this);
            }
            else if(!room.Backward && room.Forward && room.Left && room.Right)
            {
                this.state = new UpRightDownState(this);
            }
            else if(room.Backward && room.Forward && !room.Left && !room.Right)
            {
                this.state = new UpDownState(this);
            }
            else if(room.Backward && !room.Forward && room.Left && !room.Right)
            {
                this.state = new LeftDownState(this);
            }
            else if(!room.Backward && room.Forward && room.Left && !room.Right)
            {
                this.state = new LeftUpState(this);
            }
            else if(room.Backward && !room.Forward && !room.Left && room.Right)
            {
                this.state = new RightDownState(this);
            }
            else if(!room.Backward && room.Forward && !room.Left && room.Right)
            {
                this.state = new UpRightState(this);
            }
            else if(!room.Backward && !room.Forward && room.Left && room.Right)
            {
                this.state = new LeftRightState(this);
            }
            else if(!room.Backward && !room.Forward && !room.Left && room.Right)
            {
                this.state = new RightState(this);
            }
            else if(!room.Backward && !room.Forward && room.Left && !room.Right)
            {
                this.state = new LeftState(this);
            }
            else if(!room.Backward && room.Forward && !room.Left && !room.Right)
            {
                this.state = new UpState(this);
            }
            else if(room.Backward && !room.Forward && !room.Left && !room.Right)
            {
                this.state = new DownState(this);
            }

        }
        public void Play()
        {
            if(this.GemCount == 3)
            {
                Console.WriteLine("You have enough gems. Press < Enter > to battle the dragon. Any other key to continue exploring");
                var key = Console.ReadKey().Key;
                if(key == ConsoleKey.Enter)
                {
                    this.state = new FinalBattleState(this);
                    return;
                }
                    
            }
            if (this.IsDead)
                return;
            this.StateSelector();
            if(this.state.GetType() == typeof(BattleState))
            {
                this.state.Battle();
            }
            else
            {
                this.state.WhichWay();
            }
        }

        private void GemChecker()
        {
            if (this.Dungeon.Dimensions[X, Y].Gem)
            {
                this.GemCount += 1;
                this.Dungeon.Dimensions[X, Y].Gem = false;
                Console.WriteLine("You find one of the three gems in the room, and add it to your collection!");
            }
        }

    }
}
