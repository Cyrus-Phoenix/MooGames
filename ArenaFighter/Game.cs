using System;
using System.Collections.Generic;
using System.Linq;

namespace ArenaFighter
{
    class Game
    {
        public Game()
        {
            History = new List<Battle>();
        }
        Character Player;
        internal void Start()
        {
            Console.Write("Name your champion: ");
            var name = Console.ReadLine();
            var strength = Dice.RollStrength();
            var health = Dice.RollHealth();
            Player = new Character(CharacterType.Player, name);

            StartGame();
        }

        private void StartGame()
        {
            while (Player.Health > 0)
            {
                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Retire");
                var key = Console.ReadKey();
                if (key.KeyChar == '1')
                    CreateBattle();
                else if (key.KeyChar == '2')
                    break;
                Console.ReadKey();
            }
            Retire();
        }

        private void Retire()
        {
            Console.WriteLine($"\nCareer of {Player.Name}");
            History.ForEach(f =>
            {
                Console.WriteLine($"\nBattle against {f.Opponent.Name}");
                for (int i = 0; i < f.BattleLog.Count; ++i)
                {
                    Console.WriteLine($"Round {i + 1} against {f.Opponent.Name}");
                    Console.WriteLine($"{Player.Name}-{f.Opponent.Name} {f.BattleLog[i].PlayerRoll}-{f.BattleLog[i].OpponentRoll}");
                }
            });

            Console.WriteLine("Game over");
            Console.ReadKey();
        }

        private void CreateBattle()
        {
            Battle battle = new Battle(ref Player);
            battle.StartBattle();
        }
        public static List<Battle> History { get; internal set; }
    }
}