namespace Games.Data.Interfaces;

public interface IHighscoreHandler
{
    public void UpdateHighscore(string path, string highscoreInput);
    public StreamReader PrintHighscore(string path);
}
