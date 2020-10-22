using System;
using System.Data;
using System.Linq;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int foodQuantity = 0;
            int snakeRow = -1;
            int snakeCol = -1;
            int firstBurrowRow = -1;
            int firstBurrowCol= -1;
            int secondBurrowRow = -1;
            int secondBurrowCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                        matrix[snakeRow, snakeCol] = '.';
                    }
                    if (matrix[row, col] == 'B')
                    {
                        if (firstBurrowRow==-1)
                        {
                            firstBurrowRow = row;
                            firstBurrowCol = col;
                        }
                        else
                        {
                            secondBurrowRow = row;
                            secondBurrowCol = col;
                        }
                    }
                }
                Console.WriteLine();
            }
            while (true)
            {

                string command = Console.ReadLine();
                if (command == "up")
                {
                    snakeRow--;
                }
                else if (command == "down")
                {
                    snakeRow++;
                }
                else if (command == "left")
                {
                    snakeCol--;
                }
                else if (command == "right")
                {
                    snakeCol++;
                }

                if (!IsInside(matrix, snakeRow, snakeCol))
                {
                    Console.WriteLine("Game over");
                    break;
                }
                if (matrix[snakeRow, snakeCol] == '*')
                {
                    foodQuantity++;
                }
                if (matrix[snakeRow, snakeCol]=='B')
                {
                    matrix[snakeRow, snakeCol] = '.';
                    if (firstBurrowRow == snakeRow && firstBurrowCol == snakeCol)
                    {
                        snakeRow = secondBurrowRow;
                        snakeCol= secondBurrowCol;
                    }
                    else
                    {
                        snakeRow = firstBurrowRow;
                        snakeCol = firstBurrowCol;
                    }
                }
                matrix[snakeRow, snakeCol] = '.';
                if (foodQuantity>=10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    matrix[snakeRow, snakeCol] = 'S';
                    Console.WriteLine($"Food eaten: {foodQuantity}");
                    break;
                }
                PrintMatrix(matrix);
            }
        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0;
                    col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + "");
                }
                Console.WriteLine();
            }
        }
        static bool IsInside(char[,] matrix, int row, int col)
        {
            if (row<0||col<0)
            {
                return false;
            }
            if (row>matrix.GetLength(0)||col>matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }

    }
}

