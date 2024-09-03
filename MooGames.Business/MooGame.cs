using Games.Data.Interfaces;
using Games.Classes;
using Games.Common.Classes;
using Games.Common.Interfaces;

namespace Games.Common;

public class MooGame
{
    #region private readonly declarations
        private readonly IUserInterface _userInterface;
        private readonly IHighscoreHandler _highscoreHandler;
        private readonly Highscore _highscore;
        private readonly GameState _gameState;
        private readonly GamePlay _gamePlay;
    #endregion


    public MooGame(IUserInterface userInterface, IHighscoreHandler highscoreHandler)
    {
        _userInterface = userInterface ?? throw new ArgumentNullException(nameof(userInterface));
        _highscoreHandler = highscoreHandler ?? throw new ArgumentNullException(nameof(highscoreHandler));
        _highscore = new Highscore(userInterface, highscoreHandler);
        _gameState = new GameState();
        _gamePlay = new GamePlay(userInterface, _gameState);
     
    }

    public void RunMooGame()
    {
        _userInterface.Write(Messages.EnterNameMessage);
        string name = _userInterface.Read();
        string splitSeparator = "#&#";

        var gameNumberGenerator = new GameNumberGenerator();

        while (_gameState.IsActive)
        {
            string correctGameNumber = gameNumberGenerator.GenerateGameNumber();

            _userInterface.Write(Messages.NewGameMessage);
            //comment out or remove to play real games!
            _userInterface.Write("For practice, secret number is: " + correctGameNumber + "\n"); 
            _userInterface.Write(Messages.EnterGuessMessage);

            int numberOfGuesses = _gamePlay.PlayGame(correctGameNumber);
            if (!_gameState.IsActive) break;

            var highscoreFormat = name + splitSeparator + numberOfGuesses;

            _highscoreHandler.InitializeHighscoreFile(Highscore.DefaultTextFileName, highscoreFormat);
            _highscore.ShowHighscore();

            _gameState.IsActive = _gamePlay.PlayAgainOption();
        }
    }
}
