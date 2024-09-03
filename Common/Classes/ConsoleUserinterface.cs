using Games.Common.Interfaces;

namespace Games.Common.Classes;

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
