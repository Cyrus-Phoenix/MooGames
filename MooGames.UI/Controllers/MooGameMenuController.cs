using MooGame.Interfaces;
using MooGames.Menu;
using MooGames.Menu.Classes.Common;
using MooGames.Menu.Interfaces;
using MooGames.Menu.Classes;


namespace MooGames.Menu.Controller
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
