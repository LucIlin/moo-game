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
    public void Test_RunApplication_CorrectOutputsFromVoidMethodsInside() 
    {
        //Arrange
        string[] inputs = { "alex", "1", "1234", "n" };
        var userInputs = new Queue<string>(inputs);
        var io = new MockIO(userInputs);

        var userInputHandler = new UserInputHandler(io);

        var gameFactory = new MockGameFactory(userInputHandler);

        var app = new AppController(gameFactory);

        //Act
        app.RunApplication();

        var expectedOutputs = new[] { "DUMMY player created", "DUMMY game is played" };
        var actualOutputs = io.Outputs.ToArray();

        //Assert
        CollectionAssert.AreEqual(expectedOutputs, actualOutputs);
    }

    [TestMethod]
    [TestCategory("Status:Done")]
    public void Test_RunApplication_SelectGameReturnsCorrectController()
    {
        //Arrange
        string[] inputs = { "alex", "1", "1234", "n" };
        var userInputs = new Queue<string>(inputs);
        var io = new MockIO(userInputs);

        var userInputHandler = new UserInputHandler(io);
        
        var gameFactory = new MockGameFactory(userInputHandler);

        var app = new AppController(gameFactory);

        //Act
        app.RunApplication();

        var actuaLobby = (MockGameLobby)gameFactory.LastCreatedLobby;
        var actualController = actuaLobby.LastReturnedController;


        //Assert
        Assert.IsNotNull(actualController);
        Assert.IsInstanceOfType(actualController, typeof(IGameController));
        Assert.IsInstanceOfType(actualController, typeof(MockGameController));
    }
}