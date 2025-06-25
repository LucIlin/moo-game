namespace MooGame.App;

//TODO Validate
public class UserInputHandler : ISanitizer
{
    private HashSet<string> _validCommands { get; }

    public UserInputHandler(HashSet<string> commands)
    {
        _validCommands = commands;
    }
    public bool Validate(string input)
    {   
        if (string.IsNullOrEmpty(input)) throw new ArgumentException("Input is Null or Empty");
        
        if (input.Length > 25) throw new ArgumentException("Input length larger than 25 characters.");
        
        if (!_validCommands.Contains(input)) throw new ArgumentException("Invalid command");

        return true;
    }
}