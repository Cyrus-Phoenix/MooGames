using MooGame.Classes;
using MooGames.Menu.Classes.Common;
using MooGames.Menu.Interfaces;
using MooGames.MooGame.Classes;
using Games.Data.Interfaces;
using MooGames.Data;

namespace MooGames.Menu;

public class MooGame
{
    private readonly IUserInterface _userInterface;
    private readonly IHighscoreHandler _highscoreHandler;

    public MooGame(IUserInterface userInterface, IHighscoreHandler highscoreHandler)
    {
        //if (userInterface == null)
        //{
        //    throw new ArgumentNullException(nameof(userInterface));
        //}
        // samma som ovan, bara vi använda ?? operatorn istället för en if-sats
        _userInterface = userInterface ?? throw new ArgumentNullException(nameof(userInterface));
        _highscoreHandler = highscoreHandler ?? throw new ArgumentNullException(nameof(highscoreHandler));
    }

   
    /// TODO: Bug: The first number of guesses is not counted.
    public void RunMooGame()
    ///TODO: IDEA: Test all parts of the game
    {
        bool gameIsActive = true;

        _userInterface.Write(Messages.EnterNameMessage);
        string name = _userInterface.Read();

        // *** extracted method "RandomGameNumber" to its own class called "GameNumberGenerator"
        var gameNumberGenerator = new GameNumberGenerator();

        while (gameIsActive)
        {
            // generate random number for the player to guess
            string correctGameNumber = gameNumberGenerator.GenerateGameNumber();

            _userInterface.Write(Messages.NewGameMessage);
            // comment out or remove next line to play real games!
            _userInterface.Write("For practice, secret number is: " + correctGameNumber + "\n");
            _userInterface.Write(Messages.EnterGuessMessage);

            int numberOfGuesses = PlayGame(correctGameNumber);
            if (!gameIsActive) break;

            var textFileName = "result.txt";
            var highscoreEntry = name + "#&#" + numberOfGuesses;

            _highscoreHandler.UpdateHighscore(textFileName, highscoreEntry);

            ShowHighscore();

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
                return numberOfGuesses;
                //gameIsActive = false;
                //break;
            }
            //Console.WriteLine(guessedNumber + "\n");
            userGuessResault = CheckUserGuess(correctGameNumber, guessedNumber);
            _userInterface.Write(userGuessResault + "\n");
        }

        return numberOfGuesses;
    }

    //private bool PlayAgainOption(bool gameIsActive, int numberOfGuesses)
    //{
    //    bool playerDecidedToPlayAgain = false;
    //    while (!playerDecidedToPlayAgain)
    //    {
    //        _userInterface.Write("Correct, it took " + numberOfGuesses + " guesses\n Play again? (y/n)");
    //        string answer = _userInterface.Read();
    //        if (answer.ToUpper() == "Y")
    //        {
    //            playerDecidedToPlayAgain = true;
    //        }
    //        else if (answer.ToUpper() == "N")
    //        {
    //            gameIsActive = false;
    //            break;
    //        }
    //        else
    //        {
    //            _userInterface.Write("invalid input");
    //        }
    //    }

    //    return gameIsActive;
    //}





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
    static string CheckUserGuess(string correctGameNumber, string userGuess)
    {
        // Ensure userGuess has at least 4 characters
        userGuess = userGuess.PadRight(4);

        // Use Zip to iterate over the correctGameNumber and userGuess in parallel
        var characterPairs = correctGameNumber.Zip(userGuess, (correctCharacter, guessedCharacter) => new { correctCharacter, guessedCharacter });

        int bullCount = characterPairs.Count(pair => pair.correctCharacter == pair.guessedCharacter);
        int cowCount = characterPairs.Count(pair => pair.correctCharacter != pair.guessedCharacter && correctGameNumber.Contains(pair.guessedCharacter));

        return new string('B', bullCount) + new string('C', cowCount);
    }



    ///TODO: IDEA: Bryta ut metoden till egen klass
    public void ShowHighscore()
    {
        using (StreamReader input = _highscoreHandler.PrintHighscore("result.txt"))
        { 
            List<PlayerData> results = new List<PlayerData>();
            string line;
            while ((line = input.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                PlayerData playerData = new PlayerData(name, guesses);
                int indexPosition = results.IndexOf(playerData);
                if (indexPosition < 0)
                {
                    results.Add(playerData);
                }
                else
                {
                    results[indexPosition].Update(guesses);
                }
            }
            results.Sort((mainPlayer, previousPlayer) => mainPlayer.Average().CompareTo(previousPlayer.Average()));
            _userInterface.Write("Player   games average");
            foreach (PlayerData player in results)
            {
                _userInterface.Write(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.amountOfGamesPlayed, player.Average()));
            }
        }
        
    }


}
