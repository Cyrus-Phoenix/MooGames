using Games.Common.Classes;
using Games.Common.Interfaces;
using Games.Data.Interfaces;
using MooGame.Classes;

namespace MooGame
{
    public class GameRunner : IGame
    {
        private readonly IHighscoreHandler highscoreHandler;
        IUserInterface userInterface = new ConsoleUserinterface();
        

       public void RunGame()
        {
           GameMenu gameMenu = new GameMenu(userInterface,highscoreHandler);
           gameMenu.RunMenuAction();
        }
    }
}
