using MooGame.App.Interfaces;
using MooGame.App.Model;

namespace MooGame.App.Controller;

public class AppController
{
    private readonly IGameController _gameController;
    private readonly IGameLobby _gameLobby;
    public AppController(IGameController gameController, IGameLobby gameLobby)
    {
        _gameController = gameController;
        _gameLobby = gameLobby;
    }
    public void RunApplication()
    {
        _gameLobby.CreatePlayer();
        _gameController.PlayGame();
    }
}
