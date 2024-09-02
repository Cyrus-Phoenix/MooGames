using Games.Data.Interfaces;
using MooGame.Classes;
using MooGames.Menu.Classes.Common;
using MooGames.Menu.Interfaces;

namespace MooGames.Menu.Classes;

public class MenuHandler
{
    private readonly IUserInterface _userInterface;
    private readonly IHighscoreHandler _highscoreHandler;
    public MenuHandler(IUserInterface userInterface, IHighscoreHandler highscoreHandler)
    {
        _userInterface = userInterface;
        _highscoreHandler = highscoreHandler;
    }

    public string GetUserChoice()
    {
        _userInterface.Write(Messages.Menu);
        _userInterface.Write(Messages.MenuChoiceMessage);
        return _userInterface.Read();
    }

    public void RunMenuAction(string userInput)
    {
        var mooGame = new MooGame(_userInterface, _highscoreHandler);
        var highscore = new Highscore(_userInterface, _highscoreHandler);

        userInput = userInput.ToUpper();

        if (userInput == Messages.MenuChoice1)
        {
            mooGame.RunMooGame();
        }
        else if (userInput == Messages.MenuChoice2)
        {
            _userInterface.Write(Messages.GameNotReleaseYet);
        }
        else if (userInput == Messages.MenuChoice3)
        {
            highscore.ShowHighscore();
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
