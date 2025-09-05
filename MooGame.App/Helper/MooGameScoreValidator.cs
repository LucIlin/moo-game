using MooGame.App.Interfaces;
using MooGame.App.Model;

namespace MooGame.App.Helper;

public class MooGameScoreValidator
{
    private const string correctResult = "BBBB";

    public MooGameScoreValidator()
    {

    }
 
    public MooScoreResult CheckGuess(string playerGuess, string targetNumber)
    {
        var scoreResult = CalculateScore(targetNumber, playerGuess);

        return scoreResult;
    }

    public bool IsGuessCorrect(IScoreResult scoreResult)
    {
        return scoreResult.ToString() == correctResult;
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

    private bool CompareTargetNumberAndPlayerGuessByIndex(string? targetNumber, string playerGuess, int index)
    {
        return targetNumber?[index] == playerGuess[index];
    }
}
