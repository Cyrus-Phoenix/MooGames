using Games.Data.Interfaces;
using MooGames.Menu.Interfaces;
using MooGames.MooGame.Classes;

namespace MooGame.Classes;

public class Highscore
{

    public const string DefaultTextFileName = "result.txt";
    bool playerQuitedGame = true;

    private readonly IUserInterface _userInterface;
    private readonly IHighscoreHandler _highscoreHandler;

    public Highscore(IUserInterface userInterface, IHighscoreHandler highscoreHandler)
    {
        _userInterface = userInterface;
        _highscoreHandler = highscoreHandler;
    }

    public void ShowHighscore()
    {
        try
        {
            using (StreamReader input = _highscoreHandler.ReadHighscoreFile(DefaultTextFileName))
            {
                List<PlayerData> playersHighscoreResults = UpdateHighscore(input);
                playersHighscoreResults.Sort((currentPlayer, previousPlayer) => currentPlayer.Average().CompareTo(previousPlayer.Average()));
                //_userInterface.Write("Player   games average");
                PrintHighscore(playersHighscoreResults);
            }
        }
        catch (FileNotFoundException)
        {
            _userInterface.Write("Highscore file not found. No highscores to display.");
        }
        catch (Exception ex)
        {
            _userInterface.Write($"An error occurred while reading the highscore file: {ex.Message}");
        }
    }

    private List<PlayerData> UpdateHighscore(StreamReader input)
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
                //This is here for the game to add first playthrough to the highscore list
                indexPosition = results.IndexOf(playerData);
                playerData.UpdateTotalGuesses(guesses);
            }
            else
            {
                results[indexPosition].UpdateTotalGuesses(guesses);
            }
        }

        return results;
    }


    private void PrintHighscore(List<PlayerData> playersHighscoreResults)
    {
        // Define column widths
        int nameColumnWidth = 18;
        int gamesColumnWidth = 7;
        int averageColumnWidth = 7;

        // Calculate total table width
        int totalWidth = nameColumnWidth + gamesColumnWidth + averageColumnWidth + 10;

        // Calculate padding for centering the table
        int consoleWidth = Console.WindowWidth;
        int tablePadding = (consoleWidth - totalWidth) / 2;
        string tablePaddingString = new string(' ', tablePadding);

        // Calculate padding for centering the title
        string title = "HighScore";
        int titlePadding = (consoleWidth - title.Length) / 2;
        string titlePaddingString = new string(' ', titlePadding);

        // Print title
        _userInterface.Write(titlePaddingString + title);

        // Print header
        _userInterface.Write(tablePaddingString + new string('═', totalWidth));
        _userInterface.Write(tablePaddingString + $"║ {"Player".PadRight(nameColumnWidth)} ║ {"Games".PadRight(gamesColumnWidth)} ║ {"Average".PadRight(averageColumnWidth)} ║");
        _userInterface.Write(tablePaddingString + new string('═', totalWidth));

        // Print each player's high score
        foreach (PlayerData player in playersHighscoreResults)
        {
            string name = player.Name.PadRight(nameColumnWidth);
            string games = player.amountOfGamesPlayed.ToString().PadRight(gamesColumnWidth);
            string average = player.Average().ToString("F2").PadRight(averageColumnWidth);
            _userInterface.Write(tablePaddingString + $"║ {name} ║ {games} ║ {average} ║");
        }

        _userInterface.Write(tablePaddingString + new string('═', totalWidth));
    }
}