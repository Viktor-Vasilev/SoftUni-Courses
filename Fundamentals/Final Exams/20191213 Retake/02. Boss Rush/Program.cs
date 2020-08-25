using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20191213_Retake_02_Boss_Rush
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"\|([A-Z]{4,})\|:#([A-Za-z]+\s[A-Za-z]+)#";

            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string bossName = match.Groups[1].Value;
                    string title = match.Groups[2].Value;
                    int strength = bossName.Length;
                    int armour = title.Length;

                    Console.WriteLine($"{bossName}, The {title}");
                    Console.WriteLine($">> Strength: {strength}");
                    Console.WriteLine($">> Armour: {armour}");

                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
