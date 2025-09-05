using MooGame.App.Interfaces;
using MooGame.App.Model;
using System.ComponentModel.DataAnnotations;
using MooGame.App.Helper;

namespace MooGame.App.Controller;

public class GameController : IGameController
{
    private readonly IGame _game;
    private readonly Scoreboard _scoreboard;
    private readonly IUserInputHandler _io;
    private readonly Player _player;

    bool isRunning = true;
    public GameController(IGame game, IUserInputHandler inputOutput, Player player)
    {
        _game = game;
        _io = inputOutput;
        _scoreboard = new Scoreboard(inputOutput);
        _player = player;
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

                    var result = _game.GetGuessOutcome(playerGuess);

                    _io.WriteOutput(ShowPlayerResult(result));
                }
                
                ShowPlayerTheResult(_game.GuessCount);
                
                _scoreboard.WriteResult(_player.Name,  _game.GuessCount);

                PromptScoreboard();

                AskPlayerToGoAgain(); 

            } while (isRunning);
        }
        catch (Exception e)
        {
            _io.WriteOutput(e.Message);
        }
    }

    private void PromptScoreboard()
    {
        if (_io.GetYesNo("Would you like to see the scoreboard? (y/n)"))
        {
            _scoreboard.Print();
        }
    }

    private static string ShowPlayerResult(IScoreResult result)
    {
        return result.ToString() ?? "No B's or C's";
    }

    private void AskPlayerToGoAgain()
    {
        if (!_io.GetYesNo("Would you like to play again? (y/n)"))
        {
            isRunning = false;
        }
    }
    private void ShowPlayerTheResult(int numberOfGuesses) => _io.WriteOutput($"Correct, it took {numberOfGuesses} guesses");
}
