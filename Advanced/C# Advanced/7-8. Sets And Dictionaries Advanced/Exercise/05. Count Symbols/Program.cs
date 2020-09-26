using System;
using System.Collections.Generic;

namespace _2._Exer_05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> characters = new SortedDictionary<char, int>();

            foreach (char character in input)
            {
                if (!characters.ContainsKey(character))
                {
                    characters.Add(character, 0);
                }

                characters[character]++;
            }

            foreach (var character in characters)
            {
                Console.WriteLine(String.Join("\n", $"{character.Key}: {character.Value} time/s"));

               // Console.WriteLine(String.Join(Environment.NewLine, $"{character.Key}: {character.Value} time/s"));
            }
        }
    }
}
