using Games.Data.Interfaces;
using Games.Common.Interfaces;

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


        int totalTableWidth = nameColumnWidth + gamesColumnWidth + averageColumnWidth + 10;


        int consoleWidth;
        string tablePaddingString;
        CenteringHighscoreTable(totalTableWidth, out consoleWidth, out tablePaddingString);


        string title = "HighScore";
        string centerTitle = CenteringHighscoreTitle(consoleWidth, title);

        
        _userInterface.Write(centerTitle + title);

        
        HighscoreHeader(nameColumnWidth, gamesColumnWidth, averageColumnWidth, totalTableWidth, tablePaddingString);

        foreach (PlayerData player in playersHighscoreResults)
        {
            string name = player.Name.PadRight(nameColumnWidth);
            string games = player.amountOfGamesPlayed.ToString().PadRight(gamesColumnWidth);
            string average = player.Average().ToString("F2").PadRight(averageColumnWidth);
            _userInterface.Write(tablePaddingString + $"║ {name} ║ {games} ║ {average} ║");
        }

        _userInterface.Write(tablePaddingString + new string('═', totalTableWidth));
    }

    private void HighscoreHeader(int nameColumnWidth, int gamesColumnWidth, int averageColumnWidth, int totalTableWidth, string tablePaddingString)
    {
        _userInterface.Write(tablePaddingString + new string('═', totalTableWidth));
        _userInterface.Write(tablePaddingString + $"║ {"Player".PadRight(nameColumnWidth)} ║ {"Games".PadRight(gamesColumnWidth)} ║ {"Average".PadRight(averageColumnWidth)} ║");
        _userInterface.Write(tablePaddingString + new string('═', totalTableWidth));
    }

    private static string CenteringHighscoreTitle(int consoleWidth, string title)
    {
        int titlePadding = (consoleWidth - title.Length) / 2;
        string titlePaddingString = new string(' ', titlePadding);
        return titlePaddingString;
    }

    private static void CenteringHighscoreTable(int totalTableWidth, out int consoleWidth, out string tablePaddingString)
    {
        consoleWidth = Console.WindowWidth;
        int tablePadding = (consoleWidth - totalTableWidth) / 2;
        tablePaddingString = new string(' ', tablePadding);
    }
}