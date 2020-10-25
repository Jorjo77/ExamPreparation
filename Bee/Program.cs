using System;
using System.Linq;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int beeRow = -1;
            int beeCol = -1;

            int needed = 5;
            int flowersCount = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                    if (matrix[row, col] == 'B')
                    {
                        beeCol = col;
                        beeRow = row;
                    }
                }
            }
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                if (command== "up")
                {
                    matrix[beeRow, beeCol] = '.';
                    beeRow--;
                    if (!IsOnFeeld(matrix, beeRow, beeCol))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                    if (matrix[beeRow, beeCol] == 'O')
                    {
                        matrix[beeRow, beeCol] = '.';
                        beeRow--;
                    }
                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        needed--;
                        flowersCount++;
                    }
                    matrix[beeRow, beeCol] = 'B';
                }
                else if (command == "down")
                {
                    matrix[beeRow, beeCol] = '.';
                    beeRow++;
                    if (!IsOnFeeld(matrix, beeRow, beeCol))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                    if (matrix[beeRow, beeCol] == 'O')
                    {
                        matrix[beeRow, beeCol] = '.';
                        beeRow++;
                    }
                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        needed--;
                        flowersCount++;
                    }
                    matrix[beeRow, beeCol] = 'B';
                }
                else if (command == "left")
                {
                    matrix[beeRow, beeCol] = '.';
                    beeCol--;
                    if (!IsOnFeeld(matrix, beeRow, beeCol))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                    if (matrix[beeRow, beeCol] == 'O')
                    {
                        matrix[beeRow, beeCol] = '.';
                        beeCol--;

                    }
                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        needed--;
                        flowersCount++;
                    }
                    matrix[beeRow, beeCol] = 'B';
                }
                else if (command == "right")
                {
                    matrix[beeRow, beeCol] = '.';
                    beeCol++;
                    if (!IsOnFeeld(matrix, beeRow, beeCol))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                    if (matrix[beeRow, beeCol] == 'O')
                    {
                        matrix[beeRow, beeCol] = '.';
                        beeCol--;
                    }
                    else if (matrix[beeRow, beeCol] == 'f')
                    {
                        needed--;
                        flowersCount++;
                        matrix[beeRow, beeCol] = 'B';
                    }
                }
            }
            if (needed<=0)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowersCount} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {needed} flowers more");
            }
            PrintMatrix(matrix);

            static void PrintMatrix(char[,] matrix)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }
            }

            static bool IsOnFeeld(char[,] matrix, int row, int col)
            {
                if (row<0||col<0)
                {
                    return false;
                }
                if (row>=matrix.GetLength(0)||col>=matrix.GetLength(1))
                {
                    return false;
                }
                return true;
            }
        }
    }
}
