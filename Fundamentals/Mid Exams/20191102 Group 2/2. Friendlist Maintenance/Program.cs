using System;
using System.Linq;
using System.Collections.Generic;

namespace _20191102_Group_2_2._Friendlist_Maintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(", ").ToList();

            int blacklistedNamesCount = 0;
            int lostNamesCount = 0;


            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "Report")
                {
                    break;
                }
                else if (command[0] == "Blacklist")
                {
                    string name = command[1];
                    if (input.Contains(name))
                    {
                        input[input.IndexOf(name)] = "Blacklisted";
                        Console.WriteLine($"{name} was blacklisted.");
                        blacklistedNamesCount++;
                    }
                    else
                    {
                        Console.WriteLine($"{name} was not found.");
                    }

                }
                else if (command[0] == "Error")
                {
                    int index = int.Parse(command[1]);

                    if (index >= 0 && index < input.Count)
                    {
                        if (input[index] != "Blacklisted" && input[index] != "Lost")
                        {
                            string name = input[index];

                            input[index] = "Lost";
                            lostNamesCount++;
                            Console.WriteLine($"{name} was lost due to an error.");
                        }


                    }


                }
                else if (command[0] == "Change")
                {
                    int index = int.Parse(command[1]);
                    string newName = command[2];

                    if (index >= 0 && index < input.Count)
                    {
                        string currentName = input[index];
                        input[index] = newName;
                        Console.WriteLine($"{currentName} changed his username to {newName}.");
                    }



                }

            }

            Console.WriteLine($"Blacklisted names: {blacklistedNamesCount}");
            Console.WriteLine($"Lost names: {lostNamesCount}");
            Console.WriteLine(String.Join(" ", input));

        }
    }
}
