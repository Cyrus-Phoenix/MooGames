namespace MooGames.MooGame.Classes;

public class PlayerData
{
    public string Name { get; private set; }
    public int NGames { get; private set; }

    int totalGuess;

    public PlayerData(string name, int guesses)
    {
        Name = name;
    }

    public void Update(int guesses)
    {
        totalGuess += guesses;
        NGames++;
    }

    public double Average()
    {
        return (double)totalGuess / NGames;
    }

    public override bool Equals(Object p)
    {
        return Name.Equals(((PlayerData)p).Name);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

}
