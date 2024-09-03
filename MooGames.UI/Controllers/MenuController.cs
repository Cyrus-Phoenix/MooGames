using Games.Data.Interfaces;
using Games.Interfaces;
using Games.Common.Classes;
using Games.Common.Interfaces;
using MooGame;
using Games.Menu.Classes;



namespace  Games.Common.Controller;

public class MenuController : IMenuController
{
    private readonly IUserInterface _userInterface;
    private readonly IGame _mooGame;
    private readonly IGame _arenaGame;

    public MenuController(IUserInterface userInterface,IGame mooGame, IGame arenaGame)
    {
        _userInterface = userInterface;
        _mooGame = mooGame;
        _arenaGame = arenaGame;

    }
    public void RunMenu()
    {
        var menuHandler = new MenuHandler(_userInterface, _mooGame, _arenaGame);
        bool menuIsActive = true;

        while (menuIsActive)
        {
            string userInput = menuHandler.GetUserChoice();
            menuHandler.RunMenuAction(userInput);
            menuIsActive = userInput.ToUpper() != Messages.QuitApplication;
        }
    }
}
