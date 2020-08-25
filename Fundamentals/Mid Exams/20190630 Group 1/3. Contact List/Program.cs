using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;

namespace _20190630_Group_1_3._Contact_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> contacts = Console.ReadLine().Split().ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "Add")
                {
                    string newContact = command[1];
                    int index = int.Parse(command[2]);

                    if (contacts.Contains(newContact))
                    {
                        if (index >= 0 && index < contacts.Count)
                        {
                            contacts.Insert(index, newContact);
                        }
                    }
                    else
                    {
                        contacts.Add(newContact);
                    }


                }
                else if (command[0] == "Remove")
                {
                    int index = int.Parse(command[1]);

                    if (index >= 0 && index < contacts.Count)
                    {
                        contacts.RemoveAt(index);
                    }
                }
                else if (command[0] == "Export")
                {
                    int startIndex = int.Parse(command[1]);
                    int count = int.Parse(command[2]);

                    List<string> newList = new List<string>();

                    for (int i = startIndex; i < contacts.Count; i++)
                    {
                        newList.Add(contacts[i]);

                        count--;

                        if (count == 0)
                        {
                            break;
                        }

                       
                    }



                    Console.WriteLine(String.Join(" ", newList));
                }
                else if (command[0] == "Print")
                {
                    if (command[1] == "Normal")
                    {
                        Console.WriteLine($"Contacts: {String.Join(" ", contacts)}");
                        return;
                    }

                    if (command[1] == "Reversed")
                    {
                        contacts.Reverse();
                        Console.WriteLine($"Contacts: {String.Join(" ", contacts)}");
                        return;
                    }


                }
            }
        }
    }
}
