using System;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                int n = int.Parse(Console.ReadLine());
                int[,] matrix = new int[n, n];
                ReadMatrix(matrix);
                PrintMatrix(matrix);

            }
            static void ReadMatrix(int[,] matrix)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    int[] rowData = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = rowData[col];
                    }
                }
            }
            static void PrintMatrix(int[,] matrix)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
