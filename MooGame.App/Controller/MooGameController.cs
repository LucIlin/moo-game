using MooGame.App.Extensions;
using MooGame.App.Helper;
using MooGame.App.Interfaces;
using MooGame.App.Model;

namespace MooGame.App.Controller;

public class MooGameController : IGameController
{
    private readonly INumberGenerator _numberGenerator;
    private readonly IInputOutput _inputOutput;
    private readonly MooGameScoreValidator _validator;


    public MooGameController(INumberGenerator numberGenerator, IInputOutput inputOutput)
    {
        _numberGenerator = numberGenerator;
        _inputOutput = inputOutput;
        _validator = new MooGameScoreValidator();
    }
    public void Play()
    {
        bool isRunning = true;
        int numberOfGuesses = 1;

        AskPlayerForName();

        string playerName = _inputOutput.ReadInput(); //userName eller playerName //validate so that player name is not bigger than 25char //put this data into PlayerData?
        //check here
        do
        {
            GivePlayerInstructions();

            string targetNumber = _numberGenerator.GenerateNumber();   // <-- move here and keep it
            bool isGuessCorrect = TryGuess(targetNumber);

            while (!isGuessCorrect)
            {
                numberOfGuesses++;

               isGuessCorrect = TryGuess(targetNumber);
            }

            //Scoreboard.GetScoreBoard();

            ShowPlayerTheResult(numberOfGuesses);
            isRunning = AskPlayerToContinueGame();

        } while (isRunning);
    }

    private bool AskPlayerToContinueGame()
    {
        string answerToContinuePlayingGame = AskToContinue(); //must be "y" or "n" with small letters and nothing else

        return ShouldContinue(answerToContinuePlayingGame);
    }

    private bool TryGuess(string targetNumber)
    {
        bool isGuessCorrect = false;

        string playerGuess = _inputOutput.ReadInput();
        //check here, so that the guess is not longer than 4

        _inputOutput.WriteOutput("You guessed: " + playerGuess);

       string bullsAndCowsResultsMessage = _validator.CheckGuess(targetNumber, playerGuess);

        isGuessCorrect = _validator.IsGuessCorrect(bullsAndCowsResultsMessage);

        _inputOutput.WriteOutput(bullsAndCowsResultsMessage);

        return isGuessCorrect;
    }

    private static bool IsYes(string? answer)
    {
        if (string.IsNullOrWhiteSpace(answer)) return false;
        return answer.Trim().Equals("y", StringComparison.OrdinalIgnoreCase);
    }

    private bool ShouldContinue(string? answer) => IsYes(answer);

    private void ShowPlayerTheResult(int numberOfGuesses) => _inputOutput.WriteOutput($"Correct, it took {numberOfGuesses} guesses");

    private void GivePlayerInstructions()
    {
        _inputOutput.WriteOutput("New game:");
        _inputOutput.WriteOutput("Guess with 4 digits");
    }

    private void AskPlayerForName() => _inputOutput.WriteOutput("Enter your user name:");

    private string AskToContinue()
    {
        _inputOutput.WriteOutput("Continue? y/n");
        return _inputOutput.ReadInput();
    }
}