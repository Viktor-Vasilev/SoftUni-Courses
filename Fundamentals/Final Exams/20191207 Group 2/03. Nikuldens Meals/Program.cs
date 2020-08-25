using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;


namespace _20191207_Group_2_03_Nikuldens_Meals
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> guests = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();

            int unlikedMeals = 0;

            while (command != "Stop")
            {
                string[] splitted = command.Split("-");

                string guest = splitted[1];
                string meal = splitted[2];

                if (command.Contains("Like"))
                {
                    if (!guests.ContainsKey(guest))
                    {
                        guests.Add(guest, new List<string> { meal });

                    }
                    else if (!guests[guest].Contains(meal))
                    {
                        guests[guest].Add(meal);
                    }

                }
                else
                {
                    if (!guests.ContainsKey(guest))
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                    else if (!guests[guest].Contains(meal))
                    {
                        Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                    }
                    else
                    {
                        unlikedMeals++;
                        guests[guest].Remove(meal);
                        Console.WriteLine($"{guest} doesn't like the {meal}.");
                    }



                }

                command = Console.ReadLine();
            }

            foreach (var guest in guests.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{guest.Key}: {String.Join(", ", guest.Value)}");
            }




            Console.WriteLine($"Unliked meals: {unlikedMeals}");



            //Dictionary<string, List<string>> userMeals = new Dictionary<string, List<string>>();

            //string input = Console.ReadLine();

            //int unlikedMeals = 0;

            //while (input != "Stop")
            //{
            //    string[] command = input.Split('-');
            //    string name = command[1];
            //    string meal = command[2];


            //    if (input.Contains("Like"))
            //    {

            //        if (!userMeals.ContainsKey(name))
            //        {
            //            userMeals.Add(name, new List<string>());
            //        }
            //        if (!userMeals[name].Contains(meal))
            //        {
            //            userMeals[name].Add(meal);
            //        }

            //    }
            //    if (input.Contains("Unlike"))
            //    {
            //        if (!userMeals.ContainsKey(name))
            //        {
            //            Console.WriteLine($"{name} is not at the party.");
            //        }
            //        else if (!userMeals[name].Contains(meal))
            //        {
            //            Console.WriteLine($"{name} doesn't have the {meal} in his/her collection.");
            //        }
            //        else
            //        {
            //            userMeals[name].Remove(meal);
            //            Console.WriteLine($"{name} doesn't like the {meal}.");
            //            unlikedMeals++;
            //        }

            //    }

            //    input = Console.ReadLine();
            //}

            //var sorted = userMeals.OrderByDescending(m => m.Value.Count).ThenBy(n => n.Key);

            //foreach (var item in sorted)
            //{
            //    Console.WriteLine($"{item.Key}: {String.Join(", ", item.Value)}");
            //}

            //Console.WriteLine($"Unliked meals: {unlikedMeals}");
        }
    }
}
