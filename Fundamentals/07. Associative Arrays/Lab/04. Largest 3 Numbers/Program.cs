using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Lab_04._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> input = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(n => n).Take(3).ToList();

            Console.WriteLine(String.Join(" ", input));



        }
    }
}
