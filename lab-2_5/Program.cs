using System;

public class Program
{
    public static void Main()
    {
        int n, m, max, min, countMax, countMin;
        int[,] A = new int[100, 100];

        Console.WriteLine("Enter the number of rows in the matrix: ");
        n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the number of columns in the matrix: ");
        m = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.WriteLine("Enter the value of A[{0}][{1}]: ", i, j);
                A[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        max = A[0, 0];
        min = A[0, 0];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (A[i, j] > max)
                {
                    max = A[i, j];
                }
                if (A[i, j] < min)
                {
                    min = A[i, j];
                }
            }
        }

        countMax = 0;
        countMin = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (A[i, j] == max)
                {
                    countMax++;
                }
                if (A[i, j] == min)
                {
                    countMin++;
                }
            }
        }

        Console.WriteLine("The maximum element in the matrix is {0}", max);
        Console.WriteLine("The minimum element in the matrix is {0}", min);
        Console.WriteLine("The number of occurrences of the maximum element is {0}", countMax);
        Console.WriteLine("The number of occurrences of the minimum element is {0}", countMin);
    }
}