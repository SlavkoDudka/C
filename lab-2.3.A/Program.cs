using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введіть розмір масиву: ");
        int n = ReadIntegerFromConsole();

        int[] array = new int[n];

        Console.WriteLine("Заповніть масив цілими числами:");

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Елемент {i + 1}: ");
            array[i] = ReadIntegerFromConsole();
        }

        int countNegatives = 0;
        int minAbsValue = int.MaxValue;
        int minAbsIndex = -1;
        int sumAfterMinAbs = 0;

        for (int i = 0; i < n; i++)
        {
            if (array[i] < 0)
            {
                countNegatives++;
            }

            int absValue = Math.Abs(array[i]);

            if (absValue < minAbsValue)
            {
                minAbsValue = absValue;
                minAbsIndex = i;
            }

            if (minAbsIndex != -1 && i > minAbsIndex)
            {
                sumAfterMinAbs += array[i];
            }
        }

        Console.WriteLine($"Кількість від’ємних елементів масиву: {countNegatives}");
        Console.WriteLine($"Сума елементів масиву, розташованих після мінімального за модулем елемента: {sumAfterMinAbs}");
    }

    static int ReadIntegerFromConsole()
    {
        int result;
        while (!int.TryParse(Console.ReadLine(), out result))
        {
            Console.Write("Некоректне значення, введіть ціле число: ");
        }
        return result;
    }
}