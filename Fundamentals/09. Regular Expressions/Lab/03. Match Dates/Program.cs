using System;
using System.Text.RegularExpressions;

namespace _1._Lab_3._Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = @"\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";


            var dateStrings = Console.ReadLine();

            var validDates = Regex.Matches(dateStrings, regex);

            foreach (Match date in validDates)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");

            }



        }
    }
}
