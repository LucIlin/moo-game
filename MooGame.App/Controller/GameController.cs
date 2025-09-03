using MooGame.App.Interfaces;
using MooGame.App.Model;
using System.ComponentModel.DataAnnotations;
using MooGame.App.Helper;

namespace MooGame.App.Controller;

public class GameController : IGameController
{
    private readonly IGame _game;

    private readonly IUserInputHandler _io;

    bool isRunning = true;
    public GameController(IGame game, IUserInputHandler inputOutput)
    {
        _game = game;
        _io = inputOutput;
    }

    public void PlayGame()
    {
        try
        {
            do
            {
                _game.StartRound();

                _io.WriteOutput(_game.GetInstructions());

                while (!_game.IsRoundOver)
                {
                    var playerGuess = _io.GetInput(customValidator: _game.IsValidGuess);

                    var result = _game.HandleGuess(playerGuess);

                    _io.WriteOutput(ShowPlayerResult(result));
                }
                ShowPlayerTheResult(_game.GuessCount); //Kommer finnas en Scoreboard här som lucas fixar

                string playerAnswer = AskToContinue(); //kommer försvinna, lucas tar det

                isRunning = AskPlayerToGoAgain(playerAnswer); //kommer försvinna, lucas tar det

            } while (isRunning);
        }
        catch (Exception e)
        {
        _io.WriteOutput(e.Message);
        }
    }

    private static string ShowPlayerResult(IScoreResult result)
    {
        return result.ToString() ?? "No B's or C's";
    }

    private bool AskPlayerToGoAgain(string answer) //kommer försvinna, lucas tar det
    {
        if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
        {
            isRunning = false;
        }

        return isRunning;
    }
    private string AskToContinue() //kommer försvinna, lucas tar det
    {
        _io.WriteOutput("Continue? y/n");
        return _io.GetInput();
    }
    private void ShowPlayerTheResult(int numberOfGuesses) => _io.WriteOutput($"Correct, it took {numberOfGuesses} guesses");
}
