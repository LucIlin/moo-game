using MooGame.App.Helper;
using MooGame.App.Interfaces;

namespace MooGame.App.View;

public class ConsoleIO : IInputOutput
{
    public string? ReadInput() => Console.ReadLine();

    public void WriteOutput(string message) => Console.WriteLine(message + "\n");
}
