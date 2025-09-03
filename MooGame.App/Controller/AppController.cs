using MooGame.App.Helper;
using MooGame.App.Interfaces;
using MooGame.App.Model;
using System.Runtime.CompilerServices;

namespace MooGame.App.Controller;

public class AppController
{
    private readonly GameLobby _gameLobby;
    public AppController(IGameFactory factory)
    {
        _gameLobby = new GameLobby(factory.UserInput, factory);
    }
    public void RunApplication()
    {
        _gameLobby.CreatePlayer();
        var gameController = _gameLobby.SelectGame();
        gameController.PlayGame();
    }
}
