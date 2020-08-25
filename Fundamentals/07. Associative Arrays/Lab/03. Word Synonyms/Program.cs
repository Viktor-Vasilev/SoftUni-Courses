using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Lab_03._Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();

            for (int i = 1; i <= n ; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (words.ContainsKey(word) == false)
                {
                    words.Add(word, new List<string>());
                    words[word].Add(synonym);
                }
                else
                {
                    words[word].Add(synonym);
                }

            }


            foreach (var pair in words)
            {
                Console.WriteLine(pair.Key + " - " + String.Join(", ", pair.Value));
            }
        }
    }
}
