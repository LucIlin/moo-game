using MooGame.App.Controller;
using MooGame.App.Helper;
using MooGame.App.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MooGame.App.Model;

public class MooGameEngine : IGame
{
    private readonly INumberGenerator _numberGenerator;
    private readonly MooGameScoreValidator _validator;

    public string TargetNumber { get; private set; } = string.Empty;
    private int MaxLengthOfGuess { get; } = 4;
    public int GuessCount { get; private set; }
    public bool IsRoundOver { get; private set; }
    public MooGameEngine(INumberGenerator numberGenerator)
    {
        _numberGenerator = numberGenerator;
        _validator = new MooGameScoreValidator();
    }

    public void StartRound()
    {
        TargetNumber = _numberGenerator.GenerateNumber(MaxLengthOfGuess);
        GuessCount = 0;
        IsRoundOver = false;
    }
    public string GetInstructions() => "New game:\nGuess with 4 digits:";
    public IScoreResult GetGuessOutcome(string playerGuess)
    {
        GuessCount++;
        IScoreResult bullsAndCowsResult = _validator.CheckGuess(playerGuess, TargetNumber);
        bullsAndCowsResult.IsSuccess = _validator.IsGuessCorrect(bullsAndCowsResult);
        if (bullsAndCowsResult.IsSuccess)
        {
            IsRoundOver = true;
        }
        return bullsAndCowsResult;
    }

    public bool IsValidGuess(string playerGuess) => playerGuess.Length == MaxLengthOfGuess && Regex.IsMatch(playerGuess, @"^\d+$");
    //todo: måste testas
}