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
        bool isRunning = true; //Ska vara isPlaying eller isRunning
        _inputOutput.WriteOutput("Enter your user name:\n");
        string name = _inputOutput.ReadInput(); //userName eller playerName

        while (isRunning)
        {
            string goal = Program.makeGoal(); //ska absolut inte heta goal, oklart namn, targetNumber


            _inputOutput.WriteOutput("New game:\n"); //Controller
                                                     //comment out or remove next line to play real games!
            _inputOutput.WriteOutput("For practice, number is: " + goal + "\n");
            string guess = _inputOutput.ReadInput();

            int nGuess = 1; //1 blir magisk siffra
            string bbcc = Program.checkBC(goal, guess); //ändra namnet på bbcc, väldigt oklart
            _inputOutput.WriteOutput(bbcc + "\n");
            while (bbcc != "BBBB,") //Så länge gissningen inte är lika med targetNumber så körs den, Är inte BBBB en magisk "siffra/ord"
            { //Byta ut while mot dowhile
                nGuess++;
                guess = _inputOutput.ReadInput();
                _inputOutput.WriteOutput(guess + "\n");
                bbcc = Program.checkBC(goal, guess);
                _inputOutput.WriteOutput(bbcc + "\n");
            }
            StreamWriter output = new StreamWriter("result.txt", append: true);
            output.WriteLine(name + "#&#" + nGuess);
            output.Close();
            Program.showTopList();
            _inputOutput.WriteOutput("Correct, it took " + nGuess + " guesses\nContinue?");
            string answer = _inputOutput.ReadInput();
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
            {
                isRunning = false;
            }
        }
    }
}
