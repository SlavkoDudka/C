using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter the file name:");
        string fileName = Console.ReadLine();

        System.IO.FileStream fileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Open);

        byte[] firstTwoCharacters = new byte[2];
        fileStream.Read(firstTwoCharacters, 0, 2);

        string firstTwoCharactersString = System.Text.Encoding.ASCII.GetString(firstTwoCharacters);

        bool isNumber = System.Int32.TryParse(firstTwoCharactersString, out int number);

        if (isNumber)
        {
            bool isEven = number % 2 == 0;
            Console.WriteLine("The number is {0} and it is {1}", number, isEven ? "even" : "odd");
        }
        else
        {
            Console.WriteLine("The first two characters are not numbers");
        }

        fileStream.Close();
    }
}
