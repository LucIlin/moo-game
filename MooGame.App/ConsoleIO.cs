using MooGame.App;

namespace MooGame.App;

public class ConsoleIO : IInputOutput
{
    public string ReadInput()
    {
        bool isValidInput = false;
        string input  = string.Empty;
        
        while (!isValidInput)
        {
            input = Console.ReadLine() ?? "";
            
            try
            {
                isValidInput = UserInputHandler.IsValidChars(input);
            }
            catch (ArgumentException e)
            {
                WriteOutput("Something went wrong: " + e.Message + "\n Please try again:");
            }
        }

        return input;
    }

    public void WriteOutput(string message) => Console.WriteLine(message);
}
