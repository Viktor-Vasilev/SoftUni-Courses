using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Exer_12._Cups_And_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[]bottles = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Stack<int> stackBottles = new Stack<int>(bottles);
            Queue<int> queueCups = new Queue<int>(cups);

            int wastedLiters = 0;

            while (stackBottles.Count > 0 && queueCups.Count > 0)
            {
                int currentCup = queueCups.Dequeue();

                while (currentCup > 0 && stackBottles.Count > 0)
                {
                    int currentBottle = stackBottles.Pop();
                    currentCup -= currentBottle;

                    if (currentCup < 0)
                    {
                        wastedLiters += Math.Abs(currentCup);
                    }                
                }

            }

            if (queueCups.Count > 0)
            {
                Console.WriteLine(($"Cups: {String.Join(" ", queueCups)}"));
            }
            else
            {
                Console.WriteLine(($"Bottles: {String.Join(" ", stackBottles)}"));
            }
            Console.WriteLine($"Wasted litters of water: {wastedLiters}");


            //Queue<int> queueOfCups = new Queue<int>(
            //    Console.ReadLine()
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse));

            //Stack<int> stackOfBottles = new Stack<int>(
            //    Console.ReadLine()
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse));

            //int lostWater = 0;

            //while (queueOfCups.Count > 0 && stackOfBottles.Count > 0)
            //{
            //    int oneCup = queueOfCups.Peek();
            //    int oneBottel = stackOfBottles.Peek();

            //    if (oneBottel >= oneCup)
            //    {
            //        int leftWater = oneBottel - oneCup;
            //        lostWater += leftWater;

            //        queueOfCups.Dequeue();
            //        stackOfBottles.Pop();
            //    }
            //    else
            //    {
            //        int needWater = 0;
            //        while (needWater < oneCup)
            //        {
            //            int currentWater = stackOfBottles.Pop();
            //            needWater += currentWater;
            //        }

            //        int leftWater = needWater - oneCup;
            //        lostWater += leftWater;

            //        queueOfCups.Dequeue();
            //    }
            //}

            //if (queueOfCups.Count > 0)
            //{
            //    Console.WriteLine($"Cups: {string.Join(" ", queueOfCups)}");
            //}
            //else
            //{
            //    Console.WriteLine($"Bottles: {string.Join(" ", stackOfBottles)}");
            //}

            //Console.WriteLine($"Wasted litters of water: {lostWater}");
        }
    }
}
