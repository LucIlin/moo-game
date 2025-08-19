using MooGame.App.Helper;
using MooGame.App.Interfaces;
using MooGame.App.Model;

namespace MooGame.App.Controller;

public class MooGameController : IGameController
{
    private readonly INumberGenerator _numberGenerator;
    private readonly IInputOutput _inputOutput;
    private readonly MooGameScoreValidator _validator;

    const string newLine = "\n";
    const int InitialGuessCount = 1;

    public MooGameController(INumberGenerator numberGenerator, IInputOutput inputOutput)
    {
        _numberGenerator = numberGenerator;
        _inputOutput = inputOutput;
        _validator = new MooGameScoreValidator();
    }
    public void Play()
    {
        
        bool isRunning = true;

        AskPlayerForName();

        string playerName = _inputOutput.ReadInput(); //userName eller playerName //validate so that player name is not bigger than 25char //put this data into PlayerData?
        //check here
        do
        {
            string targetNumber = _numberGenerator.GenerateNumber();
            GivePlayerInstructions(targetNumber);

            string playerGuess = _inputOutput.ReadInput(); //must be 4 characters, not more, not less, must be digits
                                                           //check here
            int numberOfGuesses = InitialGuessCount; //1 blir magisk siffra

            (bool isGuessCorrect, string result) bullsAndCowsResult = _validator.CheckGuess(targetNumber, playerGuess);

            _inputOutput.WriteOutput(bullsAndCowsResult.result + newLine);

            while (bullsAndCowsResult.isGuessCorrect != true) //Så länge gissningen inte är lika med targetNumber så körs den, Är inte BBBB en magisk "siffra/ord"
            { //Byta ut while mot do-while
                numberOfGuesses++;
                playerGuess = _inputOutput.ReadInput();
                _inputOutput.WriteOutput(playerGuess + newLine);
                bullsAndCowsResult = _validator.CheckGuess(targetNumber, playerGuess);
                bool isGuessCorrect = _validator.IsGuessCorrect(bullsAndCowsResult);
                _inputOutput.WriteOutput(bullsAndCowsResult.result + newLine);
            }

            //Scoreboard.GetScoreBoard();


            ShowPlayerTheResult(numberOfGuesses);

            string answer = _inputOutput.ReadInput(); //must be "y" or "n" with small letters and nothing else

            isRunning = EndGameIfPlayerDoesNotChooseYes(isRunning, answer);

        } while (isRunning);
    }

    private string CreateScore(int bulls, int cows) //namngivningen ska va CreateScore
    {
        return $"{new string('B', bulls)}{(cows > 0 ? " " + new string('C', cows) : "")}";
    }

    private static bool EndGameIfPlayerDoesNotChooseYes(bool isRunning, string answer)
    {
        if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
        {
            isRunning = false;
        }

        return isRunning;
    }

    private void ShowPlayerTheResult(int numberOfGuesses)
    {
        _inputOutput.WriteOutput("Correct, it took " + numberOfGuesses + " guesses\nContinue? y/n");
    }

    private void GivePlayerInstructions(string targetNumber)
    {
        _inputOutput.WriteOutput("New game:\n");
        _inputOutput.WriteOutput("For practice, number is: " + targetNumber + newLine); //Ta bort denna när allt är klart
        _inputOutput.WriteOutput("Guess with 4 digits");
    }

    private void AskPlayerForName()
    {
        _inputOutput.WriteOutput("Enter your user name:\n");
    }

    public void GetValidatedGuess()
    {

    }

    public void AskToContínue()
    {

    }
}