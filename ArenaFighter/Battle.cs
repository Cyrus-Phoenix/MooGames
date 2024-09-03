using ArenaFighter;

namespace ArenaFighter
{
    class Battle
    {
        public Battle(ref Character player)
        {
            Player = player;
            Opponent = new Character(CharacterType.Opponent);
            BattleLog = new List<Round>();
        }
        public Character Player { get; internal set; }
        public Character Opponent { get; internal set; }
        public List<Round> BattleLog { get; internal set; }

        internal void StartBattle()
        {
            Console.WriteLine("\nBattle between: ");
            Player.ShowInfo();
            Opponent.ShowInfo();

            while (Player.Health > 0 && Opponent.Health > 0)
            {
                this.StartRound();
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            Game.History.Add(this);
        }

        private void StartRound()
        {
            Round round = new Round();
            round.RollRound();
            BattleLog.Add(round);
            round.RoundResults(this.Player, this.Opponent);
            if (round.PlayerRoll < round.OpponentRoll)
                Player.Health += round.PlayerRoll - round.OpponentRoll;
            else
                Opponent.Health -= round.PlayerRoll - round.OpponentRoll;

            Player.ShowInfo();
            Opponent.ShowInfo();
        }
    }
}