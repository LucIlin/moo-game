namespace MooGame.App;

public class ConsoleIO : IInputOutput
{
    public string ReadInput()
    {
        var input = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
        return input;
    }

    public void WriteOutput(string message) => Console.WriteLine(message);
}
