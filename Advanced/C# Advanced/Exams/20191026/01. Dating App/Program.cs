using System;
using System.Collections.Generic;
using System.Linq;

namespace _20191029_01._Dating_App
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputMales = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<int> inputFemales = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Stack<int> males = new Stack<int>(inputMales);

            Queue<int> females = new Queue<int>(inputFemales);

            int matches = 0;

            while (males.Count > 0 && females.Count > 0)
            {
                int currentMale = males.Peek();
                int curentFemale = females.Peek();

                if (curentFemale <= 0 || currentMale <= 0)
                {
                    if (currentMale <= 0)
                    {
                        males.Pop();
                    }

                    if (curentFemale <= 0)
                    {
                        females.Dequeue();
                    }

                    continue;
                }

                if (currentMale % 25 == 0 || curentFemale % 25 == 0)
                {
                    if (currentMale % 25 == 0)
                    {
                        males.Pop();
                        males.Pop();
                    }

                    if (curentFemale % 25 == 0)
                    {
                        females.Dequeue();
                        females.Dequeue();
                    }

                    continue;
                }

                if (curentFemale == currentMale)
                {
                    males.Pop();
                    females.Dequeue();
                    matches++;
                }
                else
                {
                    females.Dequeue();
                    currentMale -= 2;
                    males.Pop();
                    males.Push(currentMale);
                }
            }

            Console.WriteLine($"Matches: {matches}");

            if (males.Count > 0)
            {
                Console.WriteLine($"Males left: {string.Join(", ", males)}");
            }
            else
            {
                Console.WriteLine($"Males left: none");
            }
            if (females.Count > 0)
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
            else
            {
                Console.WriteLine($"Females left: none");
            }


            //string resultStringByMales = males.Any() ? $"Males left: {string.Join(", ", males)}" : "Males left: none";
            //Console.WriteLine(resultStringByMales);

            //string resultStringByFemales = females.Any() ? $"Females left: {string.Join(", ", females)}" : "Females left: none";
            //Console.WriteLine(resultStringByFemales);

        }
    }
}
