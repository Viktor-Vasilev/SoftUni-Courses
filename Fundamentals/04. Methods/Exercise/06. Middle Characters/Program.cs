using System;

namespace _2.Ex_06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            PrintMiddle(input);
        }

        static void PrintMiddle(string input)
        {
            if (input.Length == 1 || input.Length == 2)
            {
                Console.WriteLine(input);
                return;
            }

            int middle = input.Length / 2;

            if (input.Length % 2 != 0)
            {
                Console.WriteLine(input[middle]);
            }
            else
            {
                Console.WriteLine($"{input[middle - 1]}{input[middle]}");
            }

        }
    }
}
