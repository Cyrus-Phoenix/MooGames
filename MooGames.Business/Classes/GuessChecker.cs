using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Classes
{
    public static class GuessChecker
    {
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
