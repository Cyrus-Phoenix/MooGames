using Games.Common.Classes;
using Games.Common.Interfaces;

namespace ArenaFighter;

internal class GameMenu
{
    private readonly IUserInterface _userInterface;
    private readonly Dictionary<string, Action> _mooMenuActions;

    public GameMenu(IUserInterface userInterface)
    {
        _userInterface = userInterface ?? throw new ArgumentNullException(nameof(userInterface)); ;

        _mooMenuActions = new Dictionary<string, Action>
        {
            {Messages.MenuChoice1, RunGame },
            {Messages.MenuChoice2, ShowGameRules },
            {Messages.QuitApplication, ExitApplication }
        };
    }


    public void RunMenu()
    {
        _userInterface.Write(Messages.ArenaFighterWelcomeMessage);
        bool menuIsActive = true;
        while (menuIsActive)
        {
           
            _userInterface.Write(Messages.ArenaMenuOptions);
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

    private void RunGame()
    {
        Game game = new Game();
        game.Start();
    }

    private void ShowGameRules() 
    { 
        _userInterface.Write(Messages.ArenaFighterRules);
    }
    private void ExitApplication() 
    {
        _userInterface.Write(Messages.ThankYouForPlayingMessage);
    }
}
