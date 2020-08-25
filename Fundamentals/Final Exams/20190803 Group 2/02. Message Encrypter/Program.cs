using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20190803_Group_2_02_Message_Encrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"([\*\@])([A-Z][a-z]{2,})\1:\s\[([A-Za-z])\]\|\[([A-Za-z])\]\|\[([A-Za-z])\]\|$";

            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    char number1 = (char.Parse(match.Groups[3].Value));
                    char number2 = char.Parse(match.Groups[4].Value);
                    char number3 = char.Parse(match.Groups[5].Value);

                    string tag = match.Groups[2].Value;

                    Console.WriteLine($"{tag}: {(int)number1} {(int)number2} {(int)number3}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }

            }

        }
    }
}
