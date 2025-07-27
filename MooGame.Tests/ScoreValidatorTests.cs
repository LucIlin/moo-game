using MooGame.App;
using System.ComponentModel.DataAnnotations;
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
        var expectedResults = new List<string> { "BBB", "BB CC", "BBBB" };

        //Act
        var results = guesses.Select(guess => validator.CheckGuess(targetNumber, guess)).ToList();

        //Assert
        CollectionAssert.AreEqual(expectedResults, results);
    }


    [TestMethod]
    [TestCategory("Not Implemented")]
    public void CheckGuess_ReturnsCorrectBullCount_WhenDigitsAreInCorrectPosition()
    {
        // Arrange
        var validator = new ScoreValidator();
        var target = "1234";

        // Act + Assert
        Assert.AreEqual("B", validator.CheckGuess(target, "1555"));   // Only '1' is correct and in the correct place
        Assert.AreEqual("BB", validator.CheckGuess(target, "1275"));  // '1' and '2' are in correct positions
        Assert.AreEqual("BBBB", validator.CheckGuess(target, "1234")); // All correct
        Assert.AreEqual("", validator.CheckGuess(target, "5678"));    // No bulls or cows
    }
}




