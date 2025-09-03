using MooGame.App.Controller;
using MooGame.App.Helper;
using MooGame.App.Interfaces;
using MooGame.App.Model;
using MooGame.App.View;
namespace MooGame.App;

public class Program
{
    public static void Main(string[] args)
    {
        IInputOutput io = new ConsoleIO();
        IUserInputHandler userInputHandler = new UserInputHandler(io);
        IGameFactory gameFactory = new GameFactory(userInputHandler);
        var app = new AppController(gameFactory);

        try
        {
            app.RunApplication();
        }
        catch (Exception e)
        {
            io.WriteOutput(e.Message);
        }
    }
}