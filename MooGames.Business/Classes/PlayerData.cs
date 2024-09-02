namespace MooGames.MooGame.Classes;

public class PlayerData
{
    public string Name { get; private set; }
    public int amountOfGamesPlayed { get; private set; }

    bool playerQuitedGame = true;

    int totalGuesses = 0;

    public PlayerData(string name, int guesses)
    {
        Name = name;
    }

    public void UpdateTotalGuesses(int guesses)
    {
        totalGuesses += guesses;
        amountOfGamesPlayed++;

    }

    public double Average()
    {
        return (double)totalGuesses / amountOfGamesPlayed;
    }

    public override bool Equals(Object player)
    {
        return Name.Equals(((PlayerData)player).Name);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

}
