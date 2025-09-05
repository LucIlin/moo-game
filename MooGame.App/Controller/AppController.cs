using MooGame.App.Helper;
using MooGame.App.Interfaces;
using MooGame.App.Model;
using System.Runtime.CompilerServices;

namespace MooGame.App.Controller;

public class AppController
{
    private readonly IGameLobby _gameLobby;
    public AppController(IGameFactory factory)
    {
        _gameLobby = factory.CreateGameLobby();
    }
    public void RunApplication()
    {
        _gameLobby.CreatePlayer();
        var gameController = _gameLobby.SelectGame();
        gameController.PlayGame();
    }
}
