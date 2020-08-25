using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_Exer_01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string words = Console.ReadLine();

            Dictionary<char, int> count = new Dictionary<char, int>();

            foreach (char symbol in words)
            {
                if (symbol == ' ')
                {
                    continue;
                }

                if (!count.ContainsKey(symbol))
                {
                    count.Add(symbol, 0);
                }

                count[symbol]++;
            }

            foreach (var symbol in count)
            {
                Console.WriteLine($"{symbol.Key} -> {symbol.Value}");
            }




        }
    }
}
