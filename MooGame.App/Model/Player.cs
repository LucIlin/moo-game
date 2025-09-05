namespace MooGame.App.Model;

public class Player
{
    public string Name { get; private set; }
    public int NumberOfGames { get; private set; } //NumberOfGames? Eller vad är det här?
    int TotalNumberOfGuesses;


    public Player(string name, int guesses)
    {
        Name = name;
        NumberOfGames = 1;
        TotalNumberOfGuesses = guesses;
    }

    public void Update(int guesses) //Bryt ut det här till en egen klass
    {
        TotalNumberOfGuesses += guesses;
        NumberOfGames++;
    }

    public double Average() //PlayerDataController
    {
        return (double)TotalNumberOfGuesses / NumberOfGames;
    }


    //public override bool Equals(object p) //Har den någon användning?
    //{
    //    return Name.Equals(((PlayerData)p).Name);
    //}


    public override int GetHashCode() //Ska man ta bort?
    {
        return Name.GetHashCode();
    }
}



//Olika klass ideer, PLAYER, PLAYERCONTROLLER, PLAYERDATA, GAME, GAMECONTROLLER,