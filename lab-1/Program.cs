using System;

class Program
{
    static void Main(string[] args)
    {
        double r, h, s, v;

        Console.Write("Введіть радіус циліндра: ");
        r = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть висоту циліндра: ");
        h = Convert.ToDouble(Console.ReadLine());

        s = 2 * Math.PI * r * h;

        v = Math.PI * r * r * h;

        Console.WriteLine("Площа бічної поверхні циліндра: " + s);
        Console.WriteLine("Об'єм циліндра: " + v);
    }
}
