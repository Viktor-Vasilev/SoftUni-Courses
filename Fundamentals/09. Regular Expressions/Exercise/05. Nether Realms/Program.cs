﻿using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _2._Exer_5._Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] demonsInfo = Console.ReadLine()
                 .Split(new char[] { ' ', ',', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, Dictionary<int, double>> demons = new Dictionary<string, Dictionary<int, double>>();

            foreach (string demon in demonsInfo)
            {
                if (!demons.ContainsKey(demon))
                {
                    demons.Add(demon, new Dictionary<int, double>());
                }
                int health = 0;
                double damage = 0;
                List<double> damages = new List<double>();
                string otherDigits = "";
                string letters = "";

                foreach (var lr in demon)
                {
                    if (lr < 42 || lr > 57)
                    {
                        letters += lr;
                    }
                    else if (lr == 47 || lr == 42)
                    {
                        otherDigits += lr;
                    }

                }

              
                foreach (char ch in letters)
                {
                    health += ch;
                }

                string patternDigits = @"([-|+]?[\d\.]+)([*\/]*)";

                MatchCollection matches = Regex.Matches(demon, patternDigits);

                foreach (Match match in matches)
                {
                    damages.Add(double.Parse(match.Groups[1].ToString()));
                }

                damage = damages.Sum();

                foreach (char dig in otherDigits)
                {
                    if (dig == '*')
                    {
                        damage *= 2;
                    }
                    else if (dig == '/')
                    {
                        damage /= 2;
                    }
                }

                demons[demon].Add(health, damage);
            }

            foreach (var demon in demons.OrderBy(x => x.Key))
            {
                Console.Write($"{demon.Key} - ");

                foreach (var val in demon.Value)
                {
                    Console.WriteLine($"{val.Key} health, {val.Value:f2} damage");
                }
            }




        }
    }
}
