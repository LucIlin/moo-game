using MooGame.App.Helper;

namespace MooGame.App.Interfaces;

public interface IGameFactory
{
    IUserInputHandler UserInput { get; set; }
    IGameController CreateGame();
}