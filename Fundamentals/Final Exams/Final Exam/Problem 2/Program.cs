using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(=|\/)(?<location>[A-Z][A-Za-z]{2,})\1";

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);

            int travelPoints = 0;

            List<string> destinations = new List<string>();

            foreach (Match destination in matches)
            {
                destinations.Add(destination.Groups["location"].Value);

                travelPoints += destination.Groups["location"].Value.Length;
            }

            Console.WriteLine("Destinations: " + string.Join(", ", destinations));

            Console.WriteLine($"Travel Points: {travelPoints}");

            //string input = Console.ReadLine();

            //string pattern = @"(=|\/)(?<location>[A-Z][A-Za-z]{2,})\1";

            //Regex regex = new Regex(pattern);

            //MatchCollection matches = regex.Matches(input);

            //List<string> destinations = new List<string>();

            //int sum = 0;

            //foreach (Match destination in matches)
            //{
            //    destinations.Add(destination.Groups["location"].Value);

            //    sum += destination.Groups["location"].Value.Length;
            //}

            //Console.WriteLine("Destinations: " + string.Join(", ", destinations));

            //Console.WriteLine($"Travel Points: {sum}");

        }
    }
}
