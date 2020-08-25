using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Lab_03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> nums2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            int maxCount = Math.Max(nums1.Count, nums2.Count);

            List<int> result = new List<int>();

            for (int i = 0; i < maxCount; i++)
            {
                if (nums1.Count > i)
                {
                    result.Add(nums1[i]);
                }
                if (nums2.Count > i)
                {
                    result.Add(nums2[i]);
                }

            }

            Console.WriteLine(String.Join(" ", result));




        }
    }
}
