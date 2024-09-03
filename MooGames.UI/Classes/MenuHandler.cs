using Games.Data.Interfaces;
using Games.Classes;
using Games.Common.Interfaces;

namespace Games.Common.Classes;

public class MenuHandler
{
    private readonly IUserInterface _userInterface;
    private readonly IHighscoreHandler _highscoreHandler;
    private readonly MooGame _mooGame;
    private readonly Highscore _highscore;
    private readonly Dictionary<string, Action> _menuActions;

    public MenuHandler( IUserInterface userInterface, 
                        IHighscoreHandler highscoreHandler,
                        MooGame mooGame,
                        Highscore highscore)
    {
        _userInterface = userInterface ?? throw new ArgumentNullException(nameof(userInterface));
        _highscoreHandler = highscoreHandler ?? throw new ArgumentNullException(nameof(highscoreHandler));
        _mooGame = mooGame ?? throw new ArgumentNullException(nameof(mooGame));
        _highscore = highscore ?? throw new ArgumentNullException(nameof(highscore));


        _menuActions = new Dictionary<string, Action>
        {
            {Messages.MenuChoice1, RunMooGame },
            {Messages.MenuChoice2, ShowGameRules },
            {Messages.MenuChoice3, ShowHighscore },
            {Messages.MenuChoice4, ShowGameNotReleasedMessage },
            {Messages.QuitApplication, QuitApplication }
        };
    }

    public string GetUserChoice()
    {
        _userInterface.Write(Messages.Menu);
        _userInterface.Write(Messages.MenuChoiceMessage);
        return _userInterface.Read();
    }

    public void RunMenuAction(string userInput)
    {
       
        userInput = userInput.ToUpper();

        if (_menuActions.TryGetValue(userInput, out var action))
        {
            action();
        }
        else
        {
            _userInterface.Write(Messages.InvalidChoiceMessage);
        }

    }

    private void RunMooGame()
    {
        Console.Clear();
        _mooGame.RunMooGame();
    }

    private void ShowGameRules()
    {
        _userInterface.Write(Messages.GameRules);
    }

    private void ShowHighscore()
    {
        _highscore.ShowHighscore();
    }

    private void ShowGameNotReleasedMessage()
    {
        _userInterface.Write(Messages.GameNotReleaseYet);
    }

    private void QuitApplication()
    {
        _userInterface.Write(Messages.ThankYouForPlayingMessage);
    }


}
