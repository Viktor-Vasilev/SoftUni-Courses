using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace _1._Lab_2._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            var regex = @"\+359(-| )2\1\d{3}\1\d{4}\b";

            var input = Console.ReadLine();

            var phoneMatches = Regex.Matches(input, regex);

            var matchedPhones = phoneMatches.Cast<Match>().Select(a => a.Value.Trim()).ToArray();

            Console.WriteLine(String.Join(", ", matchedPhones));

            //var regex = @"\+359(?<delimeter>[ -])2\1\d{3}\1\d{4}\b";

            //string input = Console.ReadLine();

            //var validPhones = Regex.Matches(input, regex);

            //foreach (Match phone in validPhones)
            //{
            //    Console.Write(validPhones + ", ");
        }
        }
    }
}
