using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_Exer_09._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forceFighters = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();

            while (command != "Lumpawaro")
            {
                string force = string.Empty;
                string fighter = string.Empty;

                if (command.Contains('|'))
                {
                    string[] tokens = command.Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();

                    force = tokens[0];
                    fighter = tokens[1];

                    if (!forceFighters.ContainsKey(force))
                    {
                        forceFighters.Add(force, new List<string>());
                    }

                    if (!forceFighters[force].Contains(fighter) && !forceFighters.Values.Any(f => f.Contains(fighter)))
                    {
                        forceFighters[force].Add(fighter);
                    }

                }





            }




        }
    }
}
