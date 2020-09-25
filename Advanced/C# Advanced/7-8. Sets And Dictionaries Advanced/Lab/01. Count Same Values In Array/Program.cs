using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Lab_01._Count_Same_Values_In_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> counts = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!counts.ContainsKey(input[i]))
                {
                    counts.Add(input[i], 0); 
                }

                counts[input[i]]++;
            }

            foreach (var item in counts)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
