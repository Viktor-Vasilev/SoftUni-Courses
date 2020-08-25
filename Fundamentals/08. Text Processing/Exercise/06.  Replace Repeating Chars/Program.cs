using System;

namespace _2._Exer_6.__Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string replaced = string.Empty;

            replaced += input[0];

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] != input[i + 1])
                {
                    replaced += input[i + 1];
                }
            }

            Console.WriteLine(replaced);




        }
    }
}
