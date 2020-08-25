using System;
using System.Linq;

namespace _03._Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //double[] nums = Console.ReadLine()
            //    .Split(' ')
            //    .Select(double.Parse)
            //    .ToArray();

            //int[] numbers = new int[nums.Length];

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    numbers[i] = (int)Math.Round(nums[i], MidpointRounding.AwayFromZero);
            //    Console.WriteLine($"{nums[i]} -> {numbers[i]}");
            //}

            string[] input = Console.ReadLine().Split();

            double[] nums = new double[input.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = double.Parse(input[i]);



            }


            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    nums[i] = 0;
                }

                Console.WriteLine($"{nums[i]} => {(int)Math.Round(nums[i], MidpointRounding.AwayFromZero)}");
            }




        }
    }
}
