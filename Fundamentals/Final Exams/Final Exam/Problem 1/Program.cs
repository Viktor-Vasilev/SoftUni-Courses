using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;


namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Travel")
            {
                string[] splitted = command.Split(':');

                if (command.Contains("Add Stop"))
                {
                    int index = int.Parse(splitted[1]);
                    string toAdd = splitted[2];

                    if (index >= 0 && index < input.Length)
                    {
                        input = input.Insert(index, toAdd);
                    }

                    Console.WriteLine(input);
                }
                else if (command.Contains("Remove Stop"))
                {
                    int startIndex = int.Parse(splitted[1]);
                    int endIndex = int.Parse(splitted[2]);

                    
                    if (startIndex >= 0 && endIndex < input.Length)
                    {
                        input = input.Remove(startIndex, endIndex - startIndex +1);
                    }

                    Console.WriteLine(input);
                }
                else if (command.Contains("Switch"))
                {
                    string oldString = splitted[1];
                    string newString = splitted[2];

                    if (input.Contains(oldString))
                    {
                        input = input.Replace(oldString, newString);
                    }

                    Console.WriteLine(input);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
        }
    }
}
