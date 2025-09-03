using MooGame.App.Controller;
using MooGame.Tests.Mocks;

namespace MooGame.Tests.Tests;
[TestClass]

public sealed class AppControllerTests
{
    [TestMethod]
    [TestCategory("Not Done")]
    public void Test_CanRunProgram()
    {
        //Arrange
        string[] inputs = { "luke", "1", "1234", "n" };
        var userIO = MockHelpers.CreateUserInputHandler(inputs);
        var gameFactory = new MockGameFactory(userIO);
        var app = new AppController(gameFactory);

        //Act
        app.RunApplication();

        //Assert
        Assert.IsFalse(true);
    }
}