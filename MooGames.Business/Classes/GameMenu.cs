using Games.Common.Classes;
using Games.Common.Interfaces;
using Games.Data;
using Games.Data.Interfaces;

namespace MooGame.Classes;

public class GameMenu
{

   private readonly IUserInterface _userInterface;
   private readonly IHighscoreHandler _highscoreHandler;
   private readonly Dictionary<string, Action> _mooMenuActions;

    public GameMenu(IUserInterface userInterface, IHighscoreHandler highscoreHandler)
    {
        _userInterface = userInterface ?? throw new ArgumentNullException(nameof(userInterface)); ;
        _highscoreHandler = new HighScoreHandler();

        _mooMenuActions = new Dictionary<string, Action>
        {
            {Messages.MenuChoice1, RunMooGame },
            {Messages.MenuChoice2, ShowGameRules },
            {Messages.MenuChoice3, ShowHighscore },
            {Messages.QuitApplication, QuitApplication }
        };
    }


    public void RunMenuAction()
    {
        bool menuIsActive = true;
        while (menuIsActive)
        {
            _userInterface.Write(Messages.MooGameWelcomeMessage);
            _userInterface.Write(Messages.MooGameMenuOptions);
            string userInput = _userInterface.Read().ToUpper();

            if (_mooMenuActions.TryGetValue(userInput, out var action))
            {
                action();
            }
            else
            {
                _userInterface.Write(Messages.InvalidChoiceMessage);
            }
            menuIsActive = userInput != Messages.QuitApplication;
        }
    }


    private void RunMooGame()
    {
        TheMooGame _mooGame = new TheMooGame(_userInterface);
        _userInterface.Clear();
        _mooGame.RunGame();
    }

    
    private void ShowGameRules()
    {
        _userInterface.Write(Messages.MooGameRules);
    }
    private void ShowHighscore()
    {
       Highscore _highscore = new Highscore(_userInterface, _highscoreHandler);
        _userInterface.Clear();
        _highscore.ShowHighscore();
    }
    private void QuitApplication()
    {
        _userInterface.Write(Messages.ThankYouForPlayingMessage);
    }
}
