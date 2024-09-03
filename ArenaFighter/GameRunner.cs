using Games.Common.Interfaces;

namespace ArenaFighter
{
    public class GameRunner : IGame
    {
        public void RunGame()
        {
           Game game = new Game();
            game.Start();
        }
      
    }
}
