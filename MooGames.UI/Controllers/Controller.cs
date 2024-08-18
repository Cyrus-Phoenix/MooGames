using MooGames.UI.Interface;
using MooGames.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGames.UI.Controller
{
    class Controller
    {
        private readonly IUserInterface _userInterface;

        public Controller(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        public void RunGame()
        {
            var gameRunner = new Business.Business();

            gameRunner.RunGame();

        }
        

    }
}
