using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace _2._Exer_06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> input1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> input2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                if (input1[0] > input2[0])
                {
                    input1.Add(input1[0]);
                    input1.Add(input2[0]);
                }
                else if (input1[0] < input2[0])
                {
                    input2.Add(input2[0]);
                    input2.Add(input1[0]);
                }

                input1.Remove(input1[0]);

                input2.Remove(input2[0]);

                if (input1.Count == 0)
                {
                    int sum = input2.Sum();
                    Console.WriteLine($"Second player wins! Sum: {sum}");
                    break;
                }
                else if (input2.Count == 0)
                {
                    int sum = input1.Sum();
                    Console.WriteLine($"First player wins! Sum: {sum}");
                    break;
                }

            }
        }
    }
}
