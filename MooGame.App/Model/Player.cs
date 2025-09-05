namespace MooGame.App.Model;

public class Player
{
    public string Name { get; private set; }

    public int NumberOfGames { get; private set; } 
    
    private int _numberOfGuesses;
    

    public Player(string name, int guesses)
    {
        Name = name;
        NumberOfGames = 1;

        _numberOfGuesses = guesses;
    }

    public void Update(int guesses)
    {
        _numberOfGuesses += guesses;
        NumberOfGames++;
    }

    public double Average()
    {
        return (double)_numberOfGuesses / NumberOfGames;
    }
}

