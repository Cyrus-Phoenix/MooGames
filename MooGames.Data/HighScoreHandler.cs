using Games.Data.Interfaces;

namespace Games.Data;

public class HighScoreHandler : IHighscoreHandler
{
    public void InitializeHighscoreFile(string fileName, string highscoreFormat)
    {

        using (StreamWriter streamWriter = new StreamWriter(fileName, append: true))
        {
            streamWriter.WriteLine(highscoreFormat);
        }
    }
    public StreamReader ReadHighscoreFile(string fileName)
    {
        return new StreamReader(fileName);
    }
}

