using System;

namespace Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int commandsNumber = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int playerRow = -1;
            int playerCol = -1;
            bool playerWons = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                    if (matrix[row, col] == 'f')
                    {
                        playerCol = col;
                        playerRow = row;
                        matrix[row, col] = '-';
                    }
                }
            }

            for (int i = 0; i < commandsNumber; i++)
            {
                string command = Console.ReadLine();
                if (command=="up")
                {
                    playerRow--;
                    if (playerRow<0)
                    {
                        playerRow = matrix.GetLength(1) - 1;
                    }
                    if (matrix[playerRow, playerCol]=='B')
                    {
                        playerRow--;
                    }
                    else if (matrix[playerRow, playerCol] == 'T')
                    {
                        playerRow++;
                    }
                    else if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        Console.WriteLine("Player won!");
                        PrintMatrix(matrix);
                        playerWons = true;
                        break;
                    }
                }
                else if (command == "down")
                {
                    playerRow++;
                    if (playerRow >= matrix.GetLength(1))
                    {
                        playerRow = 0;
                    }
                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerRow++;
                    }
                    else if (matrix[playerRow, playerCol] == 'T')
                    {
                        playerRow--;
                    }
                    else if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        Console.WriteLine("Player won!");
                        PrintMatrix(matrix);
                        playerWons = true;
                        break;
                    }
                }
                else if (command == "left")
                {
                    playerCol--;
                    if (playerCol<0)
                    {
                        playerCol = matrix.GetLength(0) - 1;
                    }
                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerCol--;
                    }
                    else if (matrix[playerRow, playerCol] == 'T')
                    {
                        playerCol++;
                    }
                    else if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        Console.WriteLine("Player won!");
                        PrintMatrix(matrix);
                        playerWons = true;
                        break;
                    }
                }
                else if (command == "right")
                {
                    playerCol++;
                    if (playerCol >= matrix.GetLength(0))
                    {
                        playerCol = 0;
                    }
                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerCol++;
                    }
                    else if (matrix[playerRow, playerCol] == 'T')
                    {
                        playerCol--;
                    }
                    else if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        Console.WriteLine("Player won!");
                        PrintMatrix(matrix);
                        playerWons = true;
                        break;
                    }
                }
            }
            if (!playerWons)
            {
                matrix[playerRow, playerCol] = 'f';
                Console.WriteLine("Player lost!");
                PrintMatrix(matrix);
            }

        }
        private static void PrintMatrix(char[,] matrix)
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
    }
}
