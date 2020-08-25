using System;
using System.Linq;
using System.Collections.Generic;

namespace _20191102_Group_2_3._Tanks_Collector
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tanks = Console.ReadLine().Split(", ").ToList();
            int n = int.Parse(Console.ReadLine());

            while (n > 0)
            {
                string[] command = Console.ReadLine().Split(", ");

                if (command[0] == "Add")
                {
                    string newTank = command[1];

                    if (tanks.Contains(newTank))
                    {
                        Console.WriteLine("Tank is already bought");
                    }
                    else
                    {
                        Console.WriteLine("Tank successfully bought");
                        tanks.Add(newTank);
                    }
                }
                if (command[0] == "Remove")
                {
                    string tankName = command[1];

                    if (tanks.Contains(tankName))
                    {
                        Console.WriteLine("Tank successfully sold");
                        tanks.Remove(tankName);
                    }
                    else
                    {
                        Console.WriteLine("Tank not found");
                    }
                }
                if (command[0] == "Remove At")
                {
                    int index = int.Parse(command[1]);

                    if (index >= 0 && index < tanks.Count)
                    {
                        tanks.RemoveAt(index);
                        Console.WriteLine("Tank successfully sold");
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }
                if (command[0] == "Insert")
                {
                    int index = int.Parse(command[1]);
                    string tankName = command[2];

                    if (index < 0 || index >= tanks.Count)
                    {
                        Console.WriteLine("Index out of range");
                    }
                    else if (tanks.Contains(tankName))
                    {
                        Console.WriteLine("Tank is already bought");
                    }
                    else
                    {
                        tanks.Insert(index, tankName);
                        Console.WriteLine("Tank successfully bought");
                    }
                }

                n--;
            }
            Console.Write(String.Join(", ", tanks));
        }
    }
}
