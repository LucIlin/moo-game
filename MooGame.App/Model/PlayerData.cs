namespace MooGame.App.Model
{
    class PlayerData //Ska metoderna i playerdata brytas ut eller tillhör de playerdata? kolla med chat
    {
        public string Name { get; private set; }
        public int NumberOfGames { get; private set; } //NumberOfGames? Eller vad är det här?
        int TotalNumberOfGuesses;


        public PlayerData(string name, int guesses)
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


        public override bool Equals(object p)
        {
            return Name.Equals(((PlayerData)p).Name);
        }


        public override int GetHashCode() //Ska man ta bort?
        {
            return Name.GetHashCode();
        }
    }
}



//Olika klass ideer, PLAYER, PLAYERCONTROLLER, PLAYERDATA, GAME, GAMECONTROLLER,