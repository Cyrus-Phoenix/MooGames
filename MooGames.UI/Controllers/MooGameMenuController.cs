using MooGame.Interfaces;
using MooGames.Menu;
using MooGames.Menu.Classes.Common;
using MooGames.Menu.Interfaces;
using MooGames.Menu.Classes;
using Games.Data.Interfaces;


namespace MooGames.Menu.Controller
{
    public class MooGameMenuController : IMenuController
    {
        private readonly IUserInterface _userInterface;
        private readonly IHighscoreHandler _highscoreHandler;

        public MooGameMenuController(IUserInterface userInterface, IHighscoreHandler highscoreHandler)
        {
            _userInterface = userInterface;
            _highscoreHandler = highscoreHandler;
        }

        public void RunMenu()
        {
            var menuHandler = new MenuHandler(_userInterface, _highscoreHandler);
            bool menuIsActive = true;

            while (menuIsActive)
            {
                string userInput = menuHandler.GetUserChoice();
                menuHandler.RunMenuAction(userInput);
                menuIsActive = userInput.ToUpper() != Messages.QuitApplication;
            }
        }
    }
}
