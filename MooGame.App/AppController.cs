using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.App;

public class AppController 
{
    private readonly IInputOutput _inputOutput;
    public AppController(IInputOutput inputOutput)
    {
        _inputOutput = inputOutput;
    }
    public void Run()
    {
        bool isRunning = true; //Ska vara isRunning
        _inputOutput.WriteOutput("Enter your user name:\n");
        string playerName = _inputOutput.ReadInput(); //userName eller playerName

        while (isRunning)
        {
            string targetNumber = Program.makeGoal(); //ska absolut inte heta goal, oklart namn, targetNumber


            _inputOutput.WriteOutput("New game:\n"); //Controller
                                                     //comment out or remove next line to play real games!
            _inputOutput.WriteOutput("For practice, number is: " + targetNumber + "\n");
            string playerGuess = _inputOutput.ReadInput();
          
            int nGuess = 1; //1 blir magisk siffra - numberOfGuesses
            string bullsAndCowsResult = Program.CheckScore(targetNumber, playerGuess); //ändra namnet på bbcc, väldigt oklart
            _inputOutput.WriteOutput(bullsAndCowsResult + "\n");
            while (bullsAndCowsResult != "BBBB,") //Så länge gissningen inte är lika med targetNumber så körs den, Är inte BBBB en magisk "siffra/ord"
            { //Byta ut while mot dowhile
                nGuess++;
                playerGuess = _inputOutput.ReadInput();
                _inputOutput.WriteOutput(playerGuess + "\n");
                bullsAndCowsResult = Program.CheckScore(targetNumber, playerGuess);
                _inputOutput.WriteOutput(bullsAndCowsResult + "\n");
            }
            StreamWriter output = new StreamWriter("result.txt", append: true);
            output.WriteLine(playerName + "#&#" + nGuess);
            output.Close();
            Program.Scoreboard();
            _inputOutput.WriteOutput("Correct, it took " + nGuess + " guesses\nContinue?");
            string answer = _inputOutput.ReadInput();
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
            {
                isRunning = false;
            }
        }
    }
}
