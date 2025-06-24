namespace MooGame
{
    class PlayerData //Ska metoderna i playerdata brytas ut eller tillhör de playerdata? kolla med chat
    {
        public string Name { get; private set; }
        public int NGames { get; private set; } //NumberOfGames? Eller vad är det här?
        int totalGuess;


        public PlayerData(string name, int guesses)
        {
            this.Name = name;
            NGames = 1;
            totalGuess = guesses;
        }

        public void Update(int guesses) //Bryt ut det här till en egen klass
        {
            totalGuess += guesses;
            NGames++;
        }

        public double Average() //PlayerDataController
        {
            return (double)totalGuess / NGames;
        }


        public override bool Equals(Object p)
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