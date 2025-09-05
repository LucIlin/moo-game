using MooGame.App;
using MooGame.App.Helper;
using MooGame.App.Model;
using System.ComponentModel.DataAnnotations;
namespace MooGame.Tests;

[TestClass]
public sealed class ScoreValidatorTests
{
    [DataTestMethod]
    [TestCategory("Status:Done")]
    [TestCategory("Component:ScoreValidator")]
    [DataRow("1233", 3, 0)]
    [DataRow("1243", 2, 2)]
    [DataRow("1234", 4, 0)]
    public void CheckGuess_ReturnsExpectedAmount_BullsAndCows(string guess, int bulls, int cows)
    {
        var validator = new MooGameScoreValidator();
        var result = validator.CheckGuess("1234", guess);
        Assert.AreEqual(bulls, result.Bulls);
        Assert.AreEqual(cows, result.Cows);
    }


    [DataTestMethod]
    [TestCategory("Status:Done")]
    [TestCategory("Component:ScoreValidator")]
    [DataRow("1555", "B")]
    [DataRow("1275", "BB")]
    [DataRow("1234", "BBBB")]
    [DataRow("1432", "BBCC")]
    [DataRow("5678", "")]
    public void CheckGuess_ReturnsExpectedStringResult(string guess, string expectedResult)
    {
        // Arrange
        var validator = new MooGameScoreValidator();
        var target = "1234";

        // Act
        var actualResult = validator.CheckGuess(target, guess).ToString();

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

}




