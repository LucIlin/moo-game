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
        private PlayerData _playerData;
        private readonly IUserInput _io;
        public GameLobby(IUserInput io) 
        {
            _io = io;
        }
        public void CreatePlayer()
        {
            AskPlayerForName();
            string playerAnswer = _io.GetInput();
            _playerData = new PlayerData(playerAnswer, 1);
            _io.WriteOutput($"Hello there, {_playerData.Name}");

        }
        private void AskPlayerForName() => _io.WriteOutput("Enter your user name:");
    }
}
