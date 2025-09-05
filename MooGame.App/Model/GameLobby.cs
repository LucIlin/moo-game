using MooGame.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MooGame.App.Helper;

namespace MooGame.App.Model
{
    public class GameLobby : IGameLobby
    {
        private Player _player;
        private readonly IUserInputHandler _io;
        private IGameFactory _gameFactory;
        public GameLobby(IUserInputHandler io, IGameFactory gameFactory) 
        {
            _io = io;
            _gameFactory = gameFactory;
        }

        public IGameController SelectGame()
        {
            _io.WriteOutput("Please select game:\n1. MooGame\n2. Close Application");
            string input = _io.GetInput();

            if (input != "1")
                throw new Exception("Game will now close");

            return _gameFactory.CreateGame(_player);
        }

        public IGameController InitializeGame()
        {
            CreatePlayer();
            return SelectGame();
        }

        public void CreatePlayer()
        {
            AskPlayerForName();
            string playerAnswer = _io.GetInput();
            _player = new Player(playerAnswer, 1);
            _io.WriteOutput($"Hello there, {_player.Name}");

        }
        private void AskPlayerForName() => _io.WriteOutput("Enter your user name:");
      
    }
}
