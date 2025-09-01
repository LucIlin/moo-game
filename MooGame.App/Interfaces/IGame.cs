using MooGame.App.Helper;

namespace MooGame.App.Interfaces;


public interface IGame
{
    public int GuessCount { get; set; }
    public bool IsRoundOver { get; set; }
    public void StartRound();
    public IScoreResult HandleGuess(string guess);
    bool CheckForGuess(string guess);
}
