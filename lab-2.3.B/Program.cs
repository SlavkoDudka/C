using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of elements in the array:");
        int n = GetValidIntegerInput();

        int[] array = new int[n];

        Random rand = new Random();

        for (int i = 0; i < n; i++)
        {
            array[i] = rand.Next(-100, 101);
        }

        Console.WriteLine("The array is:");
        Console.WriteLine(string.Join(" ", array));

        int negativeCount = 0;
        foreach (int element in array)
        {
            if (element < 0)
            {
                negativeCount++;
            }
        }

        int smallestModulo = array[0];
        foreach (int element in array)
        {
            if (Math.Abs(element) % 2 < Math.Abs(smallestModulo) % 2)
            {
                smallestModulo = element;
            }
        }

        int sum = 0;
        bool foundSmallestModulo = false;
        foreach (int element in array)
        {
            if (foundSmallestModulo)
            {
                sum += element;
            }
            else if (element == smallestModulo)
            {
                foundSmallestModulo = true;
            }
        }

        Console.WriteLine("The number of negative elements is: {0}", negativeCount);
        Console.WriteLine("The sum of the elements after the element with the smallest modulo is: {0}", sum);
    }

    private static int GetValidIntegerInput()
    {
        int input;
        do
        {
            Console.WriteLine("Enter a positive integer:");
            input = Convert.ToInt32(Console.ReadLine());
        } while (input <= 0);

        return input;
    }
}