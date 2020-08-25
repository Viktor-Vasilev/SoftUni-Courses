using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20190803_Group_1_01_String_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] splitted = command.Split(" ");

                if (command.Contains("Translate"))
                {
                    char charToReplace = char.Parse(splitted[1]);
                    char replacement = char.Parse(splitted[2]);

                    input = input.Replace(charToReplace, replacement);

                    Console.WriteLine(input);
                }
                else if (command.Contains("Includes"))
                {
                    string stringToCheck = splitted[1];

                    bool result = input.Contains(stringToCheck);

                    Console.WriteLine(result);

                    //if (input.Contains(stringToCheck))
                    //{
                    //    Console.WriteLine("True");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("False");
                    //}

                }
                else if (command.Contains("Start"))
                {
                    string stringToCheck = splitted[1];

                    bool result = input.StartsWith(stringToCheck);

                    Console.WriteLine(result);

                }
                else if (command.Contains("Lowercase"))
                {
                    input = input.ToLower();

                    Console.WriteLine(input);
                }
                else if (command.Contains("FindIndex"))
                {
                    string charToFindIndex = splitted[1];

                    int lastIndexOfCharToFindIndex = input.LastIndexOf(charToFindIndex);

                    Console.WriteLine(lastIndexOfCharToFindIndex);
                }
                else if (command.Contains("Remove"))
                {
                    int startIndex = int.Parse(splitted[1]);
                    int count = int.Parse(splitted[2]);

                    input = input.Remove(startIndex, count);

                    Console.WriteLine(input);
                }

                command = Console.ReadLine();
            }


        }
    }
}
