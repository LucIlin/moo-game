using MooGame.App.Helper;
using MooGame.App.Interfaces;

namespace MooGame.Tests.Mocks;

internal class MockGameLobby : IGameLobby
{
    private readonly IUserInputHandler _io;
    private readonly IGameFactory _gameFactory;
    public IGameController? LastReturnedController { get; private set; }
    public MockGameLobby(IUserInputHandler io, IGameFactory gameFactory)
    {
        _io = io;
        _gameFactory = gameFactory;
    }
    public void CreatePlayer()
    {
        _io.WriteOutput("DUMMY player created");
    }

    public IGameController SelectGame()
    {
        LastReturnedController = new MockGameController(_io);
        return LastReturnedController;
    }
}
