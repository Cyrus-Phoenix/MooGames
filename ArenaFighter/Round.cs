

namespace ArenaFighter
{
    class Round
    {
        public int PlayerRoll { get; set; }
        public int OpponentRoll { get; set; }

        internal void RollRound()
        {
            PlayerRoll = Dice.Roll();
            OpponentRoll = Dice.Roll();
        }

        internal void RoundResults(Character player, Character opponent)
        {
            Console.WriteLine($"\n{player.Name} rolled: {PlayerRoll}");
            Console.WriteLine($"{opponent.Name} rolled: {OpponentRoll}");
        }
    }
}