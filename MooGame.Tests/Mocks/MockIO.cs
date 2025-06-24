using System.Diagnostics;
using MooGame.App;

namespace MooGame.Tests;

internal class MockIO : IInputOutput
{
    Queue<string> _mockInputs { get; set; }
   
    public MockIO(Queue<string> mockInputs)
    {
        _mockInputs = mockInputs;
    }

    public string ReadInput() => _mockInputs.Count > 0 ? _mockInputs.Dequeue() : string.Empty;

    public void WriteOutput(string output) => Debug.WriteLine(output);
}