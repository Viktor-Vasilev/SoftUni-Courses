using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Data;

namespace _20200815_Retake_Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"([#\|])(?<name>[A-Za-z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})*\1(?<calories>\d{1,5})\1";

            MatchCollection matches = Regex.Matches(input, pattern);

            int caloriesTotal = 0;  

            foreach (Match match in matches)
            {
                int calories = (int.Parse)(match.Groups["calories"].Value);

                caloriesTotal += calories;
            }

            int days = caloriesTotal / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Match match in matches)
            {
                Console.WriteLine($"Item: {match.Groups["name"].Value}, Best before: {match.Groups["date"].Value}, Nutrition: {match.Groups["calories"].Value}");
            }

            // дава само 33 точки!!!

            //string input = Console.ReadLine();

            //string pattern = @"([#\|])(?<name>[A-Za-z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})*\1(?<calories>\d{1,5})\1";

            //MatchCollection matches = Regex.Matches(input, pattern);

            //int caloriesTotal = 0;

            //foreach (Match match in matches)
            //{
            //    int calories = (int.Parse)(match.Groups["calories"].Value);

            //    caloriesTotal += calories;
            //}

            //int days = caloriesTotal / 2000;

            //Console.WriteLine($"You have food to last you for: {days} days!");

            //Dictionary<string, List<string>> info = new Dictionary<string, List<string>>();

            //foreach (Match match in matches)
            //{
            //    string nameFood = match.Groups["name"].Value;
            //    string period = match.Groups["date"].Value;
            //    string calories = match.Groups["calories"].Value;

            //    info.Add(nameFood, new List<string> { period, calories });
            //}

            //foreach (var food in info)
            //{
            //    Console.WriteLine($"Item: {food.Key}, Best before: {food.Value[0]}, Nutrition: {food.Value[1]}");
            //}



        }
    }
}
