//using Games.Data.Interfaces;
//using MooGame.Classes;
//using Games.Interfaces;
//using Games.Common.Classes;
//using Games.Common.Interfaces;
//using MooGame;



//namespace  Games.Common.Controller;

////public class MenuController : IMenuController
//{
//    private readonly IUserInterface _userInterface;
//    private readonly IHighscoreHandler _highscoreHandler;
//    private readonly IGame _mooGame;
//    private readonly Highscore _highscore;
   

//    public MenuController(IUserInterface userInterface, IHighscoreHandler highscoreHandler)
//    {
//        _userInterface = userInterface;
//        _highscoreHandler = highscoreHandler;

//        _mooGame = new Game(_userInterface, _highscoreHandler);
//        _highscore = new Highscore(_userInterface, _highscoreHandler);
//    }

//    public void RunMenu()
//    {
//        var menuHandler = new MenuHandler(_userInterface, _highscoreHandler, _mooGame, _highscore);
//        bool menuIsActive = true;

//        while (menuIsActive)
//        {
//            string userInput = menuHandler.GetUserChoice();
//            menuHandler.RunMenuAction(userInput);
//            menuIsActive = userInput.ToUpper() != Messages.QuitApplication;
//        }
//    }
//}
