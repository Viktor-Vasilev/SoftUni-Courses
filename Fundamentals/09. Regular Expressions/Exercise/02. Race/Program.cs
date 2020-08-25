using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace _2._Exer_2._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> namesAndKm = new Dictionary<string, int>();
            
            
            string[] contestants = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            
            
            string input = Console.ReadLine();

            while (input != "end of race")
            {
                string namePattern = @"[A-Za-z]";
                string digitsPattern = @"\d";

                var nameMatch = Regex.Matches(input, namePattern);
                var kmMatch = Regex.Matches(input, digitsPattern);

                var name = String.Concat(nameMatch);
                var sumofKm = kmMatch.Select(x => int.Parse(x.Value)).Sum();

                if (contestants.Contains(name))
                {
                    if (namesAndKm.ContainsKey(name))
                    {
                        namesAndKm[name] += sumofKm;
                    }
                    else
                    {
                        namesAndKm.Add(name, sumofKm);
                    }


                }

                input = Console.ReadLine();
            }

            var sorted = namesAndKm.OrderByDescending(x => x.Value).Select(x=>x.Key).ToList();


            Console.WriteLine("1st place: " + sorted[0]);
            Console.WriteLine("2nd place: " + sorted[1]);
            Console.WriteLine("3rd place: " + sorted[2]);

        }
    }
}
