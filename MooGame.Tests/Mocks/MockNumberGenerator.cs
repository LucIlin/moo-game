using MooGame.App.Interfaces;

namespace MooGame.Tests.Mocks;

internal class MockNumberGenerator : IGuessGenerator
{
    string _number {  get; set; }
    public MockNumberGenerator(string desiredNumber)
    {
        _number = desiredNumber;
    }
    public string GenerateGuess()
    {
        return _number;
    }
}