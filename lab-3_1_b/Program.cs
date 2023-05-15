using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter a text line:");
        string textLine = Console.ReadLine();

        string[] words = textLine.Split(' ');

        string longestWord = words[0];
        for (int i = 1; i < words.Length; i++)
        {
            if (words[i].Length > longestWord.Length)
            {
                longestWord = words[i];
            }
        }

        Console.WriteLine("The longest word is: " + longestWord);
    }
}
