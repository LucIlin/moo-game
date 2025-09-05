using MooGame.App.Controller;
using MooGame.App.Helper;
using MooGame.App.Interfaces;
using MooGame.App.Model;
using System.Diagnostics;

namespace MooGame.Tests.Mocks;

internal class MockGameFactory : IGameFactory
{
    public IUserInputHandler UserInput { get; set; }
    public IGameLobby LastCreatedLobby { get; private set; }
    public MockGameFactory(IUserInputHandler userInput)
    {
        UserInput = userInput;
    }
    public IGameController CreateGame(Player player)
    {
        var mockGen = new MockNumberGenerator("1234");
        var mooGame = new MooGameEngine(mockGen);
        return new GameController(mooGame, UserInput, player);
    }

    public IGameLobby CreateGameLobby()
    {
        LastCreatedLobby = new MockGameLobby(UserInput);
        return LastCreatedLobby;
    }
}
