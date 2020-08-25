using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;


namespace _2._Exer_3._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^%(?<client>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$";

            double totalIncome = 0;

            while (true)
            {
               string input = Console.ReadLine();

                if (input == "end of shift")
                {
                    break;
                }

                if (Regex.IsMatch(input, pattern))
                {
                   

                    Match match = Regex.Match(input, pattern);

                    var customer = match.Groups["client"].Value;

                    string product = match.Groups["product"].Value;

                    int count = int.Parse(match.Groups["count"].Value);

                    double price = double.Parse(match.Groups["price"].Value);

                    double money = price * count;

                    Console.WriteLine($"{customer}: {product} - {money:F2}");

                    totalIncome += money;

                    
                }
            }
            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}
