using System.IO;
using Games.Data.Interfaces;

namespace MooGames.Data;

public class HighScoreHandler: IHighscoreHandler
{

    /// <summary>
    /// Updates the given highscore file with the given highscore input, creating the file if it does not exist.
    /// </summary>
    /// <param name="path">The file path where the highscore will be updated.</param>
    /// <param name="highscoreInput">The highscore input to be written to the file.</param>
    /// <returns>Returns the StreamWriter object used to write to the file.</returns>
    public void UpdateHighscore(string path, string highscoreInput)
    {
       
        using (StreamWriter streamWriter = new StreamWriter(path, append: true))
        {
            streamWriter.WriteLine(highscoreInput);
        }
    }
    public StreamReader PrintHighscore(string path)
    {
        return new StreamReader(path);
    }
}

