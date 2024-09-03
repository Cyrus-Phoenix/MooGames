using Games.Common.Classes;
using Games.Common.Interfaces;
using Moq;
using Games.Menu.Classes;

namespace Games.Common.ControllerMooGames.Menu.Controller_Tests
{
    [TestClass()]
    public class MooGameMenuControllerMenu_Tests
    {
        #region Hiding this test to write second test by myself

        [TestMethod()]
        public void RunMenuRunMenu_InvalidChoice_DisplaysInvalidChoiceMessage()
        {
            //Arrange
            var mockUserInterface = new Mock<IUserInterface>();
            var mockMooGame = new Mock<IGame>();
            var mockArenaGame = new Mock<IGame>();

            //Assert
            var menuHandler = new MenuHandler(mockUserInterface.Object, mockMooGame.Object, mockArenaGame.Object);

            // This is just a string that represents an invalid choice in the menu.
            var invalidChoice = " ";
            
            //Assert
            var validChoices = new List<string> { "1", "2", "3", "Q" };
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
            var mockMooGame = new Mock<IGame>();
            var mockArenaGame = new Mock<IGame>();

            
            var menuHandler = new MenuHandler(mockUserInterface.Object, mockMooGame.Object, mockArenaGame.Object);
            var quitApplication = "Q";

            //Act
            menuHandler.RunMenuAction(quitApplication);

            //Assert
            mockUserInterface.Verify(ui => ui.Write(Messages.ThankYouForPlayingMessage), Times.Once,$"You typed {quitApplication} Expected ThankYouForPlayingMessage to be written");
        }
    }
}