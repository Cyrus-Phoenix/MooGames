using System.IO;
using Games.Data.Interfaces;

namespace MooGames.Data;

public class HighScoreHandler: IHighscoreHandler
{

   
    public void InitializeHighscoreFile(string fileName, string splitIdentifier)
    {
       
        using (StreamWriter streamWriter = new StreamWriter(fileName, append: true))
        {
            streamWriter.WriteLine(splitIdentifier);
        }
    }
    public StreamReader ReadHighscoreFile(string fileName)
    {
        return new StreamReader(fileName);
    }
}

