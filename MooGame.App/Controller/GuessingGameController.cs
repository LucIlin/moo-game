using MooGame.App.Extensions;
using MooGame.App.Interfaces;
using MooGame.App.Model;
using System.ComponentModel.DataAnnotations;
using MooGame.App.Helper;

namespace MooGame.App.Controller;

public class GuessingGameController : IGameController //Controller should have play, play round, play another game, correct guess?
{
    private readonly IGame _game;

    private readonly IUserInput _inputOutput;

    bool isRunning = true;
    public GuessingGameController(IGame game, IUserInput inputOutput)
    {
        _game = game;
        _inputOutput = inputOutput;
    }

    public void PlayGame()
    {
       
        do
        {
            _game.StartRound();

            GivePlayerInstructions();

            while (!_game.IsRoundOver)
            {
                string playerGuess = _inputOutput.GetInput();

               var result = _game.HandleGuess(playerGuess); //behöver returnera BBBB eller något liknande

                _inputOutput.WriteOutput("You guessed: " + playerGuess);
                _inputOutput.WriteOutput(result.ToString() ?? "No B's or C's");
                if(result.IsSuccess)
                {
                    _game.IsRoundOver = true;
                }
            }
            ShowPlayerTheResult(_game.GuessCount);
            string playerAnswer = AskToContinue();
            isRunning = AskPlayerToGoAgain(playerAnswer);
            
        } while (isRunning);
    }
    private bool AskPlayerToGoAgain(string answer)
    {
        if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
        {
            isRunning = false;
        }

        return isRunning;
    }
    private void GivePlayerInstructions()
    {
        _inputOutput.WriteOutput("New game:\n");
        _inputOutput.WriteOutput("Guess with 4 digits");
    }
    private string AskToContinue()
    {
        _inputOutput.WriteOutput("Continue? y/n");
        return _inputOutput.GetInput();
    }
    private void ShowPlayerTheResult(int numberOfGuesses) => _inputOutput.WriteOutput($"Correct, it took {numberOfGuesses} guesses");
}
