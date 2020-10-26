using System;
using System.Linq;

namespace Garden
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();
            int n = arr[0];
            int m = arr[1];
            int[,] matrix = new int[n, m];
            while (true)
            {
                string coordinates = Console.ReadLine();
                if (coordinates == "Bloom Bloom Plow")
                {
                    break;
                }
                string[] splittedCoordinaes = coordinates.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int currRow = int.Parse(splittedCoordinaes[0]);
                int currCol = int.Parse(splittedCoordinaes[1]);

                if (!IsOnFeeld(matrix, currRow, currCol))
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else if (IsOnFeeld(matrix, currRow, currCol))
                {

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {

                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {

                            if (matrix[row, col] != 0  && row == currRow || col == currCol)
                            {
                                matrix[currRow, col] = 1;
                                matrix[row, currCol] = 1;
                            }

                        }
                    }
                }
            }

            PrintMatrix(matrix);
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

        static bool IsOnFeeld(int[,] matrix, int row, int col)
        {
            if (row < 0 || col < 0)
            {
                return false;
            }
            if (row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }
    }
}
