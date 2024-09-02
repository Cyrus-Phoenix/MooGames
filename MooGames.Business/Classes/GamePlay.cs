using MooGames.Menu.Interfaces;
using MooGames.Menu.Classes.Common;

namespace MooGame.Classes
{
    public class GamePlay
    {
        private readonly IUserInterface _userInterface;
        private readonly GameState _gameState;
        public GamePlay(IUserInterface userInterface, GameState gameState)
        {
            _userInterface = userInterface;
            _gameState = gameState;
        }


        public int PlayGame(string correctGameNumber)
        {
            string guessedNumber;
            int numberOfGuesses = 0;
            string userGuessResault = string.Empty;

            while (userGuessResault != "BBBB")
            {
                //IDEA create variable correctAnswer = "BBBB"
               
                guessedNumber = _userInterface.Read();
             
                if (guessedNumber.ToUpper() == "Q")
                {
                    _gameState.IsActive = false;
                    return 0;
                }
                int parsedNumber;
                if(!int.TryParse(guessedNumber, out parsedNumber))
                {
                    _userInterface.Write("Invalid input. Guess has to be a 4 digit integer number");
                    continue;
                }
                else if(guessedNumber.Length != 4)
                {
                    _userInterface.Write("Invalid input. Please enter a 4 digit number\n");
                    continue;
                }

                numberOfGuesses++;
                userGuessResault = CheckUserGuess(correctGameNumber, guessedNumber);
                _userInterface.Write(userGuessResault + "\n");
                _userInterface.Write(Messages.Divider + "\n");
               
            }
            _userInterface.Write(Messages.GameWonMessage + "\n");
            return numberOfGuesses;
        }


        public bool PlayAgainOption()
        {
            while (true)
            {
                _userInterface.Write(Messages.ReplayChoiceMessage);
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
                    _userInterface.Write(Messages.InvalidReplayChoiceMessage);
                }
            }
        }

        public static string CheckUserGuess(string correctGameNumber, string userGuess)
        {
            // Ensure userGuess has at least 4 characters
            userGuess = userGuess.PadRight(4);

            // Zip to iterate over the correctGameNumber and userGuess in parallel
            var characterPairs = correctGameNumber.Zip(userGuess, (correctCharacter, guessedCharacter) => new { correctCharacter, guessedCharacter });

            int bullCount = characterPairs.Count(pair => pair.correctCharacter == pair.guessedCharacter);
            int cowCount = characterPairs.Count(pair => pair.correctCharacter != pair.guessedCharacter && correctGameNumber.Contains(pair.guessedCharacter));

            return new string('B', bullCount) + new string('C', cowCount);
        }

    }
}