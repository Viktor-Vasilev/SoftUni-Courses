using System;
using System.Collections.Generic;
using System.Linq;

namespace _20190417_Retake_01._Catapult_Attack
{
    class Program
    {
        static void Main(string[] args)
        {
            int piles = int.Parse(Console.ReadLine());

            List<int> walls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Stack<int> rocks = new Stack<int>();

            for (int i = 1; i <= piles; i++)
            {
                if (walls.Count == 0)
                {
                    break;
                }

                int[] rocksInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                rocks = new Stack<int>(rocksInput);

                if (i % 3 == 0)
                {
                    int additionalWall = int.Parse(Console.ReadLine());

                    walls.Add(additionalWall);
                }

                while (rocks.Any() && walls.Any())
                {
                    int currentRock = rocks.Pop();

                    if (currentRock > walls[0])
                    {
                        currentRock -= walls[0];
                        rocks.Push(currentRock);
                        walls.RemoveAt(0);
                    }
                    else if (currentRock < walls[0])
                    {
                        walls[0] -= currentRock;
                    }
                    else
                    {
                        walls.RemoveAt(0);
                    }
                }
            }
            if (rocks.Any())
            {
                Console.WriteLine($"Rocks left: {string.Join(", ", rocks)}");
            }
            else if (walls.Any())
            {
                Console.WriteLine($"Walls left: {string.Join(", ", walls)}");
            }




        }
    }
}
