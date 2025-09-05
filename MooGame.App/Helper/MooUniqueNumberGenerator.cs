using MooGame.App.Interfaces;

namespace MooGame.App.Helper;

public class MooUniqueNumberGenerator : INumberGenerator
{
    Random _randomGenerator = new Random();

    public string GenerateNumber(int length)
    {
        if (length < 1 || length > 10)
            throw new ArgumentOutOfRangeException(nameof(length), "Length must be 1..10 when digits are unique.");

        string targetNumber = string.Empty;
        for (int i = 0; i < length; i++)
        {
            string randomDigit = GetUniqueDigit(targetNumber);
            targetNumber += randomDigit;
        }
        return targetNumber;
    }

    private string GetUniqueDigit(string targetNumber)
    {
        int randomNumber = _randomGenerator.Next(10);
        string randomDigit = randomNumber.ToString();
        while (targetNumber.Contains(randomDigit))
        {
            randomNumber = _randomGenerator.Next(10);
            randomDigit = randomNumber.ToString();
        }

        return randomDigit;
    }
}
