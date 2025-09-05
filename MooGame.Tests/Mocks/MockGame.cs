using MooGame.App.Interfaces;
using System.Text.RegularExpressions;

namespace MooGame.Tests.Mocks
{
    public class MockGame : IGame
    {
        public int StartRoundCalls { get; private set; }
        public int GuessCount { get; private set; }
        public bool IsRoundOver { get; private set; }
        public void StartRound() 
        { 
            StartRoundCalls++; 
            GuessCount = 0; 
            IsRoundOver = false; 
        }
        public string GetInstructions() => $"INSTRUCTIONS";
        public IScoreResult GetGuessOutcome(string guess)
        {
            GuessCount++;

            if (guess == "1234")
            { IsRoundOver = true; }

            return new MockScoreResult { IsSuccess = IsRoundOver };
        }
        public bool IsValidGuess(string guess) => guess.Length == 4 && Regex.IsMatch(guess, @"^\d+$");
    }
}
