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
            string targetNumber = ""; //ändra namn och tilldela string.Empty?
            for (int i = 0; i < 4; i++) //4 är en magisk siffra
            {
                int randomNumber = randomGenerator.Next(10);
                string randomDigit = "" + randomNumber; //Göra en metod som heter "CreateRandomNumber" och parse-a det till en sträng
                while (targetNumber.Contains(randomDigit))
                {
                    randomNumber = randomGenerator.Next(10);
                    randomDigit = "" + randomNumber;
                }
                targetNumber = targetNumber + randomDigit;
            }
            return targetNumber;
        }

        public static string checkBC(string targetNumber, string playerGuess) //CheckResult eller checkguess iställer för BC, BC är oklart.
        {
            int cows = 0, bulls = 0;
            playerGuess += "    ";     // if player entered less than 4 chars
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++) //Implementera felhantering på längden av gissningen, om den är inom "range"
                {
                    if (targetNumber[i] == playerGuess[j])
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
        public static void Scoreboard() //Byt namn till Scoreboard
        {
            //byt namngivning input mot streamreader
            //Ha using, så att den kan dispose-a senare
            StreamReader fileContent = new StreamReader("result.txt"); //Byta namn till textStream eller fileStream
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
            Console.WriteLine("Player   games average");
            foreach (PlayerData p in playerDatas)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
            }
            fileContent.Close();
        }
    }
}