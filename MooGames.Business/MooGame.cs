using Games.Data.Interfaces;
using MooGame.Classes;
using MooGames.Menu.Classes.Common;
using MooGames.Menu.Interfaces;

namespace MooGames.Menu;

public class MooGame
{
    private readonly IUserInterface _userInterface;
    private readonly IHighscoreHandler _highscoreHandler;
    private readonly Highscore _highscore;
    private readonly GameState _gameState;
    private readonly GamePlay _gamePlay;


    public MooGame(IUserInterface userInterface, IHighscoreHandler highscoreHandler)
    {
        _userInterface = userInterface ?? throw new ArgumentNullException(nameof(userInterface));
        _highscoreHandler = highscoreHandler ?? throw new ArgumentNullException(nameof(highscoreHandler));
        _highscore = new Highscore(userInterface, highscoreHandler);
        _gameState = new GameState();
        _gamePlay = new GamePlay(userInterface, _gameState);
    }


    /// TODO: Bug: The first number of guesses is not counted.
    public void RunMooGame()
    {


        _userInterface.Write(Messages.EnterNameMessage);
        string name = _userInterface.Read();

        // *** extracted method "RandomGameNumber" to its own class called "GameNumberGenerator"
        var gameNumberGenerator = new GameNumberGenerator();

        while (_gameState.IsActive)
        {
            // generate random number for the player to guess
            string correctGameNumber = gameNumberGenerator.GenerateGameNumber();

            _userInterface.Write(Messages.NewGameMessage);
            _userInterface.Write("For practice, secret number is: " + correctGameNumber + "\n"); //<---  comment out or remove  to play real games!
            _userInterface.Write(Messages.EnterGuessMessage);

            int numberOfGuesses = _gamePlay.PlayGame(correctGameNumber);
            if (!_gameState.IsActive) break;

            var highscoreEntry = name + "#&#" + numberOfGuesses;

            _highscoreHandler.InitializeHighscoreFile(Highscore.DefaultTextFileName, highscoreEntry);

            _highscore.ShowHighscore();

            _gameState.IsActive = _gamePlay.PlayAgainOption();
        }
    }
}
