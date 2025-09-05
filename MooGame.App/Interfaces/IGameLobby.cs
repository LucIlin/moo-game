using MooGame.App.Model;

namespace MooGame.App.Interfaces
{
    public interface IGameLobby
    {
        public void CreatePlayer();
        public IGameController SelectGame();
    }
}