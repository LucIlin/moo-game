using System.Diagnostics;
using System.Text.RegularExpressions;
using MooGame.App.Interfaces;

namespace MooGame.App.Helper;

public class UserInputHandler : IUserInput
{
    private IInputOutput _io;
    public UserInputHandler(IInputOutput io)
    {
        _io = io;
    }
    private static (bool, string?) IsValidChars(string? input)
    {   
        if (string.IsNullOrEmpty(input)) return (false, "Input is Null or Empty");
        
        if (input.Length > 25) return (false, "Input length larger than 25 characters.");
        
        if (!Regex.IsMatch(input, @"^[a-zA-Z0-9!""#$%&'()*+, \-./:;<=>?@[\\\]^_`{|}~]+$")) 
            return (false, "Invalid characters");
        
        return (true, null);
    }

    /// <summary>
    /// Returns true for "Yes" and false for "No", throws argument exception if input is not N,n or Y,y.
    /// </summary>
    public bool GetYesNo(string? question = null)
    {
        Func<string, bool> validator = x => x is "y" or "n";
        
        var input = GetInput(prompt: question, customValidator: validator, errorMessage:"Input is not \"n\" or \"y\"");

        if (input is "y")
            return true;
        if (input is "n")
            return false;
        
        throw new UnreachableException($"Unexpected input: {input}");
    }

    public string GetInput(
        string? prompt = null,
        string? errorMessage = null,
        Func<string, bool>? customValidator = null
        )
    {
        bool isResolved = false;
        string input  = string.Empty;
        
        if (prompt != null)
            _io.WriteOutput(prompt);
        
        while (!isResolved)
        {
            input = _io.ReadInput() ?? "";
            
            var (isValidInput, error) = IsValidChars(input);

            if (!isValidInput)
            {
                var charValidationError = error ?? "Invalid characters";
                _io.WriteOutput(charValidationError);
                continue;
            }
            
            if (customValidator != null)
            {
                var isCustomValidated = customValidator(input);

                if (!isCustomValidated)
                {
                    _io.WriteOutput(errorMessage ?? "Invalid characters");
                    continue;
                }
            }
            
            isResolved = true;
        }

        return input;
    }
}