using System;
using System.Collections.Generic;
using System.Linq;

namespace _20181217_04._The_Kitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputKnifes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] inpuForks = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> knifes = new Stack<int>(inputKnifes);

            Queue<int> forks = new Queue<int>(inpuForks);

            Queue<int> output = new Queue<int>();

            int biggestSet = int.MinValue;

            while (knifes.Any() && forks.Any())
            {
                int currentKnife = knifes.Peek();

                int currentFork = forks.Peek();

                if (currentKnife > currentFork)
                {
                    int sum = currentKnife + currentFork;

                    output.Enqueue(sum);

                    if (sum > biggestSet)
                    {
                        biggestSet = sum;
                    }

                    knifes.Pop();
                    forks.Dequeue();
                }

                else if (currentKnife < currentFork)
                {
                    knifes.Pop();
                }

                else
                {
                    forks.Dequeue();
                    currentKnife = knifes.Pop();
                    currentKnife++;
                    knifes.Push(currentKnife);

                }
            }

            Console.WriteLine($"The biggest set is: {biggestSet}");
            Console.WriteLine(string.Join(" ", output));

        }

      
    }
}
