using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Exer_04._Find_Evens_Or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputBounds = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int start = inputBounds[0];
            int end = inputBounds[1];

            string inputOddOrEven = Console.ReadLine();

            List<int> numbers = new List<int>();

            Predicate<int> filter = x => inputOddOrEven == "odd" ? x % 2 != 0 : x % 2 == 0;

            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }

            Console.WriteLine(string.Join(" ", numbers.Where(x => filter(x))));

        }
    }
}
