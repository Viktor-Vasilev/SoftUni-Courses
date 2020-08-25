using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;

namespace _20200229_Group_2__2._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine().Split('!').ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "Go")
                {
                    break;
                }
                else if (command[0] == "Urgent")
                {
                    string item = command[1];
                    if (groceries.Contains(item))
                    {
                        continue;
                    }
                    else
                    {
                        groceries.Insert(0, item);
                    }

                }
                else if (command[0] == "Unnecessary")
                {
                    string item = command[1];
                    if (groceries.Contains(item))
                    {
                        groceries.Remove(item);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command[0] == "Correct")
                {
                    string oldItem = command[1];
                    string newItem = command[2];

                    if (groceries.Contains(oldItem))
                    {
                        int index = groceries.IndexOf(oldItem);
                        groceries[index] = newItem;

                    }
                    else
                    {
                        continue;
                    }


                }
                else if (command[0] == "Rearrange")
                {
                    string item = command[1];

                    if (groceries.Contains(item))
                    {
                        string temp = item;
                        groceries.Remove(item);
                        groceries.Add(temp);
                    }
                    else
                    {
                        continue;
                    }
                    
                }

            }

            Console.WriteLine(String.Join(", ", groceries));
        }
    }
}
