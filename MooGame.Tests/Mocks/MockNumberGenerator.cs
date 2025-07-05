namespace MooGame.Tests.Mocks;

internal class MockNumberGenerator : INumberGenerator
{
    string _number {  get; set; }
    public MockNumberGenerator(string desiredNumber)
    {
        _number = desiredNumber;
    }
    public string GenerateNumber()
    {
        return _number;
    }
}