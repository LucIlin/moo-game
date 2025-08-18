using MooGame.App;
using MooGame.App.Controller;
using MooGame.App.Helper;
using MooGame.App.View;
namespace MooGame;

public class Program
{
    public static void Main(string[] args)
    {
        var io = new ConsoleIO();
        var numberGenerator = new RandomMooNumberGenerator();
        var mooGame = new MooGameApp(numberGenerator, io);
        var app = new AppController(mooGame);

        app.RunApplication();
    }
}