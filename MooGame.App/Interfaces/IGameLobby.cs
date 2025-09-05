using MooGame.App.Model;

namespace MooGame.App.Interfaces
{
    public interface IGameLobby
    {
        public Player CreatePlayer();
        public IGameController InitializeGame(Player player);
    }
}