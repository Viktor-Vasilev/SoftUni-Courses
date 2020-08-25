using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20191207_Group_1_02_Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"U\$([A-Z][a-z]{2,})U\$P@\$([A-Za-z]{5,}[0-9]+)P@\$";

            int validRegistrations = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Regex regex = new Regex(pattern);

                Match match = regex.Match(input);

                if (match.Success)
                {
                    validRegistrations++;

                    string userName = match.Groups[1].Value;
                    string password = match.Groups[2].Value;

                    Console.WriteLine($"Registration was successful");
                    Console.WriteLine($"Username: {userName}, Password: {password}");
                }
                else
                {
                    Console.WriteLine($"Invalid username or password");
                }
            }

            Console.WriteLine($"Successful registrations: {validRegistrations}");
        }


        //int n = int.Parse(Console.ReadLine());

        //Regex regex = new Regex(@"U\$(?<name>[A-Z][a-z]{2,})U\$P@\$(?<pass>[A-Za-z]{5,}[A-Za-z0-9]*[0-9])P@\$");                  

        //int count = 0;

        //for (int i = 0; i < n; i++)
        //{
        //    string login = Console.ReadLine();

        //    Match match = regex.Match(login);

        //    if (match.Success)
        //    {
        //        count++;

        //        Console.WriteLine("Registration was successful");
        //        Console.WriteLine($"Username: {match.Groups["name"]}, Password: {match.Groups["pass"]}");

        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid username or password");
        //    }
        //}

        //Console.WriteLine($"Successful registrations: {count}");

    }
    }
}
