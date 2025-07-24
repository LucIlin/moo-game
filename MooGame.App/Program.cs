using MooGame.App;
namespace MooGame;

class Program //Program //testtest
{

    public static void Main(string[] args)
    {
        var app = new AppController(new ConsoleIO(), new RandomMooNumberGenerator(), new GameController());
        app.Run(/*game*/);
    }
}