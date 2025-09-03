namespace MooGame.App.Helper;

public interface IUserInputHandler
{
    string GetInput(
        string? prompt = null,
        string? errorMessage = null,
        Func<string, bool>? customValidator = null
    );

    bool GetYesNo(string? question);
    void WriteOutput(string output);
}