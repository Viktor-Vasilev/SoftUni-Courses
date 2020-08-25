using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20190803_Group_2_01_String_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string myString = Console.ReadLine();
            
            string input = Console.ReadLine();

            while (input != "Done")
            {
                string[] command = input.Split();

                if (command.Contains("Change"))
                {
                    char charToChange = char.Parse(command[1]);
                    char replacement = char.Parse(command[2]);

                   myString = myString.Replace(charToChange, replacement);

                    Console.WriteLine(myString);
                }
                else if (command.Contains("Includes"))
                {
                    string toCheck = command[1];

                    if (myString.Contains(toCheck))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command.Contains("End"))
                {
                    string toCheck = command[1];

                    if (myString.EndsWith(toCheck))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }

                }
                else if (command.Contains("Uppercase"))
                {
                    myString = myString.ToUpper();
                    Console.WriteLine(myString);
                }
                else if (command.Contains("FindIndex"))
                {
                    char toFindIndex = char.Parse(command[1]);

                    int number = myString.IndexOf(toFindIndex);

                    Console.WriteLine(number);
                }
                else if (command.Contains("Cut"))
                {
                    int startIndex = int.Parse(command[1]);
                    int length = int.Parse(command[2]);

                   myString = myString.Substring(startIndex, length);

                    Console.WriteLine(myString);
                }
                input = Console.ReadLine();
            }

        }
    }
}
