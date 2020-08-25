using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20190809_Retake_02_Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(.+)>(\d{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})<(\1)$";

            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string password = Console.ReadLine();

                Match match = regex.Match(password);

                if (!match.Success)
                {
                    Console.WriteLine("Try another password!");
                    continue;
                }

                string numbers = match.Groups[2].Value;
                string lowerLetters = match.Groups[3].Value;
                string upperLetters = match.Groups[4].Value;
                string symbols = match.Groups[5].Value;

                string encryptedPassword = String.Concat(numbers, lowerLetters, upperLetters, symbols);

                Console.WriteLine($"Password: {encryptedPassword}");
            }

            //int n = int.Parse(Console.ReadLine());

            //string pattern = @"(.+)>([0-9]{3})\|([a-z]{3})\|([A-Z]{3})\|([^\>\<]{3})<\1";


            //for (int i = 0; i < n; i++)
            //{
            //    string input = Console.ReadLine();

            //    Regex regex = new Regex(pattern);

            //    Match match = regex.Match(input);

            //    if (match.Success)
            //    {
            //        string group1 = match.Groups[2].Value;
            //        string group2 = match.Groups[3].Value;
            //        string group3 = match.Groups[4].Value;
            //        string group4 = match.Groups[5].Value;

            //        StringBuilder sb = new StringBuilder();

            //        sb.Append(group1);
            //        sb.Append(group2);
            //        sb.Append(group3);
            //        sb.Append(group4);

            //        string password = sb.ToString();

            //        Console.WriteLine($"Password: {password}");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Try another password!");
            //    }


            //}

        }
    }
}
