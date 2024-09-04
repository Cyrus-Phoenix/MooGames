using Games.Common.Interfaces;
using Games.Common.Classes;


namespace Games.Menu.Classes;

public class MenuHandler
{
    private readonly IUserInterface _userInterface;
    private readonly IGame _mooGame = new MooGame.GameRunner();
    private readonly IGame _arenaGame = new ArenaFighter.GameRunner();
    private readonly Dictionary<string, Action> _menuActions;


    public MenuHandler(IUserInterface userInterface, IGame mooGame, IGame arenaGame)
    {
        _userInterface = userInterface ?? throw new ArgumentNullException(nameof(userInterface));
        _mooGame = mooGame ?? throw new ArgumentNullException(nameof(mooGame));
        _arenaGame = arenaGame ?? throw new ArgumentNullException(nameof(arenaGame));

        _menuActions = new Dictionary<string, Action>
            {
                {Messages.MenuChoice1, RunMooGame},
                {Messages.MenuChoice2, RunArenaGame },
                {Messages.MenuChoice3, ShowGameNotReleasedMessage},
                {Messages.QuitApplication, QuitApplication }
            };
    }

    public string GetUserChoice()
    {
        _userInterface.Clear();
        _userInterface.Write(Messages.GamesWelcomeMessage);
        _userInterface.Write(Messages.GamesMenuOptions);
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
        _userInterface.Clear();
        _mooGame.RunGame();
    }

    private void RunArenaGame() 
    {
        _userInterface.Clear();
        _arenaGame.RunGame();
    }

    private void ShowGameNotReleasedMessage()
    {
        _userInterface.Clear();
        _userInterface.Write(Messages.GameNotReleaseYet);
        _userInterface.Write(Messages.PressEnterToContinueMessage);
        _userInterface.Read();
    }

    private void QuitApplication()
    {
        _userInterface.Write(Messages.ThankYouForPlayingMessage);
    }

}
