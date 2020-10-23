using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallsCapacity = int.Parse(Console.ReadLine());
            int currHallCapacity = hallsCapacity;
            Stack<string> stack = new Stack<string>();
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            Queue<char> halls = new Queue<char>();
            Queue<char> guests = new Queue<char>();
            while (stack.Count>0)
            {
                string currElement = stack.Pop();
                if (char.IsDigit(currElement))
                {
                    guests.Enqueue(currElement);
                    currHallCapacity -= currElement; //май не ще кастване към инт!?
                    guests.Enqueue(currElement);
                    if (currHallCapacity<=0&&halls.Count>0)
                    {
                        guests.Enqueue(currElement);
                        stack.Push(currElement);
                        char currHall = halls.Dequeue();
                        guests.Enqueue(currHall);
                        Console.Write(guests.Dequeue() + "->" );
                        while (guests.Count>0)
                        {
                            Console.Write(guests.Dequeue() + ", ");
                        }
                    }
                }
                else if (char.IsLetter(currElement))
                {
                    halls.Enqueue(currElement);
                }
            }
        }
    }
}
