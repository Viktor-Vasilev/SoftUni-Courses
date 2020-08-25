using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Lab_05._Word_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            List<string> evenLength = words.Where(word => word.Length % 2 == 0).ToList();


            Console.WriteLine(String.Join("\n", evenLength));


        }
    }
}
