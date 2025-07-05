namespace MooGame;

public class RandomMooNumberGenerator : INumberGenerator
{
    public string GenerateNumber()
    {
        //Bryt ner den här metoden till 2 olika metoder, en som skapar målsiffran/strängen och den 
        //andra metoden som kollar om alla siffror är unika

        Random randomGenerator = new Random();
        string targetNumber = string.Empty; //ändra namn och tilldela string.Empty?
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
}
