using System;
using System.Linq;

namespace _1._Recursion_01._Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int index = 0;
            int result = SumArray(arr, index);
            Console.WriteLine(result);


        }

        private static int SumArray(int[] arr, int index)
        {
            if (index < arr.Length)
            {
                return arr[index] + SumArray(arr, index + 1);
            }

            return 0;
        }

    }
}
