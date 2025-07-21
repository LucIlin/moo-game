using MooGame.App.Extensions;

namespace MooGame.Tests;

public class ScoreValidator
{
    public ScoreValidator()
    {

    }
    //public string CheckGuess(string targetNumber, string playerGuess)
    //{
    //    string bullScore = "BBBB";
    //    string cowScore = "CCCC";

    //    int cows = 0, bulls = 0;
    //    //playerGuess += "    ";     // if player entered less than 4 chars
    //    for (int i = 0; i < 4; i++)
    //    {
    //        for (int j = 0; j < 4; j++) //Implementera felhantering på längden av gissningen, om den är inom "range"
    //        {
    //            if (targetNumber[i] == playerGuess[j])
    //            {
    //                if (i == j)
    //                {
    //                    bulls++;
    //                }
    //                else
    //                {
    //                    cows++;
    //                }
    //            }
    //        }
    //    }
    //    return $"{bullScore.Substring(0, bulls)} {cowScore.Substring(0, cows)}".TrimEnd();
    //}



    public string CheckGuess(string targetNumber, string playerGuess)
    {
        if (targetNumber.IsLengthNotFour() || playerGuess.IsLengthNotFour())
        {
            throw new ArgumentException("Both numbers must be exactly 4 digits.");
        }

        (int bulls, int cows) = CalculateScore(targetNumber, playerGuess);

        return Score(bulls, cows);
    }

    private string Score(int bulls, int cows)
    {
        return $"{new string('B', bulls)}{(cows > 0 ? " " + new string('C', cows) : "")}";
    }

    private (int, int) CalculateScore(string targetNumber, string playerGuess)
    {
        int bulls = 0, cows = 0;
        var unmatchedTarget = new List<char>();
        var unmatchedGuess = new List<char>();

        for (int i = 0; i < 4; i++)
        {
            if (CompareTargetNumberAndPlayerGuessByIndex(targetNumber, playerGuess, i))
            {
                bulls++;
            }
            else
            {
                unmatchedTarget.Add(targetNumber[i]);
                unmatchedGuess.Add(playerGuess[i]);
            }
        }

        foreach (char guessChar in unmatchedGuess)
        {
            if (unmatchedTarget.Remove(guessChar))
                cows++;
        }

        return (bulls, cows);
    }

    private bool CompareTargetNumberAndPlayerGuessByIndex(string targetNumber, string playerGuess, int index)
    {
        return targetNumber[index] == playerGuess[index];
    }
}


