using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20191207_Group_1_03_Inbox_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();



            while (command != "Statistics")
            {
                var splitted = command.Split("->");
                string username = splitted[1];

                if (command.Contains("Add"))
                {
                    if (users.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} is already registered");
                    }
                    else
                    {
                        users.Add(username, new List<string>());
                    }

                }
                else if (command.Contains("Send"))
                {
                    string email = splitted[2];

                    users[username].Add(email);

                }
                else if (command.Contains("Delete"))
                {
                    if (!users.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} not found!");
                    }
                    else
                    {
                        users.Remove(username);
                    }

                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Users count: {users.Count}");

            users = users.OrderByDescending(user => user.Value.Count).ThenBy(user => user.Key).ToDictionary(item => item.Key, item => item.Value);

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}");

                var emails = user.Value;

                foreach (var msg in user.Value)
                {
                    Console.WriteLine($" - {msg}");
                }


                // Console.WriteLine(string.Join("\n- ", emails));
            }
        }
    }
}
