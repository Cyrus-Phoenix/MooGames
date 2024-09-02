using Games.Data.Interfaces;
using MooGames.Menu.Interfaces;
using MooGames.MooGame.Classes;

namespace MooGame.Classes
{
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
                    _userInterface.Write("Player   games average");
                    foreach (PlayerData player in playersHighscoreResults)
                    {
                        _userInterface.Write(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.amountOfGamesPlayed, player.Average()));
                    }
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
    }
}