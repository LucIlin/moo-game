using MooGame.App.Helper;
using MooGame.App.Interfaces;
using System.Diagnostics;

namespace MooGame.Tests;

internal class MockIO : IInputOutput
{
    Queue<string> _mockInputs { get; set; }
    public List<string> Outputs { get; set; } = new List<string>();

    public MockIO(Queue<string> mockInputs)
    {
        _mockInputs = mockInputs;
    }

    public string ReadInput() => _mockInputs.Count > 0 ? _mockInputs.Dequeue() : string.Empty;

    public void WriteOutput(string output)
    {
        Outputs.Add(output);
        Debug.WriteLine(output);
    }
}