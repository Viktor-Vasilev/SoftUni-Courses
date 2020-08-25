using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace _2._Exer_07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> input = Console.ReadLine().Split('|').Reverse().ToList(); // има сплитване и Reverse!!!!

            List<int> result = new List<int>();

            foreach (string str in input)
            {
                result.AddRange(str.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            }

            Console.WriteLine(String.Join(" ", result));



        }
    }
}
