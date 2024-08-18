using MooGames.Business;
using MooGames.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGames.Business.Controller
{
    public class Controller
    {
        private readonly IUserInterface _userInterface;

        public Controller(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }


        public void RunGame()
        {
            var gameRunner = new Business();

            gameRunner.RunGame();

        }


    }
}
