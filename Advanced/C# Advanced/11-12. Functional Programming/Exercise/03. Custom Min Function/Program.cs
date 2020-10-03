using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Exer_03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Action<int> print = Console.WriteLine;

            Func<List<int>, int> FindMin = x => x.Min();

            print(FindMin(numbers));

            //Func<int[], int> minFunction = GetMin;
            //int[] numbers = Console.ReadLine()
            //                       .Split()
            //                       .Select(int.Parse)
            //                       .ToArray();

            //int minNumber = minFunction(numbers);
            //Console.WriteLine(minNumber);

        }

        //private static int GetMin(int[] array)
        //{
        //    int min = int.MaxValue;
        //    foreach (int num in array)
        //    {
        //        if (num < min)
        //        {
        //            min = num;
        //        }
        //    }

        //    return min;
        //}

    }
}
