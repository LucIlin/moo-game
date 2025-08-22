using MooGame.App.Controller;
using MooGame.App.Helper;
using MooGame.App.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MooGame.App.Model;

public class MooGameEngine : IGame
{
    private readonly IGuessGenerator _numberGenerator;
    private readonly MooGameScoreValidator _validator;

    public string TargetNumber { get; set; }
    public string Guess { get; set; }
    public int GuessCount { get; set; }
    public bool IsRoundOver { get; set; }
    public MooGameEngine(IGuessGenerator numberGenerator)
    {
        _numberGenerator = numberGenerator;
        _validator = new MooGameScoreValidator();
    }

    public void StartRound()
    {
        TargetNumber = _numberGenerator.GenerateGuess();
        GuessCount = 0;
        IsRoundOver = false;
    }
    public IScoreResult HandleGuess(string playerGuess)
    {
        GuessCount++;
        IScoreResult bullsAndCowsResult = _validator.CheckGuess(playerGuess, TargetNumber);
        bullsAndCowsResult.IsSuccess = _validator.IsGuessCorrect(bullsAndCowsResult);
        return bullsAndCowsResult;
    }
}
