using System.IO;
using Games.Data.Interfaces;

namespace MooGames.Data;

public class HighScoreHandler: IHighscoreHandler
{
 

    public StreamWriter UpdateHighscore(string path, string highscoreInput)
    {
       StreamWriter streamWriter = new StreamWriter(path, append:true);
       streamWriter.WriteLine(highscoreInput);
       streamWriter.Close();
       return streamWriter;
    }
    public  StreamReader PrintHighscore(string path)
    { 
        StreamReader streamReader = new StreamReader(path);
        return streamReader;

    }
}

