using Games.Common.Classes;
using Games.Common.Controller;
using Games.Common.Interfaces;
using MooGame;

namespace Games.UI;

class MainClass
{
    public static void Main(string[] args)
    {
        IUserInterface userInterface = new ConsoleUserinterface();
        IGame mooGame = new GameRunner();
        IGame arenaGame = new ArenaFighter.GameRunner();

        MenuController menuController = new MenuController(userInterface, mooGame, arenaGame);
        menuController.RunMenu();
    }
}