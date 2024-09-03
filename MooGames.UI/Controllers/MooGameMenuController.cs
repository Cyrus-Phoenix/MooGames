using Games.Data.Interfaces;
using MooGame.Classes;
using MooGame.Interfaces;
using MooGames.Menu.Classes;
using MooGames.Menu.Classes.Common;
using MooGames.Menu.Interfaces;


namespace MooGames.Menu.Controller
{
    public class MooGameMenuController : IMenuController
    {
        private readonly IUserInterface _userInterface;
        private readonly IHighscoreHandler _highscoreHandler;
        private readonly MooGame _mooGame;
        private readonly Highscore _highscore;
       

        public MooGameMenuController(IUserInterface userInterface, IHighscoreHandler highscoreHandler)
        {
            _userInterface = userInterface;
            _highscoreHandler = highscoreHandler;

            _mooGame = new MooGame(_userInterface, _highscoreHandler);
            _highscore = new Highscore(_userInterface, _highscoreHandler);
        }

        public void RunMenu()
        {
            var menuHandler = new MenuHandler(_userInterface, _highscoreHandler, _mooGame, _highscore);
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
