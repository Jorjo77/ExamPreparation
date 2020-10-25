using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
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
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            Stack<int> tasks = new Stack<int>(arr1);

            Queue<int> threads = new Queue<int>(arr2);

            int taskToBeKilled = int.Parse(Console.ReadLine());

            while (tasks.Count>0||threads.Count>0)
            {
                if (threads.Peek()>=tasks.Peek())
                {
                    if (tasks.Peek()==taskToBeKilled)
                    {
                        Console.WriteLine($"Thread with value {threads.Peek()} killed task {tasks.Pop()}");
                        break;
                    }
                    threads.Dequeue();
                    tasks.Pop();
                }
                else if (threads.Peek() < tasks.Peek())
                {
                    if (tasks.Peek() == taskToBeKilled)
                    {
                        Console.WriteLine($"Thread with value {threads.Peek()} killed task {tasks.Pop()}");
                        break;
                    }
                    threads.Dequeue();
                }
            }
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
