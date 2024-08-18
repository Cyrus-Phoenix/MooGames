using MooGames.Business.Classes.Game;
using MooGames.Business.Interfaces;
using MooGames.Data.Classes;

namespace MooGames.Business;


public class Business
{
    private readonly IUserInterface _userInterface;

    public Business(IUserInterface userInterface)
    {
        if(userInterface == null)
        {
            throw new ArgumentNullException(nameof(userInterface));
        }
          _userInterface = userInterface;
    }

    /// TODO: Bug: The first number of guesses is not counted.
    public void RunGame()
        ///TODO:Test all parts of the game
    {
        // taking input: user name, declaring game loop
        // *** changed gameloop to "gameIsActive"
        bool gameIsActive = true;
        _userInterface.Write("Enter your user name:\n");
        string name = _userInterface.Read();

        // *** extracted method "RandomGameNumber" to its own class called "GameNumberGenerator"
        // *** changed variable name from "makeRandomGameNumber" to "generateGameNumber"
        var generateGameNumber = new GameNumberGenerator();


        while (gameIsActive)
        {
            // generate random number for the player to guess
            // *** also changed variable name from "goal" to "correctGameNumber"
            string correctGameNumber = generateGameNumber.RandomGameNumber();

            _userInterface.Write("New game:\n");
            // comment out or remove next line to play real games!
            _userInterface.Write("For practice, number is: " + correctGameNumber + "\n");
            
            // input from user: a guessed number
            // *** changed variable name from "guess" to "guessedNumber"
            string guessedNumber = _userInterface.Read();
            // *** changed variable name from "nGuess" to "numberOfGuesses"
            int numberOfGuesses = 1;

            //calling method wich compares guesses number with correct answer. returns B's and C's (or nothing)
            // *** changed the method's name from "checkBC" to "checkUserGuess"
            ///*** changed variable name from "bbcc" to "userGuessResault"
            string userGuessResault = checkUserGuess(correctGameNumber, guessedNumber);
            
            // Write the result. IDEA: put this in the checkUserGuess method?
            _userInterface.Write(userGuessResault + "\n");

            // Keep on asking for guesses until the users answer is correct
            // IDEA: make method that takes user guess and give resault
            ///TODO: make method that takes user guess and give resault
            while (userGuessResault != "BBBB,")
            {
                //IDEA create variable correctAnswer = "BBBB"
                numberOfGuesses++;
                guessedNumber = _userInterface.Read();
                Console.WriteLine(guessedNumber + "\n");
                userGuessResault = checkUserGuess(correctGameNumber, guessedNumber);
                Console.WriteLine(userGuessResault + "\n");
            }

            
            StreamWriter output = new StreamWriter("result.txt", append: true);
            output.WriteLine(name + "#&#" + numberOfGuesses);
            output.Close();
            showTopList();
            ///TODO: Change the message to be more user friendly
            _userInterface.Write("Correct, it took " + numberOfGuesses + " guesses\n Continue?\n n = no");
            string answer = _userInterface.Read();
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
            {
                gameIsActive = false;
            }
        }

      
        ///TODO: Bryta ut metoden till egen klass
        static string checkUserGuess(string correctGameNumber, string guessedNumber)
        {
            // IDEA: is there a way to make this method more readable?
            ///TODO : make this method more readable
            int cows = 0, bulls = 0;
            guessedNumber += "    ";     // if player entered less than 4 chars
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (correctGameNumber[i] == guessedNumber[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }
            return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
        }

        ///TODO: Bryta ut metoden till egen klass
            void showTopList()
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
}
