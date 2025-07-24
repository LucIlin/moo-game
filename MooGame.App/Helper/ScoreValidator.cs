using MooGame.App.Extensions;

namespace MooGame.App.Helper;

public class ScoreValidator
{
    public ScoreValidator()
    {

    }
 
    public string CheckGuess(string targetNumber, string playerGuess)
    {

        var scoreResult = CalculateScore(targetNumber, playerGuess);

        return Score(scoreResult.Bulls, scoreResult.Cows);
    }

    private ScoreResult CalculateScore(string targetNumber, string playerGuess)
    {
        var result = new ScoreResult();
        var remainingTargetDigits = new List<char>();
        var remainingGuessDigits = new List<char>();

        for (int index = 0; index < 4; index++)
        {
            if (CompareTargetNumberAndPlayerGuessByIndex(targetNumber, playerGuess, index))
            {
                result.Bulls++;
            }
            else
            {
                remainingTargetDigits.Add(targetNumber[index]);
                remainingGuessDigits.Add(playerGuess[index]);
            }
        }

        foreach (char guessDigit in remainingGuessDigits)
        {
            if (remainingTargetDigits.Remove(guessDigit))
                result.Cows++;
        }

        return result;
    }

    private bool CompareTargetNumberAndPlayerGuessByIndex(string targetNumber, string playerGuess, int index)
    {
        return targetNumber[index] == playerGuess[index];
    }

    private string Score(int bulls, int cows)
    {
        return $"{new string('B', bulls)}{(cows > 0 ? " " + new string('C', cows) : "")}";
    }
}

public class ScoreResult
{
    public int Bulls { get; set; }
    public int Cows { get; set; }
}