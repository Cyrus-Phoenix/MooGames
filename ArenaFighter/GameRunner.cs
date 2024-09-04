using Games.Common.Classes;
using Games.Common.Interfaces;

namespace ArenaFighter
{
    public class GameRunner : IGame
    {
        IUserInterface userInterface = new ConsoleUserinterface();

        public void RunGame()
        {
           GameMenu gameMenu = new GameMenu(userInterface);
            gameMenu.RunMenu();
        }
      
    }
}
