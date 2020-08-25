using System;
using System.Text.RegularExpressions;

namespace _2._Exer_6._Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<=\s)(?<user>[A-Za-z0-9]+[.-]*\w*)@(?<host>[A-za-z]+?([.-][A-Za-z]*)*(\.[A-Za-z]{2,}))";

            string input = Console.ReadLine();

            var matches = Regex.Matches(input, pattern);

            Console.WriteLine(String.Join(Environment.NewLine, matches));

        }
    }
}
