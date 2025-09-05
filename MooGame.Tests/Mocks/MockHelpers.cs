using MooGame.App.Helper;
using MooGame.App.Interfaces;
using MooGame.App.Model;

namespace MooGame.Tests.Mocks;

internal static class MockHelpers
{
    public static IUserInputHandler CreateUserInputHandler(string[] inputs)
    {
        var userInputs = new Queue<string>(inputs);
        var io = new MockIO(userInputs);
        return new UserInputHandler(io);
    }
    public static IGame CreateMooGame(string desiredNumber)
    {
        var generator = new MockNumberGenerator(desiredNumber);
        return new MooGameEngine(generator);
    }

    public static MockGame CreateMockGame(string desiredNumber)
    {
        return new MockGame();
    }
}
