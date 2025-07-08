using MooGame.App;
namespace MooGame.Tests;

[TestClass]
[TestCategory("Not Implemented")]
public sealed class ScoreValidatorTests
{
    [TestMethod]
    [TestCategory("Not Implemented")]
    public void Test_CheckScore_ResultMatchesScore()
    {
        //Arrange
        var validator = new ScoreValidator();
        var targetNumber = "1234";
        var guesses = new List<string>(new[] { "1233", "1243", "1234" });
        var expectedResults = new List<string> { "BBB ", "BB CC", "BBBB" };

        //Act
        var results = guesses.Select(guess => validator.CheckGuess(targetNumber, guess)).ToList();

        //Assert
        CollectionAssert.AreEqual(expectedResults, results);
    }


    [TestMethod]
    [TestCategory("Not Implemented")]
    public void Test_CheckScore_ValidatesBullsCorrectly()
    {
        //Arrange
        var validator = new ScoreValidator();
        var targetNumber = "1234";
        var guesses = new Queue<string>(new[] { "1233", "1232", "1234"});

        //Act
        foreach (var guess in guesses)
        {
            validator.CheckGuess(targetNumber, guesses.Dequeue());
        }
        //Assert
        Assert.Fail();

    }
}




