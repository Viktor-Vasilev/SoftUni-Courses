using System;
using System.Linq;
using System.Collections.Generic;

namespace _20200229_Group_1__3._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split(" - ");

                if (command[0] == "Craft!")
                {
                    break;
                }
                else if (command[0] == "Collect")
                {
                    string newItem = command[1];
                    if (!(items.Contains(newItem)))
                    {
                        items.Add(newItem);
                    }

                }
                else if (command[0] == "Drop")
                {
                    string newItem = command[1];

                    if (items.Contains(newItem))
                    {
                        items.Remove(newItem);
                    }

                }
                else if (command[0] == "Combine Items")
                {
                    string[] splitted = command[1].Split(':');

                    string oldItem = splitted[0];
                    string newerItem = splitted[1];

                    if (items.Contains(oldItem))
                    {
                        int index = items.IndexOf(oldItem);
                        items.Insert(index + 1, newerItem);

                    }
                   

                }
                else if (command[0] == "Renew")
                {
                    string newItem = command[1];

                    if (items.Contains(newItem))
                    {
                        items.Add(newItem);
                        items.Remove(newItem);
                    }
                }
            }
            Console.Write(String.Join(", ", items));
        }
    }
}
