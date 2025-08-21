using MooGame.App;
using MooGame.App.Controller;
using MooGame.App.Helper;
using MooGame.App.View;
using MooGame.App.Model;
namespace MooGame.App;

public class Program
{
    public static void Main(string[] args)
    {
        var io = new ConsoleIO();
        var numberGenerator = new RandomMooNumberGenerator();
        var mooGame = new MooGameEngine(numberGenerator);
        var controller = new GuessingGameController(mooGame, io);
        var app = new AppController(controller, new GameLobby(io));

        app.RunApplication();
    }
}