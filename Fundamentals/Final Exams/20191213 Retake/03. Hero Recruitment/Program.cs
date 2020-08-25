using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20191213_Retake_03_Hero_Recruitment
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            Dictionary<string, List<string>> heroes = new Dictionary<string, List<string>>();

            while (input != "End")
            {
                string[] command = input.Split();

                string heroName = command[1];

                if (command.Contains("Enroll"))
                {
                    if (!heroes.ContainsKey(heroName))
                    {
                        heroes.Add(heroName, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                }
                else if (command.Contains("Learn"))
                {
                    string spellName = command[2];

                    if (!heroes.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else if (heroes[heroName].Contains(spellName))
                    {
                        Console.WriteLine($"{heroName} has already learnt {spellName}.");
                    }
                    else
                    {
                        heroes[heroName].Add(spellName);
                    }


                }
                else if (command.Contains("Unlearn"))
                {
                    string spellName = command[2];

                    if (!heroes.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else if (!heroes[heroName].Contains(spellName))
                    {
                        Console.WriteLine($"{heroName} doesn't know {spellName}.");
                    }
                    else
                    {
                        heroes[heroName].Remove(spellName);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Heroes:");

            foreach (var hero in heroes.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"== {hero.Key}: {String.Join(", ", hero.Value)}");
            }


            //Console.WriteLine("Heroes:");

            //foreach (var hero in heroes.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            //{
            //    Console.Write($"== {hero.Key}:");



            //    int count = 0;

            //    foreach (var kvp in hero.Value)
            //    {
            //        count++;

            //        if (count == hero.Value.Count)
            //        {
            //            Console.Write($" {kvp}");
            //        }
            //        else
            //        {
            //            Console.Write($" {kvp},");
            //        }

            //    }
            //    Console.WriteLine();
            //}

        }
    }
}
