using System;
using System.Collections.Generic;
using System.Linq;

namespace _20200819_01._Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputLillies = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] inputRoses = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> roses = new Queue<int>(inputRoses);
            Stack<int> lillies = new Stack<int>(inputLillies);

            int madeWreaths = 0;

            int storedFlowersSum = 0;

            while (roses.Any() && lillies.Any())
            {
                int currentRose = roses.Peek();
                int currentLillie = lillies.Peek();

                int currentSum = currentLillie + currentRose;

                if (currentSum == 15)
                {
                    lillies.Pop();
                    roses.Dequeue();
                    madeWreaths++;
                }
                else if (currentSum < 15)
                {
                    lillies.Pop();
                    roses.Dequeue();
                    storedFlowersSum += currentSum;
                }
                else if (currentSum > 15)
                {
                    lillies.Push(lillies.Pop() - 2);
                }

            }

            madeWreaths += (storedFlowersSum / 15);

            if (madeWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {madeWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - madeWreaths} wreaths more!");
            }


        }
    }
}
