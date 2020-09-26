using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Exer_02._Sets_Of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int setOneLength = input[0];
            int setTwoLength = input[1];

            HashSet<int> setOne = new HashSet<int>();
            HashSet<int> setTwo = new HashSet<int>();

            for (int i = 0; i < setOneLength; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                setOne.Add(currentNumber);
            }

            for (int i = 0; i < setTwoLength; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                setTwo.Add(currentNumber);
            }

            var commonElements = setOne.Intersect(setTwo);
            Console.WriteLine(String.Join(" ", commonElements));

        }
    }
}
