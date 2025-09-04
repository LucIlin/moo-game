using MooGame.App.Helper;

namespace MooGame.App.Interfaces;


public interface IGame
{
    public int GuessCount { get; }
    public bool IsRoundOver { get; }
    public void StartRound();
    public string GetInstructions();
    public IScoreResult HandleGuess(string guess);
    bool IsValidGuess(string guess);
}
