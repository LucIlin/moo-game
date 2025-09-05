using MooGame.App.Controller;
using MooGame.App.Helper;
using MooGame.App.Model;
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
            string[] userInputs = { "1234", "n", "n"};
            var userIO = MockHelpers.CreateUserInputHandler(userInputs);
            var game = MockHelpers.CreateMockGame("1234");
            var player = new Player("alex", 1);
            var controller = new GameController(game, userIO, player);
            //Act
            controller.PlayGame();

            //Assert
            Assert.IsTrue(game.IsRoundOver);
        }

        [DataTestMethod]
        [DoNotParallelize]
        [TestCategory("Status:Done")]
        [TestCategory("Component:GameController")]
        [DataRow("INSTRUCTIONS")]
        [DataRow("RESULT DUMMY")]
        [DataRow("Correct, it took 1 guesses")]
        [DataRow("Would you like to see the scoreboard? (y/n)")]
        [DataRow("Would you like to play again? (y/n)")]
        public void Test_PlayGame_OutputsAreCorrect(string expectedOutput) //Fick hjälp av ai att lösa det här då Scoreboard är hårdkopplat till gamecontroller
        {
            var originalCwd = Environment.CurrentDirectory;
            var tempCwd = Path.Combine(Path.GetTempPath(), "MooGameTests", Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(tempCwd);
            Environment.CurrentDirectory = tempCwd; 

            try
            {
                var io = new MockIO(new Queue<string>(new[] { "1234", "n", "n" }));
                var userInputHandler = new UserInputHandler(io);
                var game = MockHelpers.CreateMockGame("1234");
                var player = new Player("alex", 1);
                var controller = new GameController(game, userInputHandler, player);

                controller.PlayGame();

                Assert.IsTrue(io.Outputs.Any(o => o.Contains(expectedOutput)), $"Missing output: {expectedOutput}");
            }
            finally
            {
                Environment.CurrentDirectory = originalCwd;
            }
        }


        [TestMethod]
        [TestCategory("Status:Done")]
        [TestCategory("Component:GameController")]
        public void Test_PlayGame_CorrectNumberOfGuesses()
        {
            //Arrange
            string[] userInputs = { "1235", "1234", "n", "n" };
            var userIO = MockHelpers.CreateUserInputHandler(userInputs);
            var game = MockHelpers.CreateMooGame("1234");
            var player = new Player("alex", 1);
            var controller = new GameController(game, userIO, player);
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
            var inputs = new[] { "x", "12", "abcd", "1234", "n", "n" };
            var userIO = MockHelpers.CreateUserInputHandler(inputs);
            var game = MockHelpers.CreateMockGame("1234");
            var player = new Player("alex", 1);
            var controller = new GameController(game, userIO, player);
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
        public void PlayGame_TwoRounds_FirstYThenNo()
        {   
            //Arrange
            var inputs = new[] { "1234", "n", "y", "1234", "n", "n" };
            var userIO = MockHelpers.CreateUserInputHandler(inputs);
            MockGame game = MockHelpers.CreateMockGame("1234");
            var player = new Player("alex", 1);
            var controller = new GameController(game, userIO, player);
            var expectedStartCount = 2;

            //Act
            controller.PlayGame();
            var actualStartCounts = game.StartRoundCalls;

            //Assert
            Assert.AreEqual(expectedStartCount, actualStartCounts);
        }
    }
}