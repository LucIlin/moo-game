using MooGame.App.Extensions;
using MooGame.App.Helper;
using MooGame.App.Interfaces;
using MooGame.App.Model;

namespace MooGame.App.Controller;

//public class MooGameController
//{
//    private readonly IGuessGenerator _numberGenerator;
//    private readonly IInputOutput _inputOutput;
//    private readonly MooGameScoreValidator _validator;

//    public MooGameController(IGuessGenerator numberGenerator, IInputOutput inputOutput)
//    {
//        _numberGenerator = numberGenerator;
//        _inputOutput = inputOutput;
//        _validator = new MooGameScoreValidator();
//    }
//    public void Play()
//    {

//        bool isRunning = true;

//        AskPlayerForName();

//        string playerName = _inputOutput.ReadInput(); //userName eller playerName //validate so that player name is not bigger than 25char //put this data into PlayerData?
//        //check here
//        do
//        {
//            string targetNumber = _numberGenerator.GenerateGuess();
//            GivePlayerInstructions(targetNumber);

//            string playerGuess = _inputOutput.ReadInput(); //must be 4 characters, not more, not less, must be digits
//                                                           //check here
//            int numberOfGuesses = 1; //1 blir magisk siffra

//            MooScoreResult bullsAndCowsResult = _validator.CheckGuess(targetNumber, playerGuess);

//            _inputOutput.WriteOutput(bullsAndCowsResult.ToString());

//            while (bullsAndCowsResult.IsGuessCorrect() != true) //Så länge gissningen inte är lika med targetNumber så körs den, Är inte BBBB en magisk "siffra/ord"
//            { //Byta ut while mot do-while
//                numberOfGuesses++;
//                playerGuess = _inputOutput.ReadInput();
//                _inputOutput.WriteOutput(playerGuess);
//                bullsAndCowsResult = _validator.CheckGuess(targetNumber, playerGuess);
//                bool isGuessCorrect = _validator.IsGuessCorrect(bullsAndCowsResult);
//                _inputOutput.WriteOutput(bullsAndCowsResult.result);
//            }

//            //Scoreboard.GetScoreBoard();


//            ShowPlayerTheResult(numberOfGuesses);

//            string answer = _inputOutput.ReadInput(); //must be "y" or "n" with small letters and nothing else

//            isRunning = EndGameIfPlayerDoesNotChooseYes(isRunning, answer);

//        } while (isRunning);
//    }
  

//    private void ShowPlayerTheResult(int numberOfGuesses)
//    {
//        _inputOutput.WriteOutput("Correct, it took " + numberOfGuesses + " guesses\nContinue? y/n");
//    }

//    private void GivePlayerInstructions(string targetNumber)
//    {
//        _inputOutput.WriteOutput("New game:\n");
//        _inputOutput.WriteOutput("For practice, number is: " + targetNumber + newLine); //Ta bort denna när allt är klart
//        _inputOutput.WriteOutput("Guess with 4 digits");
//    }

//    private void AskPlayerForName()
//    {
//        _inputOutput.WriteOutput("Enter your user name:\n");
//    }
//}