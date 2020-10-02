using System;
using System.Linq;

namespace _1._Lab_04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).Select(x => x * 1.2).ToList();

            foreach (var price in input)
            {
                Console.WriteLine($"{price:f2}");
            }

            //Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
            //                 .Select(double.Parse)
            //                 .Select(number => number * 1.20)
            //                 .ToList()
            //                 .ForEach(number => Console.WriteLine($"{number:F2}"));




        }
    }
}
