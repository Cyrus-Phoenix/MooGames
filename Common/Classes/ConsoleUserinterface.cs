using MooGames.Menu.Interfaces;

namespace MooGames.Menu.Classes.Common;

public class ConsoleUserinterface : IUserInterface
{
    public void Write(string message)
    {
        Console.WriteLine(message);
    }

    public string Read()
    {
        return Console.ReadLine()?.Trim() ?? string.Empty;
    }
}
