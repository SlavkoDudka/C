using System;

public class Program
{
    public static void Main()
    {
        double r = 3;
        double h = 10;

        double lateralArea = 2 * Math.PI * r * h;

        double volume = Math.PI * r * r * h;

        Console.WriteLine("Площа бічної поверхні циліндра: " + lateralArea);
        Console.WriteLine("Об'єм циліндра: " + volume);
    }
}