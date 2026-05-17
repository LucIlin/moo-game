using MooGame.App.Model;

namespace MooGame.App.Interfaces;

public interface IScoreboard
{
    void WriteResult(string playerName, int guesses);

    IReadOnlyList<Player> GetPlayers();

    void Print(int top = 10);
}