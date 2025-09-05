using MooGame.App.Controller;
using MooGame.App.Helper;
using MooGame.App.Interfaces;
using MooGame.Tests.Mocks;

namespace MooGame.Tests.Tests;


[TestClass]
[TestCategory("Component:AppController")]
public sealed class AppControllerTests
{
    [TestMethod]
    [TestCategory("Status:Done")]
    public void Test_RunApplication_CreatePlayer_ReturnsDummyPlayer()
    {
        // Arrange
        var inputs = new[] { "alex", "1", "1234", "n" };
        var io = new MockIO(new Queue<string>(inputs));
        var userInputHandler = new UserInputHandler(io);
        var gameFactory = new MockGameFactory(userInputHandler);
        var app = new AppController(gameFactory);

        // Act
        app.RunApplication();
        var lobby = (MockGameLobby)gameFactory.LastCreatedLobby;
        var player = lobby.LastCreatedPlayer;

        // Assert
        Assert.IsNotNull(player, "CreatePlayer should return a Player.");
        Assert.AreEqual("DUMMY", player.Name, "Player name should be DUMMY.");
    }

    [TestMethod]
    [TestCategory("Status:Done")]
    public void Test_RunApplication_InitializeGame_ReturnsCorrectController_TypeAndInterface()
    {
        // Arrange
        var inputs = new[] { "alex", "1", "1234", "n", "n" };
        var io = new MockIO(new Queue<string>(inputs));
        var userInputHandler = new UserInputHandler(io);
        var gameFactory = new MockGameFactory(userInputHandler);
        var app = new AppController(gameFactory);

        // Act
        app.RunApplication();

        // Assert
        var lobby = (MockGameLobby)gameFactory.LastCreatedLobby;
        var controller = lobby.LastReturnedController;
        Assert.IsNotNull(controller, "InitializeGame should return a controller.");
        Assert.IsInstanceOfType(controller, typeof(IGameController));
        Assert.IsInstanceOfType(controller, typeof(MockGameController));
    }
}