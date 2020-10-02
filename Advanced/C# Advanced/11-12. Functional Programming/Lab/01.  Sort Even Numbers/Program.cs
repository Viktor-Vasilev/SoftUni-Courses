using System;
using System.Linq;

namespace _1._Lab_01.__Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).Where(x => x % 2 == 0).OrderBy(x => x).ToArray();

            Console.WriteLine(String.Join(", ", numbers));



        }
    }
}
