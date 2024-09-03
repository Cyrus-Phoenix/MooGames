using Games.Common.Interfaces;
using Games.Common.Classes;

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
            string winCondition = "BBBB";

            while (userGuessResault != winCondition)
            {  
                guessedNumber = _userInterface.Read();
             
                if (guessedNumber.ToUpper() == "Q")
                {
                    _gameState.IsActive = false;
                    return 0;
                }
                
                if(!IsValidGuess(guessedNumber))
                {
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
            return GetReplayChoice();
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


        private bool GetReplayChoice()
        {
            while (true)
            {
                _userInterface.Write(Messages.ReplayChoiceMessage);
                string answer = _userInterface.Read().ToUpper();

                if (answer == "Y")
                {
                    return true;
                }
                else if (answer == "N")
                {
                    return false;
                }
                else
                {
                    _userInterface.Write(Messages.InvalidReplayChoiceMessage);
                }
            }
        }

        /// <summary>
        /// Validates the user's guessed number.
        /// </summary>
        /// <param name="guessedNumber">The guessed number to validate.</param>
        /// <returns>True if the guessed number is valid, otherwise false.</returns>
        private bool IsValidGuess(string guessedNumber)
        {
            if (!int.TryParse(guessedNumber, out _))
            {
                _userInterface.Write(Messages.InvalidStringGuessMessage);
                return false;
            }

            if (guessedNumber.Length != 4)
            {
                _userInterface.Write(Messages.InvalidDigitLengthMessage);
                return false;
            }

            return true;
        }
    }
}