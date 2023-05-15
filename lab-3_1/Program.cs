using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter a text line:");
        string textLine = Console.ReadLine();

        char[] chars = textLine.ToCharArray();

        for (int i = 0; i < chars.Length; i++)
        {
            if (Char.IsUpper(chars[i]))
            {
                chars[i] = Char.ToLower(chars[i]);
            }
        }

        string newTextLine = new string(chars);
        Console.WriteLine(newTextLine);
    }
}
