using MooGame.App.Controller;
using MooGame.App.Helper;
using MooGame.App.Interfaces;
using MooGame.App.Model;

namespace MooGame.Tests.Mocks;

public class MockGameFactory : IGameFactory
{
    public IUserInputHandler UserInput { get; set; }

    public MockGameFactory(IUserInputHandler userInput)
    {
        UserInput = userInput;
    }
    public IGameController CreateGame()
    {
        var mockGen = new MockNumberGenerator("1234");
        var mooGame = new MooGameEngine(mockGen);
        return new GameController(mooGame, UserInput);
    }
}
