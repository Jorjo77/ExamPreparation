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
                     .Split(", ")
                     .Select(int.Parse)
                     .ToArray();
            int[] arr2 = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();
            int dauturaBombs = 0;
            int cherryBombs = 0;
            int smokeDecoryBombs = 0;
            Stack<int> bombEffects = new Stack<int>(arr1);
            Queue<int> bombCasings = new Queue<int>(arr2);
            Dictionary<int, int> bombs = new Dictionary<int, int>();
            while (bombEffects.Count>0||bombCasings.Count>0)
            {
                int currCasing = bombCasings.Peek();
                int currBoimbs = bombEffects.Peek();
                int currSum = currBoimbs +
                currCasing;
                if (currSum == 40)
                {
                    dauturaBombs++;
                    AddBomb(dauturaBombs, bombs);
                    bombCasings.Dequeue();
                    bombEffects.Pop();
                }
                else if (currSum==60)
                {
                    cherryBombs++;
                    AddBomb(cherryBombs, bombs);
                    bombCasings.Dequeue();
                    bombEffects.Pop();
                }
                else if (currSum == 120)
                {
                    smokeDecoryBombs++;
                    AddBomb(smokeDecoryBombs, bombs);
                    bombCasings.Dequeue();
                    bombEffects.Pop();
                }
                else
                {
                currCasing -= 5;
                }
            }
            if (dauturaBombs != 0|| cherryBombs != 0|| smokeDecoryBombs!=0)
            { 
                Console.WriteLine( "Bene! You have successfully filled the bomb pouch!");
            }
            else if (dauturaBombs == 0 || cherryBombs == 0 || smokeDecoryBombs== 0)
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (bombEffects.Count==0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                foreach (var item in bombEffects)
                {
                    Console.Write(bombEffects.Pop() + " ");
                }
            }
            if (bombCasings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                foreach (var item in bombCasings)
                {
                    Console.Write(bombCasings.Dequeue() + " ");
                }
            }
            foreach (var bomb in bombs.OrderBy(k=>k))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }

        private static void AddBomb(int smokeDecoryBombs, Dictionary<int, int> bombs)
        {
            if (!bombs.ContainsKey(smokeDecoryBombs))
            {
                bombs.Add(smokeDecoryBombs, 0);
            }
            bombs[smokeDecoryBombs] += 1;
        }
    }
}
