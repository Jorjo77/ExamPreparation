using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine()
                     .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();
            int[] arr2 = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int dauturaBombs = 0;
            int cherryBombs = 0;
            int smokeDecoryBombs = 0;
            Queue<int> bombEffects = new Queue<int>(arr1);
            Stack<int> bombCasings = new Stack<int>(arr2);

            while (bombEffects.Count > 0 && bombCasings.Count > 0)
            {

                int currCasing = bombCasings.Peek();
                int currBombs = bombEffects.Peek();
                int currSum = currBombs +
                currCasing;
                if (dauturaBombs >= 3 && cherryBombs >= 3 && smokeDecoryBombs >= 3)
                {
                    break;
                }
                if (currSum == 40)
                {
                    dauturaBombs++;
                    bombCasings.Pop();
                    bombEffects.Dequeue();
                }
                else if (currSum == 60)
                {
                    cherryBombs++;
                    bombCasings.Pop();
                    bombEffects.Dequeue();
                }
                else if (currSum == 120)
                {
                    smokeDecoryBombs++;
                    bombCasings.Pop();
                    bombEffects.Dequeue();
                }

                else
                {
                    int topElement = bombCasings.Pop();
                    topElement -= 5;
                    bombCasings.Push(topElement);
                }
            }
            if (dauturaBombs >= 3 && cherryBombs >= 3 && smokeDecoryBombs >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (bombEffects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }
            if (bombCasings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }

            Console.WriteLine($"Cherry Bombs: {cherryBombs}");
            Console.WriteLine($"Datura Bombs: {dauturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoryBombs}");
        }
    }
}
