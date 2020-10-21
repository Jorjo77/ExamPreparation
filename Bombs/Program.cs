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
                     .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();
            int[] arr2 = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            bool IsCompleted = false;
            string dauturaBombs = string.Empty;
            string cherryBombs = string.Empty;
            string smokeDecoryBombs = string.Empty;
            Queue<int> bombEffects = new Queue<int>(arr1);
            Stack<int> bombCasings = new Stack<int>(arr2);
            Dictionary<string, int> bombs = new Dictionary<string, int>();
            while (bombEffects.Count>0 && bombCasings.Count>0)
            {
                ComplimationCheck(bombs, IsCompleted);//Не разбирам защо като е върнало долу true, тук става false!?
                if (IsCompleted)
                {
                    break;
                }
                int currCasing = bombCasings.Peek();
                int currBombs = bombEffects.Peek();
                int currSum = currBombs +
                currCasing;
                if (currSum == 40)
                {
                    dauturaBombs = "Datura Bombs";
                    AddBomb(dauturaBombs, bombs);
                    bombCasings.Pop();
                    bombEffects.Dequeue();
                }
                else if (currSum==60)
                {
                    cherryBombs = "Cherry Bombs";
                    AddBomb(cherryBombs, bombs);
                    bombCasings.Pop();
                    bombEffects.Dequeue();
                }
                else if (currSum == 120)
                {
                    smokeDecoryBombs = "Smoke Decoy Bombs";
                    AddBomb(smokeDecoryBombs, bombs);
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
            if (bombCasings.Count != 0 && bombEffects.Count != 0)
            { 
                Console.WriteLine( "Bene! You have successfully filled the bomb pouch!");
            }
            else if (bombCasings.Count == 0 && bombEffects.Count == 0)
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (bombEffects.Count==0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                while (bombEffects.Count>0)
                {
                    Console.Write($"Bomb Effects: {bombEffects.Dequeue()} ");
                    Console.WriteLine();
                }
            }
            if (bombCasings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                while (bombCasings.Count>0)
                {
                    Console.Write($"Bomb Casings: {bombCasings.Pop()} ");
                }
            }
            foreach (var bomb in bombs.OrderBy(k=>k.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }

        private static void AddBomb(string bomb, Dictionary<string, int> bombs)
        {
            if (!bombs.ContainsKey(bomb))
            {
                bombs.Add(bomb, 0);
            }
            bombs[bomb] += 1;

        }

        private static bool ComplimationCheck(Dictionary<string, int> bombs, bool IsCompleted)
        {
            foreach (var item in bombs)
            {
                if (item.Key == "Datura Bombs" && item.Value >= 3 || item.Key == "Cherry Bombs" && item.Value >= 3 || item.Key == "Smoke Decoy Bombs" && item.Value >= 3)
                {
                    return IsCompleted = true;
                }

            }
             return IsCompleted = false;
        }
    }
}
