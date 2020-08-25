using System;
using System.Linq;
using System.Collections.Generic;

namespace _00_MidExam_Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            double averageValue = input.Sum() * 1.0 / input.Count;

            List<int> newList = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] > averageValue)
                {
                    newList.Add(input[i]);
                }
            }

            if (newList.Sum() == 0)
            {
                Console.WriteLine("No");
                return;
            }
            else
            {
                newList.Sort();
                newList.Reverse();

                if (newList.Count > 5)
                {
                    List<int> final = new List<int>();

                    for (int i = 0; i <= 4; i++)
                    {
                        final.Add(newList[i]);
                    }
                    Console.WriteLine(String.Join(" ", final));
                    return;
                }
                Console.WriteLine(String.Join(" ", newList));
            }
        }
    }
}
