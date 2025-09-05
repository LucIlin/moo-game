using MooGame.App.Helper;
using MooGame.App.Interfaces;

namespace MooGame.Tests.Mocks;

internal class MockGameController : IGameController
{
    private readonly IUserInputHandler _io;
    public MockGameController(IUserInputHandler io)
    {
        _io = io;
    }
    public void PlayGame()
    {
        _io.WriteOutput("DUMMY game is played");
    }
}