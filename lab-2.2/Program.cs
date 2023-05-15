using System;

public class Program
{
    public static void Main()
    {
        double a = 1;
        double b = 2;
        double dx = 0.025;

        Console.WriteLine("{0,10}{1,10}", "x", "y");
        Console.WriteLine("--------------------");

        for (double x = a; x <= b; x += dx)
        {
            double y = Function(x);
            Console.WriteLine("{0,10:F3}{1,10:F3}", x, y);
        }
    }

    public static double Function(double x)
    {
        double y = Math.Log(x, 2);
        return y;
    }
}