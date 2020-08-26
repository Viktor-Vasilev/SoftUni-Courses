using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Immutable;
using System.Security.Cryptography.X509Certificates;

namespace _000_boza
{

    class Program
    {
        static void Main(string[] args)
        {
            int passengers = int.Parse(Console.ReadLine());

            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();

            int wagonCapacity = 4;

            for (int i = 0; i < wagons.Count; i++)
            {
                while (wagonCapacity - wagons[i] != 0 && passengers > 0)
                {
                    passengers--;
                    wagons[i] += 1;
                }
            }
            if (passengers > 0)
            {
                Console.WriteLine($"There isn't enough space! {passengers} people in a queue!");
                Console.WriteLine(String.Join(" ", wagons));
            }
            else if (passengers == 0 && wagons[wagons.Count - 1] == 4)
            {
                Console.WriteLine(String.Join(" ", wagons));
            }
            else
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(String.Join(" ", wagons));
            }

        }

    }
}
