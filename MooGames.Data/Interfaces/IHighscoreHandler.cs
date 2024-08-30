namespace Games.Data.Interfaces;

public interface IHighscoreHandler
{
    public StreamWriter UpdateHighscore(string path, string highscoreInput);
    public StreamReader PrintHighscore(string path);
}
