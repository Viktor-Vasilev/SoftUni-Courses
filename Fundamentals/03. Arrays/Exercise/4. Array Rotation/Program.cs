using System;
using System.Linq;

namespace _4._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                             .Split()
                             .Select(int.Parse)
                             .ToArray();

            int rotations = int.Parse(Console.ReadLine());
            for (int i = 0; i < rotations; i++)
            {
                int[] rotated = new int[nums.Length];
                rotated[nums.Length - 1] = nums[0];

                for (int k = 0; k < rotated.Length - 1; k++)
                {
                    rotated[k] = nums[k + 1];
                }

                nums = rotated;
            }

            Console.WriteLine(String.Join(" ", nums));




        }
    }
}
