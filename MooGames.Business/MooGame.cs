using MooGames.Business.Classes.Common;
using MooGames.Business.Classes.Game;
using MooGames.Business.Interfaces;
using MooGames.Data.Classes;

namespace MooGames.Business;


public class MooGame
{
    private readonly IUserInterface _userInterface;

    public MooGame(IUserInterface userInterface)
    {
        if (userInterface == null)
        {
            throw new ArgumentNullException(nameof(userInterface));
        }
        _userInterface = userInterface;
    }

    /// TODO: Bug: The first number of guesses is not counted.
    /// TODO: Show more game rules to the player more than "guessing the number". Player need to know what BBBB and CCCC means.
    public void RunMooGame()
    
        ///TODO:Test all parts of the game
    {
        // taking input: user name, declaring game loop
        // *** changed gameloop to "gameIsActive"
        bool gameIsActive = true;
        _userInterface.Write(Messages.EnterUserNameMessage);
        string name = _userInterface.Read();

        // *** extracted method "RandomGameNumber" to its own class called "GameNumberGenerator"
        // *** changed variable name from "makeRandomGameNumber" to "generateGameNumber"
        var generateGameNumber = new GameNumberGenerator();


        while (gameIsActive)
        {
            // generate random number for the player to guess
            // *** also changed variable name from "goal" to "correctGameNumber"
            string correctGameNumber = generateGameNumber.RandomGameNumber();

            _userInterface.Write(Messages.NewGameMessage);
            // comment out or remove next line to play real games!
            _userInterface.Write("For practice, secret number is: " + correctGameNumber + "\n");
            _userInterface.Write(Messages.EnterGuessMessage);



            // input from user: a guessed number
            // *** changed variable name from "guess" to "guessedNumber"
            string guessedNumber = _userInterface.Read();
            
            // *** changed variable name from "nGuess" to "numberOfGuesses"
            int numberOfGuesses = 1;


            //calling method wich compares guesses number with correct answer. returns B's and C's (or nothing)
            // *** changed the method's name from "checkBC" to "checkUserGuess"
            ///*** changed variable name from "bbcc" to "userGuessResault"
            string userGuessResault = CheckUserGuess(correctGameNumber, guessedNumber);

            // Write the result. IDEA: put this in the checkUserGuess method?
            _userInterface.Write(userGuessResault + "\n");

            ///TODO: BUG: Player cannot quit in middle of the game
            // quit if the user chooses to cancel, else - keep on asking for guesses 
            if (guessedNumber.ToUpper() == "Q")
                gameIsActive = false;
            else { 
                while (userGuessResault != "BBBB,")
                {
                    //IDEA create variable correctAnswer = "BBBB"
                    numberOfGuesses++;
                    guessedNumber = _userInterface.Read();
                    Console.WriteLine(guessedNumber + "\n");
                    userGuessResault = CheckUserGuess(correctGameNumber, guessedNumber);
                    Console.WriteLine(userGuessResault + "\n");
                }
                
                StreamWriter output = new StreamWriter("result.txt", append: true);
                output.WriteLine(name + "#&#" + numberOfGuesses);
                output.Close();

                showTopList();

                _userInterface.Write("Correct, it took " + numberOfGuesses + " guesses\n Continue?\n n = no");
                string answer = _userInterface.Read();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    gameIsActive = false;
                }
            }
            




           
        }


        ///TODO: Bryta ut metoden till egen klass
        #region Linq version av den nestlade loopen under

        static string CheckUserGuess(string correctGameNumber, string userGuess)
        {
            // Ensure userGuess has at least 4 characters
            userGuess = userGuess.PadRight(4);

            // Use Zip to iterate over the correctGameNumber and userGuess in parallel
            var matches = correctGameNumber.Zip(userGuess, (correctChar, guessChar) => new { correctChar, guessChar });

            // Count the bulls and cows
            int bullCount = matches.Count(match => match.correctChar == match.guessChar);
            int cowCount = matches.Count(match => match.correctChar != match.guessChar && correctGameNumber.Contains(match.guessChar));

            // Build the result string
            string result = new string('B', bullCount) + "," + new string('C', cowCount);

            return result;
        }

        #endregion

        //static string CheckUserGuess(string correctgamenumber, string guessednumber)
        //{
        //    // idea: is there a way to make this method more readable?
        //    ///todo : make this method more readable
        //    int cows = 0, bulls = 0;
        //    guessednumber += "    ";     // if player entered less than 4 chars
        //    for (int i = 0; i < 4; i++)
        //    {
        //        for (int j = 0; j < 4; j++)
        //        {
        //            if (correctgamenumber[i] == guessednumber[j])
        //            {
        //                if (i == j)
        //                {
        //                    bulls++;
        //                }
        //                else
        //                {
        //                    cows++;
        //                }
        //            }
        //        }
        //    }
        //    return "bbbb".Substring(0, bulls) + "," + "cccc".Substring(0, cows);
        //}

        ///TODO: Bryta ut metoden till egen klass
    }
        public void showTopList()
        {

            StreamReader input = new StreamReader("result.txt");
            List<PlayerData> results = new List<PlayerData>();
            string line;
            while ((line = input.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                PlayerData pd = new PlayerData(name, guesses);
                int pos = results.IndexOf(pd);
                if (pos < 0)
                {
                    results.Add(pd);
                }
                else
                {
                    results[pos].Update(guesses);
                }


            }
            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            _userInterface.Write("Player   games average");
            foreach (PlayerData p in results)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
            }
            input.Close();
        }
}