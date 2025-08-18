using MooGame.App.Extensions;

namespace MooGame.App.Helper;

public class MooGameScoreValidator
{
    public MooGameScoreValidator()
    {

    }
 
    public bool CheckGuess(string targetNumber, string playerGuess)
    {
        var scoreResult = CalculateScore(targetNumber, playerGuess);

        return Score(scoreResult.Bulls, scoreResult.Cows);
    }

    private MooScoreResult CalculateScore(string targetNumber, string playerGuess)
    {
        var result = new MooScoreResult();
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

    private bool Score(int bulls, int cows)
    {
        return $"{new string('B', bulls)}{(cows > 0 ? " " + new string('C', cows) : "")}" == "BBBB";
    }
}

public class MooScoreResult
{
    public int Bulls { get; set; }
    public int Cows { get; set; }
}