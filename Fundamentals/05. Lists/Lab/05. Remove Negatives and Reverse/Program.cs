using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace _1._Lab_05._Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> result = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] > 0)
                {
                    result.Add(input[i]);
                }

            }
            if (result.Count == 0)
            {
                Console.WriteLine("empty");
                return;
            }
            else
            {
                result.Reverse();
            }

            Console.WriteLine(String.Join(" ", result));

            //List<int> numbers = Console.ReadLine().Split()
            // .Select(int.Parse).ToList();

            //for (int i = 0; i < numbers.Count; i++)
            //{
            //    if (numbers[i] < 0)
            //    {
            //        numbers.RemoveAt(i--);
            //    }
            //}

            //numbers.Reverse();
            //if (numbers.Count == 0)
            //{
            //    Console.WriteLine("empty");
            //    return;
            //}

            //Console.WriteLine(String.Join(" ", numbers));

        }






    }
}
}
