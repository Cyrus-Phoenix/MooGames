using MooGame.Interfaces;
using MooGames.Business;
using MooGames.Business.Classes.Common;
using MooGames.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGames.Business.Controller
{
    public class MooGameMenuController : IMenuController
    {
        private readonly IUserInterface _userInterface;

        public MooGameMenuController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        public void RunMenu()
        {
            var mooGame = new MooGame(_userInterface);

           // _userInterface.Write(Messages.Menu);

            bool menuIsActive = true;

            while (menuIsActive)
            {
                _userInterface.Write(Messages.Menu);
                _userInterface.Write(Messages.MenuChoiceMessage);

            string userInput = _userInterface.Read();

                if (userInput == Messages.MenuChoice1)
                {
                    mooGame.RunMooGame();
                }
                else if (userInput == Messages.MenuChoice5)
                {
                    mooGame.showTopList();
                }
                else
                {
                    _userInterface.Write(Messages.ThankYouForPlayingMessage);
                    menuIsActive = false;
                }
            }
           
        }


    }
}
