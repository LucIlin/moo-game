using MooGame.App.Controller;
using MooGame.App.Helper;
using MooGame.App.Interfaces;

namespace MooGame.App.Model;

public class GameFactory : IGameFactory
{
    public IUserInputHandler UserInput { get; set; }

    public GameFactory(IUserInputHandler userInput) 
    {
        UserInput = userInput;
    }

    public IGameController CreateGame()
    {
        var numberGenerator = new MooUniqueNumberGenerator();
        IGame game = new MooGameEngine(numberGenerator);
        return new GameController(game, UserInput);
    }
}
