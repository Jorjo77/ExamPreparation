using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int restFlowers = 0;
            int wreathsCount = 0;
            int currSum = 0;
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            while (lilies.Count>0||roses.Count>0)
            {
                if (lilies.Peek()+roses.Peek()==15)
                {
                    wreathsCount++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (lilies.Peek() + roses.Peek() < 15)
                {
                    restFlowers+= lilies.Pop()+ roses.Dequeue();
                }
                else if (lilies.Peek() + roses.Peek() > 15)
                {
                    int tempElement = lilies.Pop();
                    tempElement -= 2;
                    lilies.Push(tempElement);
                }
            }
            wreathsCount += restFlowers / 15;
            if (wreathsCount>=5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCount} wreaths!");
            }
            else
            {
                int neededWreths = 5 - wreathsCount;
                Console.WriteLine($"You didn't make it, you need {neededWreths} wreaths more!");
            }
        }
    }
}
