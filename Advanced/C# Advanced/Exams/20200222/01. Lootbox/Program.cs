using System;
using System.Collections.Generic;
using System.Linq;

namespace _20200222_01._Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
           int[] firstBoxRawData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
           int[] secondBoxRawData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> firstBox = new Queue<int>(firstBoxRawData);
            Stack<int> secondBox = new Stack<int>(secondBoxRawData);

            int totalSum = 0;

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int currentFirstBox = firstBox.Peek();
                int currentSecondBox = secondBox.Peek();

                int currentSum = currentFirstBox + currentSecondBox;

                if (currentSum % 2 == 0)
                {
                    totalSum += currentSum;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }
                if (firstBox.Count == 0)
                {
                    Console.WriteLine("First lootbox is empty");
                }

                if (secondBox.Count == 0)
                {
                    Console.WriteLine("Second lootbox is empty");
                }

            if (totalSum < 100)
            {
                Console.WriteLine($"Your loot was poor... Value: {totalSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was epic! Value: {totalSum}");
            }         

        }
    }
}
