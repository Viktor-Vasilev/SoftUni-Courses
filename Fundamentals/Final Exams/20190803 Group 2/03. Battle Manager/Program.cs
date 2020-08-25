using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20190803_Group_2_03_Battle_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<int>> usernames = new Dictionary<string, List<int>>();

            // health = 0;
            // energy = 1;

            while (input != "Results")
            {
                string[] command = input.Split(":");
                
                if (command.Contains("Add"))
                {
                    string personName = command[1];
                    int health = int.Parse(command[2]);
                    int energy = int.Parse(command[3]);

                    if (!usernames.ContainsKey(personName))
                    {
                        usernames.Add(personName, new List<int> {health, energy});
                    }
                    else
                    {
                        usernames[personName][0] += health;
                    }


                }
                else if (command.Contains("Attack"))
                {
                    string attackerName = command[1];
                    string defenderName = command[2];
                    int damage = int.Parse(command[3]);

                    if (usernames.ContainsKey(attackerName) && usernames.ContainsKey(defenderName))
                    {
                        usernames[defenderName][0] -= damage;

                        if (usernames[defenderName][0] <= 0)
                        {
                            usernames.Remove(defenderName);
                            Console.WriteLine($"{defenderName} was disqualified!");
                        }

                        usernames[attackerName][1] -= 1;

                        if (usernames[attackerName][1] == 0)
                        {
                            usernames.Remove(attackerName);
                            Console.WriteLine($"{attackerName} was disqualified!");
                        }
                    }
                }
                else if (command.Contains("Delete"))
                {
                    string userName = command[1];

                    if (usernames.ContainsKey(userName))
                    {
                        usernames.Remove(userName);
                    }
                    if (command.Contains("All"))   /// може и с else да го направя, ако гърмят тестове!
                    {
                        usernames.Clear();
                    }

                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"People count: {usernames.Count}");

            foreach (var user in usernames.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} - {user.Value[0]} - {user.Value[1]}");
            }

            // решение с два речника:

            //Dictionary<string, int> nameAndHealth = new Dictionary<string, int>();
            //Dictionary<string, int> nameAndEnergy = new Dictionary<string, int>();

            //string commands = Console.ReadLine();

            //while (commands != "Results")
            //{
            //    string[] commandArgs = commands.Split(":");
            //    string command = commandArgs[0];

            //    if (command == "Add")
            //    {
            //        string personName = commandArgs[1];
            //        int health = int.Parse(commandArgs[2]);
            //        int energy = int.Parse(commandArgs[3]);

            //        if (!nameAndHealth.ContainsKey(personName) && !nameAndEnergy.ContainsKey(personName))
            //        {
            //            nameAndHealth[personName] = health;
            //            nameAndEnergy[personName] = energy;
            //        }

            //        else
            //        {
            //            nameAndHealth[personName] += health;
            //        }

            //    }

            //    else if (command == "Attack")
            //    {
            //        string attackerName = commandArgs[1];
            //        string defenderName = commandArgs[2];
            //        int damage = int.Parse(commandArgs[3]);

            //        if (nameAndHealth.ContainsKey(attackerName) && nameAndHealth.ContainsKey(defenderName))
            //        {
            //            nameAndHealth[defenderName] -= damage;

            //            if (nameAndHealth[defenderName] <= 0)
            //            {
            //                nameAndHealth.Remove(defenderName);
            //                nameAndEnergy.Remove(defenderName);
            //                Console.WriteLine($"{defenderName} was disqualified!");
            //            }

            //            nameAndEnergy[attackerName]--;

            //            if (nameAndEnergy[attackerName] == 0)
            //            {
            //                nameAndHealth.Remove(attackerName);
            //                nameAndEnergy.Remove(attackerName);
            //                Console.WriteLine($"{attackerName} was disqualified!");
            //            }

            //        }

            //    }

            //    else if (command == "Delete")
            //    {
            //        string username = commandArgs[1];

            //        if (nameAndEnergy.ContainsKey(username))
            //        {
            //            nameAndEnergy.Remove(username);
            //        }

            //        if (nameAndHealth.ContainsKey(username))
            //        {
            //            nameAndHealth.Remove(username);
            //        }

            //        if (username == "All")
            //        {
            //            nameAndHealth.Clear();
            //            nameAndEnergy.Clear();
            //        }
            //    }

            //    commands = Console.ReadLine();
            //}

            //Console.WriteLine($"People count: {nameAndHealth.Count}");

            //nameAndHealth = nameAndHealth
            //                 .OrderByDescending(health => health.Value)
            //                .ThenBy(name => name.Key)
            //                 .ToDictionary(a => a.Key, b => b.Value);

            //foreach (var kvp in nameAndHealth)
            //{
            //    Console.WriteLine($"{kvp.Key} - {kvp.Value} - {nameAndEnergy[kvp.Key]}");
            //}


        }
    }
}
