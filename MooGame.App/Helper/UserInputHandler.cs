using System.Text.RegularExpressions;

namespace MooGame.App.Helper;

public static class UserInputHandler
{
    public static bool IsValidChars(string? input)
    {   
        if (string.IsNullOrEmpty(input)) throw new ArgumentException("Input is Null or Empty");
        
        if (input.Length > 25) throw new ArgumentException("Input length larger than 25 characters.");
        
        if (!Regex.IsMatch(input, @"^[a-zA-Z0-9!""#$%&'()*+, \-./:;<=>?@[\\\]^_`{|}~]+$")) throw new ArgumentException("Invalid characters");
        
        return true;
    }

    public static bool IsYesNo(string input)
    {
        input = input.ToLower();

        return input is "n" or "y";
    }

}