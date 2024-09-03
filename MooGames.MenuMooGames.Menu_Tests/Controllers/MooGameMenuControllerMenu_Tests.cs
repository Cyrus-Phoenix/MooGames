using MooGames.Menu.Classes;
using MooGames.Menu.Classes.Common;
using MooGames.Menu.Interfaces;
using Games.Data.Interfaces;
using Moq;
using MooGame.Classes;

namespace MooGames.Menu.ControllerMooGames.Menu.Controller_Tests
{
    [TestClass()]
    public class MooGameMenuControllerMenu_Tests
    {
        #region Hiding this test to write second test by myself

        [TestMethod()]
        public void RunMenuRunMenu_InvalidChoice_DisplaysInvalidChoiceMessage()
        {
            //Arrange
            // Create a new mock object for the IUserInterface. 
            // This creates a "fake" user interface that we can control in our test.
            var mockUserInterface = new Mock<IUserInterface>();
            var mockHighscoreHandler = new Mock<IHighscoreHandler>();
            var mockMooGame = new Mock<MooGame>(mockUserInterface.Object, mockHighscoreHandler.Object);
            var mockHighscore = new Mock<Highscore>(mockUserInterface.Object, mockHighscoreHandler.Object);


            // The .Object property on a Mock<T> gives you the actual object that has been mocked.
            // In this case, it gives you an object that implements IUserInterface.
            // This object doesn't do anything by default, but you can set up expectations and return values on it.
            var menuHandler = new MenuHandler(mockUserInterface.Object, mockHighscoreHandler.Object, mockMooGame.Object, mockHighscore.Object);

            // This is just a string that represents an invalid choice in the menu.
            var invalidChoice = " ";
            
            //Assert
            var validChoices = new List<string> { "1", "2", "3", "4", "Q" };
            if(validChoices.Contains(invalidChoice))
            {
                Assert.Fail($"'{invalidChoice}' is a valid choice but expected an invalid choice");
            }
           

            //Act
            menuHandler.RunMenuAction(invalidChoice);

            //Assert
            mockUserInterface.Verify(ui => ui.Write(Messages.InvalidChoiceMessage), Times.Once, "Valid choice but expected Invalid choice");

        }
        #endregion
            
        [TestMethod()]
        public void RunMenuRunMenu_QuitApplication_WritesThankYouMessage()
        {
            //Arrange
            var mockUserInterface = new Mock<IUserInterface>();
            var mockHighscoreHandler = new Mock<IHighscoreHandler>();
            var mockMooGame = new Mock<MooGame>(mockUserInterface.Object, mockHighscoreHandler.Object);
            var mockHighscore = new Mock<Highscore>(mockUserInterface.Object, mockHighscoreHandler.Object);

            var menuHandler = new MenuHandler(mockUserInterface.Object, mockHighscoreHandler.Object, mockMooGame.Object, mockHighscore.Object);
            var quitApplication = "Q";

            //Act
            menuHandler.RunMenuAction(quitApplication);

            //Assert
            mockUserInterface.Verify(ui => ui.Write(Messages.ThankYouForPlayingMessage), Times.Once,$"You typed {quitApplication} Expected ThankYouForPlayingMessage to be written");
        }
    }
}