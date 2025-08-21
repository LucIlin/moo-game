using MooGame.App.Interfaces;

namespace MooGame.App.Model;

public class MooScoreResult : IScoreResult
{
    public bool IsSuccess { get; set; }
    public int Bulls { get; set; }
    public int Cows { get; set; }

    public override string ToString()
    {
        return $"{new string('B', Bulls)}{(Cows > 0 ? new string('C', Cows) : "")}";
    }
}