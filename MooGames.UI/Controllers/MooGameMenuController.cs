using MooGame.Interfaces;
using MooGames.MooGame;
using MooGames.MooGame.Classes.Common;
using MooGames.MooGame.Interfaces;
using MooGames.Menu.Classes;


namespace MooGames.MooGame.Controller
{
    public class MooGameMenuController : IMenuController
    {
        private readonly IUserInterface _userInterface;

        public MooGameMenuController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        public void RunMenu()
        {
            var menuHandler = new MenuHandler(_userInterface);
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
