using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _2._Exer_1._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> furniture = new List<string>();

            double totalPrice = 0;
            
            string input = Console.ReadLine();

            string pattern = @">>(?<name>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";
                           

            while (input != "Purchase")
            {

                Regex regex = new Regex(pattern);
                 
                Match match = regex.Match(input);

                if (match.Success)
                {
                    furniture.Add(match.Groups["name"].Value);

                    totalPrice += double.Parse(match.Groups["price"].Value) * double.Parse(match.Groups["quantity"].Value);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");

            if (furniture.Count != 0)
            {
                Console.WriteLine(String.Join(Environment.NewLine, furniture));
            }
            
            Console.WriteLine($"Total money spend: {totalPrice:f2}");

        //    string pattern = @">>(?<furniture>[A-Za-z]+)<<(?<price>\d+\.?\d+)!(?<quantity>\d+)";
        //    decimal sum = 0.0M;
        //    List<string> furnitureList = new List<string>();

        //    while (true)
        //    {
        //        string input = Console.ReadLine();
        //        if (input == "Purchase")
        //        {
        //            break;
        //        }

        //        MatchCollection matches = Regex.Matches(input, pattern);
        //        foreach (Match furniture in matches)
        //        {
        //            furnitureList.Add(furniture.Groups["furniture"].Value);
        //            sum += decimal.Parse(furniture.Groups["price"].Value) * int.Parse(furniture.Groups["quantity"].Value);
        //        }
        //    }

        //    Console.WriteLine("Bought furniture:");
        //    if (furnitureList.Count != 0)
        //    {
        //        Console.WriteLine(String.Join(Environment.NewLine, furnitureList));
        //    }
        //    Console.WriteLine($"Total money spend: {sum:F2}");
        //}
    }
    }
}
