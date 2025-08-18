using MooGame.App.Helper;
using MooGame.App.Interfaces;

namespace MooGame.App.Controller;

public class AppController
{
    private IGame _game;
    public AppController(IGame game)
    {
        _game = game;
    }
    public void RunApplication()
    {
        _game.RunGame();
    }
}
