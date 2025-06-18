namespace MooGame
{
    class MainClass //Program //testtest
    {

        public static void Main(string[] args)
        {

            bool playOn = true; //Ska vara isPlaying eller isRunning
            Console.WriteLine("Enter your user name:\n");
            string name = Console.ReadLine(); //userName eller playerName

            while (playOn)
            {
                string goal = makeGoal(); //ska absolut inte heta goal, oklart namn, targetNumber


                Console.WriteLine("New game:\n"); //Controller
                //comment out or remove next line to play real games!
                Console.WriteLine("For practice, number is: " + goal + "\n");
                string guess = Console.ReadLine();

                int nGuess = 1; //1 blir magisk siffra
                string bbcc = checkBC(goal, guess); //ändra namnet på bbcc, väldigt oklart
                Console.WriteLine(bbcc + "\n");
                while (bbcc != "BBBB,") //Så länge gissningen inte är lika med targetNumber så körs den, Är inte BBBB en magisk "siffra/ord"
                { //Byta ut while mot dowhile
                    nGuess++;
                    guess = Console.ReadLine();
                    Console.WriteLine(guess + "\n");
                    bbcc = checkBC(goal, guess);
                    Console.WriteLine(bbcc + "\n");
                }
                StreamWriter output = new StreamWriter("result.txt", append: true);
                output.WriteLine(name + "#&#" + nGuess);
                output.Close();
                showTopList();
                Console.WriteLine("Correct, it took " + nGuess + " guesses\nContinue?");
                string answer = Console.ReadLine();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    playOn = false;
                }
            }
        }
        static string makeGoal() //Bryt ner den här metoden till 2 olika metoder, en som skapar målsiffran/strängen och den 
                                 //andra metoden som kollar om alla siffror är unika


        {
            Random randomGenerator = new Random();
            string goal = ""; //ändra namn och tilldela string.Empty?
            for (int i = 0; i < 4; i++) //4 är en magisk siffra
            {
                int random = randomGenerator.Next(10);
                string randomDigit = "" + random; //Göra en metod som heter "CreateRandomNumber" och parse-a det till en sträng
                while (goal.Contains(randomDigit))
                {
                    random = randomGenerator.Next(10);
                    randomDigit = "" + random;
                }
                goal = goal + randomDigit;
            }
            return goal;
        }

        static string checkBC(string goal, string guess) //CheckResult eller checkguess iställer för BC, BC är oklart.
        {
            int cows = 0, bulls = 0;
            guess += "    ";     // if player entered less than 4 chars
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++) //Implementera felhantering på längden av gissningen, om den är inom "range"
                {
                    if (goal[i] == guess[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }
            return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
        }

        //Kasta in scoreboard till en egen klass, även skapa upp ett interface ifall man vill byta ut streamreader/text file writer till databas eller något
        static void showTopList() //Byt namn till Scoreboard
        {
            //byt namngivning input mot streamreader
            //Ha using, så att den kan dispose-a senare
            StreamReader input = new StreamReader("result.txt"); //Byta namn till textStream eller fileStream
            List<PlayerData> results = new List<PlayerData>(); //playerDatas ska det heta
            string line;
            //Kolla om den här faktiskt blir null eller string empty
            while ((line = input.ReadLine()) != null) //Gör en till metod som läser ifall användare har skrivit något och inte lämnat det till null
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                PlayerData pd = new PlayerData(name, guesses);
                int pos = results.IndexOf(pd);
                if (pos < 0)
                {
                    results.Add(pd);
                }
                else
                {
                    results[pos].Update(guesses);
                }


            }
            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            Console.WriteLine("Player   games average");
            foreach (PlayerData p in results)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
            }
            input.Close();
        }
    }

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