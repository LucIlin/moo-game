namespace MooGame.App.Extensions;

public static class StringExtensions
{
    public static bool IsLengthNotFour(this string numberString)
    {
        return numberString.Length != 4;
    }
}


