namespace MooGame.App;

public class ConsoleIO : IInputOutput
{
    public string ReadInput() => Console.ReadLine() ?? string.Empty;
    public void WriteOutput(string message) => Console.WriteLine(message);
}
