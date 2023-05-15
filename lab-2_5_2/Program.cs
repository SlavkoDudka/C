using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of rows in the matrix:");
        int n = GetPositiveInteger();

        Console.WriteLine("Enter the number of columns in the matrix:");
        int m = GetPositiveInteger();

        int[,] matrix = new int[n, m];

        Random rand = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = rand.Next(-100, 101);
            }
        }

        Console.WriteLine("Initial matrix:");
        PrintMatrix(matrix);

        int minElement = matrix[0, 0];
        int minCount = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] < minElement)
                {
                    minElement = matrix[i, j];
                    minCount = 1;
                }
                else if (matrix[i, j] == minElement)
                {
                    minCount++;
                }
            }
        }

        Console.WriteLine($"The minimum element in the matrix is {minElement}.");
        Console.WriteLine($"It occurs {minCount} times.");

        Console.ReadLine();
    }

    static int GetPositiveInteger()
    {
        int num;
        while (!int.TryParse(Console.ReadLine(), out num) || num <= 0)
        {
            Console.WriteLine("Please enter a positive integer.");
        }
        return num;
    }

    static void PrintMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
