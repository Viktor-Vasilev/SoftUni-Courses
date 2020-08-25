using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_Exer_08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            var companies = new SortedDictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string name = input.Split(" -> ")[0];
                string id = input.Split(" -> ")[1];

                if (!companies.ContainsKey(name)) // ако я няма компанията
                {
                    companies.Add(name, new List<string>());
                    companies[name].Add(id);
                }
                else //ако я имаме компанията
                {
                    //добавяме id ако го няма в листа

                    if (!companies[name].Contains(id))
                    {
                        companies[name].Add(id);
                    }

                }
            }
            foreach (var pair in companies)
            {
                Console.WriteLine(pair.Key);
                foreach (string id in pair.Value)
                {
                    Console.WriteLine("-- " + id);
                }
            }



        }
    }
}
