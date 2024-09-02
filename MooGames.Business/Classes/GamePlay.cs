using MooGames.Menu.Interfaces;

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

        public bool PlayAgainOption()
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

        public int PlayGame(string correctGameNumber)
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
                    _gameState.IsActive = false;
                    return 0;
                }
                userGuessResault = GuessChecker.CheckUserGuess(correctGameNumber, guessedNumber);
                _userInterface.Write(userGuessResault + "\n");
            }
            return numberOfGuesses;
        }
    }
}