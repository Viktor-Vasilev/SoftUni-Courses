using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace _2._Exer_01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    wagons.Add(int.Parse(command[1]));

                }
                else
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (maxCapacity - wagons[i] >= int.Parse(command[0]))
                        {
                            wagons[i] += int.Parse(command[0]);
                            break;
                        }

                    }

                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(String.Join(" ", wagons));


        }
    }
}
