using MooGame.App;
using MooGame.Tests.Mocks;

namespace MooGame.Tests;



[TestClass]
public sealed class AppTest
{
    [TestMethod]
    [TestCategory("Not Implemented")]
    public void TestGameFlow_GuessUntilCorrectAndExit()
    {
        // Arrange
        var inputs = new Queue<string>(new[]
        {
        "lucas",       // username
        "1230",        // first guess - wrong
        "1234",        // second guess - correct
        "n"            // continue? no
        });

        var mockIO = new MockIO(inputs);
        var mockNumberGenerator = new MockNumberGenerator("1234"); // always return 1234
        var controller = new AppController(mockIO, mockNumberGenerator);

        // Act
        controller.Run();

        // Assert - you should replace the exact strings with whatever your bulls and cows logic returns.
        Assert.IsTrue(mockIO.Outputs.Contains("Enter your user name:\n"));
        Assert.IsTrue(mockIO.Outputs.Contains("New game:\n"));
        Assert.IsTrue(mockIO.Outputs.Contains("For practice, number is: 1234\n"));

        // Bulls and Cows feedback
        Assert.IsTrue(mockIO.Outputs.Contains("BBB,\n"));  // First guess: 1230
        Assert.IsTrue(mockIO.Outputs.Contains("BBBB,\n")); // Second guess: 1234

        // Final confirmation
        Assert.IsTrue(mockIO.Outputs.Contains("Correct, it took 2 guesses\nContinue?"));
    }
}
