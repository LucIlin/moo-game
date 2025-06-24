namespace MooGame
{
    class Program //Program //testtest
    {

        public static void Main(string[] args)
        {
            
        }
        public static string makeGoal() //Bryt ner den här metoden till 2 olika metoder, en som skapar målsiffran/strängen och den 
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

        public static string checkBC(string goal, string guess) //CheckResult eller checkguess iställer för BC, BC är oklart.
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
        public static void showTopList() //Byt namn till Scoreboard
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
}