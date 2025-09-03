using MooGame.App.Controller;
using MooGame.App.Helper;
using MooGame.Tests.Mocks;

namespace MooGame.Tests.Tests
{
    [TestClass()]
    public class GameControllerTests
    {

        [TestMethod]
        [TestCategory("Status:Done")]
        [TestCategory("Component:GameController")]
        public void Test_PlayGame_CorrectGuess_ThenExitGame()
        {
            //Arrange
            string[] userInputs = { "1234", "n" };
            var userIO = MockHelpers.CreateUserInputHandler(userInputs);
            var game = MockHelpers.CreateMockGame("1234");
            var controller = new GameController(game, userIO);
            //Act
            controller.PlayGame();

            //Assert
            Assert.IsTrue(game.IsRoundOver);
        }

        [DataTestMethod]
        [TestCategory("Status:Done")]
        [TestCategory("Component:GameController")]
        [DataRow("INSTRUCTIONS")]
        [DataRow("Continue? y/n")]
        [DataRow("Correct, it took 1 guesses")]
        public void Test_PlayGame_OutputsAreCorrect(string output)
        {
            //Arrange
            var userInputs = new Queue<string>(new[] { "1234", "n" });
            var io = new MockIO(userInputs);
            var userInputHandler = new UserInputHandler(io);
            var game = MockHelpers.CreateMockGame("1234");
            var controller = new GameController(game, userInputHandler);

            //Act
            controller.PlayGame();

            //Assert
            Assert.IsTrue(io.Outputs.Any(o => o.Contains(output)));
            Assert.IsTrue(io.Outputs.Any(o => o.Contains(output)));
            Assert.IsTrue(io.Outputs.Any(o => o.Contains(output)));
        }

        [TestMethod]
        [TestCategory("Status:Done")]
        [TestCategory("Component:GameController")]
        public void Test_PlayGame_CorrectNumberOfGuesses()
        {
            //Arrange
            string[] userInputs = { "1235", "1234", "n" };
            var userIO = MockHelpers.CreateUserInputHandler(userInputs);
            var game = MockHelpers.CreateMooGame("1234");
            var controller = new GameController(game, userIO);
            var expectedGuessCount = 2;

            //Act
            controller.PlayGame();
            var actualGuessCount = game.GuessCount;

            //Assert
            Assert.AreEqual(expectedGuessCount, actualGuessCount);
        }

        [TestMethod]
        [TestCategory("Status:Done")]
        [TestCategory("Component:GameController")]
        public void PlayGame_InvalidInputs_DoNotCount()
        {
            //Arrange
            var inputs = new[] { "x", "12", "abcd", "1234", "n" };
            var userIO = MockHelpers.CreateUserInputHandler(inputs);
            var game = MockHelpers.CreateMockGame("1234");
            var controller = new GameController(game, userIO);
            var expectedGuessCount = 1;

            //Act
            controller.PlayGame();
            var actualGuessCount = game.GuessCount;

            //Assert
            Assert.AreEqual(expectedGuessCount, actualGuessCount);
        }

        [TestMethod]
        [TestCategory("Status:Done")]
        [TestCategory("Component:GameController")]
        public void PlayGame_TwoRounds_WhenYThenN()
        {   
            //Arrange
            var inputs = new[] { "1234", "y", "1234", "n" };
            var userIO = MockHelpers.CreateUserInputHandler(inputs);
            MockGame game = MockHelpers.CreateMockGame("1234");
            var controller = new GameController(game, userIO);
            var expectedStartCount = 2;

            //Act
            controller.PlayGame();
            var actualStartCounts = game.StartRoundCalls;

            //Assert
            Assert.AreEqual(expectedStartCount, actualStartCounts);
        }
    }
}