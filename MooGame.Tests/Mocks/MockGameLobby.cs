using MooGame.App.Helper;
using MooGame.App.Interfaces;
using MooGame.App.Model;

namespace MooGame.Tests.Mocks;

internal class MockGameLobby : IGameLobby
{
    private readonly IUserInputHandler _io;
    public Player LastCreatedPlayer { get; private set; }
    public IGameController? LastReturnedController { get; private set; }
    public MockGameLobby(IUserInputHandler io)
    {
        _io = io;
    }
    public Player CreatePlayer()
    {
        LastCreatedPlayer = new Player("DUMMY", 1);
        return LastCreatedPlayer;
    }

    public IGameController InitializeGame(Player player)
    {
        LastReturnedController = new MockGameController(_io);
        return LastReturnedController;
    }
}
