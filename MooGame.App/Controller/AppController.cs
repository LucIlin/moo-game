using MooGame.App.Helper;
using MooGame.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.App.Controller;

public class AppController //Appcontroller KÖR programmet, men logiken ska vara i GameController som kör ett specifikt Game
{
    private readonly IInputOutput _inputOutput;
    private readonly INumberGenerator _numberGenerator;
    private readonly ScoreValidator _validator;
    public AppController(IInputOutput inputOutput, INumberGenerator numberGenerator)
    {
        _inputOutput = inputOutput;
        _numberGenerator = numberGenerator;
        _validator = new ScoreValidator();
    }
    public void Run()
    {
        bool isRunning = true; //Ska vara isRunning
        _inputOutput.WriteOutput("Enter your user name:\n");
        string playerName = _inputOutput.ReadInput(); //userName eller playerName //validate so that player name is not bigger than 25char
        //check here
        while (isRunning)
        {
            string targetNumber = _numberGenerator.GenerateNumber(); //ska absolut inte heta goal, oklart namn, targetNumber

            _inputOutput.WriteOutput("New game:\n"); //Controller
                                                     //comment out or remove next line to play real games!
            _inputOutput.WriteOutput("For practice, number is: " + targetNumber + "\n");
            _inputOutput.WriteOutput("Guess with 4 digits");

            string playerGuess = _inputOutput.ReadInput(); //must be 4 characters, not more, not less, must be digits
          //check here
            int numberOfGuesses = 1; //1 blir magisk siffra

            string bullsAndCowsResult = _validator.CheckGuess(targetNumber, playerGuess);

            _inputOutput.WriteOutput(bullsAndCowsResult + "\n");

            while (bullsAndCowsResult != "BBBB") //Så länge gissningen inte är lika med targetNumber så körs den, Är inte BBBB en magisk "siffra/ord"
            { //Byta ut while mot do-while
                numberOfGuesses++;
                playerGuess = _inputOutput.ReadInput();
                _inputOutput.WriteOutput(playerGuess + "\n");
                bullsAndCowsResult = _validator.CheckGuess(targetNumber, playerGuess);
                _inputOutput.WriteOutput(bullsAndCowsResult + "\n");
            }
            //StreamWriter output = new StreamWriter("result.txt", append: true); //måste abstraheras bort
            //output.WriteLine(playerName + "#&#" + nGuess);
            //output.Close();
            /*Program.Scoreboard();*/ //måste fixas
            _inputOutput.WriteOutput("Correct, it took " + numberOfGuesses + " guesses\nContinue? y/n");
            string answer = _inputOutput.ReadInput(); //must be "y" or "n" with small letters and nothing else
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")    
            {
                isRunning = false;
            }
        }
    }
}
