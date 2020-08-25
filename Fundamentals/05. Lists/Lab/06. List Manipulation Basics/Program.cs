using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace _1._Lab_06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] tokens = line.Split();

                if (tokens[0] == "Add")
                {
                    int numberToAdd = int.Parse(tokens[1]);
                    numbers.Add(numberToAdd);
                }
                else if (tokens[0] == "Remove")
                {
                    int numberToRemove = int.Parse(tokens[1]);
                    numbers.Remove(numberToRemove);
                }
                else if(tokens[0] == "RemoveAt")
                {
                    int indexToRemoveAt = int.Parse(tokens[1]);
                    numbers.RemoveAt(indexToRemoveAt);
                }
                else if (tokens[0] == "Insert")
                {
                    int numberToInsert = int.Parse(tokens[1]);
                    int indexToInsert = int.Parse(tokens[2]);
                    numbers.Insert(indexToInsert, numberToInsert);
                }

            }

            Console.WriteLine(String.Join(" ", numbers));



        }
    }
}
