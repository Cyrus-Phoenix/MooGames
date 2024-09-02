using MooGame.Classes;
using MooGames.Menu.Classes.Common;
using MooGames.Menu.Interfaces;
using MooGames.MooGame.Classes;
using Games.Data.Interfaces;
using MooGames.Data;
using System.Xml.Linq;

namespace MooGames.Menu;

public class MooGame
{
    private readonly IUserInterface _userInterface;
    private readonly IHighscoreHandler _highscoreHandler;
    private readonly Highscore _highscore;
    bool gameIsActive = true;


    public MooGame(IUserInterface userInterface, IHighscoreHandler highscoreHandler)
    {
        _userInterface = userInterface ?? throw new ArgumentNullException(nameof(userInterface));
        _highscoreHandler = highscoreHandler ?? throw new ArgumentNullException(nameof(highscoreHandler));
        _highscore= new Highscore(userInterface, highscoreHandler);
    }

   
    /// TODO: Bug: The first number of guesses is not counted.
    public void RunMooGame()
    {
       

        _userInterface.Write(Messages.EnterNameMessage);
        string name = _userInterface.Read();

        // *** extracted method "RandomGameNumber" to its own class called "GameNumberGenerator"
        var gameNumberGenerator = new GameNumberGenerator();

        while (gameIsActive)
        {
            // generate random number for the player to guess
            string correctGameNumber = gameNumberGenerator.GenerateGameNumber();

            _userInterface.Write(Messages.NewGameMessage);
            _userInterface.Write("For practice, secret number is: " + correctGameNumber + "\n"); //<---  comment out or remove  to play real games!
            _userInterface.Write(Messages.EnterGuessMessage);

            int numberOfGuesses = PlayGame(correctGameNumber);
            if (!gameIsActive) break;

            var highscoreEntry = name + "#&#" + numberOfGuesses;

            _highscoreHandler.InitializeHighscoreFile(Highscore.DefaultTextFileName, highscoreEntry);

            _highscore.ShowHighscore();

            gameIsActive = PlayAgainOption();
        }
    }

    private int PlayGame(string correctGameNumber)
    {
        string guessedNumber;
        int numberOfGuesses = 0;
        string userGuessResault = string.Empty;

        while (userGuessResault != "BBBB")
        {
            //IDEA create variable correctAnswer = "BBBB"
            numberOfGuesses++;
            guessedNumber = _userInterface.Read();
            if (guessedNumber.ToUpper() == "Q")
            {
                gameIsActive=false;
               return 0;
            }
            userGuessResault = GuessChecker.CheckUserGuess(correctGameNumber, guessedNumber);
            _userInterface.Write(userGuessResault + "\n");
        }
        return numberOfGuesses;
    }

   
    private bool PlayAgainOption()
    {
        while (true)
        {
            _userInterface.Write("Play again? (y/n)");
            string answer = _userInterface.Read();
            if (answer.ToUpper() == "Y")
            {
                return true;
            }
            else if (answer.ToUpper() == "N")
            {
                return false;
            }
            else
            {
                _userInterface.Write("Invalid input");
            }
        }
    }




    ///TODO: IDEA: Bryta ut metoden till egen klass
    //static string CheckUserGuess(string correctGameNumber, string userGuess)
    //{
    //    // Ensure userGuess has at least 4 characters
    //    userGuess = userGuess.PadRight(4);

    //    // Zip to iterate over the correctGameNumber and userGuess in parallel
    //    var characterPairs = correctGameNumber.Zip(userGuess, (correctCharacter, guessedCharacter) => new { correctCharacter, guessedCharacter });

    //    int bullCount = characterPairs.Count(pair => pair.correctCharacter == pair.guessedCharacter);
    //    int cowCount = characterPairs.Count(pair => pair.correctCharacter != pair.guessedCharacter && correctGameNumber.Contains(pair.guessedCharacter));

    //    return new string('B', bullCount) + new string('C', cowCount);
    //}
}
