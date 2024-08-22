using MooGames.Menu.Classes.Common;
using MooGames.Menu.Interfaces;
using MooGames.Menu;

namespace MooGames.Menu.Classes;

public class MenuHandler
{
    private readonly IUserInterface _userInterface;

    public MenuHandler(IUserInterface userInterface)
    {
        _userInterface = userInterface;
    }

    public string GetUserChoice()
    {
        _userInterface.Write(Messages.Menu);
        _userInterface.Write(Messages.MenuChoiceMessage);
        return _userInterface.Read();
    }

    public void RunMenuAction(string userInput)
    {
        var mooGame = new Game(_userInterface);
        userInput = userInput.ToUpper();

        if (userInput == Messages.MenuChoice1)
        {
            mooGame.RunMooGame();
        }else if (userInput == Messages.MenuChoice2)
        {
            _userInterface.Write(Messages.GameNotReleaseYet);
        }
        else if (userInput == Messages.MenuChoice3)
        {
            mooGame.ShowTopList();
        }
        else if (userInput == Messages.QuitApplication)
        {
            _userInterface.Write(Messages.ThankYouForPlayingMessage);
        }
        else 
        {
            _userInterface.Write(Messages.InvalidChoiceMessage);
        }
    }
}
