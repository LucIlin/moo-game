namespace MooGame.App.Model;

public class Scoreboard
{
    //Kasta in scoreboard till en egen klass, även skapa upp ett interface ifall man vill byta ut streamreader/text file writer till databas eller något
    public void PrintScoreboard() //Byt namn till Scoreboard
    {
        //byt namngivning input mot streamreader
        //Ha using, så att den kan dispose-a senare
        StreamReader fileContent = new StreamReader("result.txt"); //Byta namn till textStream eller fileStream         Det här ska flyttas till en egen klass som sköter själva läsning av filer
        List<PlayerData> playerDatas = new List<PlayerData>(); //playerDatas ska det heta
        string line;
        //Kolla om den här faktiskt blir null eller string empty
        while ((line = fileContent.ReadLine()) != null) //Gör en till metod som läser ifall användare har skrivit något och inte lämnat det till null
        {
            string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
            string name = nameAndScore[0];
            int guesses = Convert.ToInt32(nameAndScore[1]);
            PlayerData pd = new PlayerData(name, guesses);
            int pos = playerDatas.IndexOf(pd);
            if (pos < 0)
            {
                playerDatas.Add(pd);
            }
            else
            {
                playerDatas[pos].Update(guesses);
            }
        }
        playerDatas.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
        Console.WriteLine("Player games average");
        foreach (PlayerData p in playerDatas)
        {
            Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NumberOfGames, p.Average()));
        }
        fileContent.Close();
    }

    public void GetScoreboard()
    {
        //StreamWriter output = new StreamWriter("result.txt", append: true); //måste abstraheras bort
        //output.WriteLine(playerName + "#&#" + nGuess);
        //output.Close();
        ///*Program.Scoreboard();*/ //måste fixas
        ///
        throw new ArgumentException("not implemented");
    }
}