namespace Games.Data.Interfaces;

public interface IHighscoreHandler
{
    public void InitializeHighscoreFile(string path, string highscoreInput);
    public StreamReader ReadHighscoreFile(string path);
}
