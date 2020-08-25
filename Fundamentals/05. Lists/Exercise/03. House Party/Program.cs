using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Exec_03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();
         
            while (n > 0)
            {
                string[] command = Console.ReadLine().Split(); // Ако го прочета преди цикъла дава грешка!!!!!
                string name = command[0];
                if (command[2] == "going!")
                {
                    if (guests.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guests.Add(name);
                    }
                }
                else
                {
                    if (guests.Contains(name))
                    {
                        guests.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
                n--;             
            }
            // Console.WriteLine(String.Join(" ", guests));
            for (int i = 0; i < guests.Count; i++)
            {
                Console.WriteLine(guests[i]);
            }

        }
    }
}
