using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20190724_Preparation_03_The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([#, $, %, *, &])([A-Za-z]+)\1=([0-9]+)!!(.+$)";

            while (true)
            {
                string input = Console.ReadLine();

                Regex regex = new Regex(pattern);

                Match match = regex.Match(input);

                if (match.Success)
                {
                    string nameOfRacer = match.Groups[2].Value;
                    int length = int.Parse(match.Groups[3].Value);
                    string coordinates = match.Groups[4].Value;

                    if (length == coordinates.Length)
                    {

                        StringBuilder sb = new StringBuilder();

                        for (int i = 0; i < coordinates.Length; i++)
                        {
                            sb.Append((char)(coordinates[i] + length));

                        }

                        string geohashcode = sb.ToString();

                        Console.WriteLine($"Coordinates found! {nameOfRacer} -> {geohashcode}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }

            }

            //while (true)
            //{
            //    string input = Console.ReadLine();

            //    string pattern = $@"([#$%*&])(\w+)\1=(\d+)!!(.*)$";

            //    // ^([#$%*&])([A-Za-z]+)\1=([0-9]+)!!(.*)$ - моя регекс също работи

            //    Match match = Regex.Match(input, pattern);

            //    // правим регекса да хваща и тези, които са с различна дължина

            //    if (match.Success)
            //    {
            //        string name = match.Groups[2].Value;
            //        int length = int.Parse(match.Groups[3].Value);
            //        string coordinates = match.Groups[4].Value;

            //        if (length == coordinates.Length) // тук проверявам за дължината
            //        {
            //            StringBuilder sb = new StringBuilder();

            //            for (int i = 0; i < coordinates.Length; i++) 
            //            {
            //                sb.Append((char)(coordinates[i] + length));
            //            }

            //            Console.WriteLine($"Coordinates found! {name} -> {sb.ToString()}");

            //            break;
            //        }
            //    }
            //    Console.WriteLine("Nothing found!");
            //}

        }
    }
}
