using MooGame.Classes;
using Games.Common.Interfaces;
using Moq;


namespace Games.ClassesMooGame.Classes.GamePlay_Tests
{
    [TestClass()]
    public class GamePlay_Tests
    {
        [TestMethod]
        public void PlayGame_ValidGuess_ReturnsNumberOfGuesses()
        {
            // Arrange
            var mockUserInterface = new Mock<IUserInterface>();
            var gameState = new GameState();
            var gamePlay = new GamePlay(mockUserInterface.Object, gameState);
            string correctGameNumber = "1234";

            mockUserInterface.SetupSequence(ui => ui.Read())
                .Returns("5678") 
                .Returns("1234");

            // Act
            int result = gamePlay.PlayGame(correctGameNumber);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void PlayGame_InvalidInput_ShowsErrorMessage()
        {
            // Arrange
            var mockUserInterface = new Mock<IUserInterface>();
            var gameState = new GameState();
            var gamePlay = new GamePlay(mockUserInterface.Object, gameState);
            var correctGameNumber = "1234";

            mockUserInterface.SetupSequence(ui => ui.Read())
                .Returns("abcd") // Invalid input
                .Returns("1234"); // Correct guess

            // Act
            int result = gamePlay.PlayGame(correctGameNumber);

            // Assert
            mockUserInterface.Verify(ui => ui.Write("Invalid input. Guess has to be a 4 digit integer number"), Times.Once);
            Assert.AreEqual(1, result); // One valid guess was made
        }

        [TestMethod]
        public void PlayGame_QuitGame_ReturnsZero()
        {
            // Arrange
            var mockUserInterface = new Mock<IUserInterface>();
            var gameState = new GameState();
            var gamePlay = new GamePlay(mockUserInterface.Object, gameState);
            string correctGameNumber = "1234";

            mockUserInterface.Setup(ui => ui.Read()).Returns("Q");

            // Act
            int result = gamePlay.PlayGame(correctGameNumber);

            // Assert
            Assert.AreEqual(0, result); // Game was quit
            Assert.IsFalse(gameState.IsActive); // Game state should be inactive
        }
    }
}