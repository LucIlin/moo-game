using MooGame.App.Helper;
using MooGame.App.Model;

namespace MooGame.App.Interfaces;

public interface IGameFactory
{
    IUserInputHandler UserInput { get; set; }
    IGameController CreateGame(Player player);
    IGameLobby CreateGameLobby();
}