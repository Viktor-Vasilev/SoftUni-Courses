using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20191213_Retake_01_Warriors_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "For Azeroth")
            {
                string[] splitted = command.Split();

                if (command.Contains("GladiatorStance"))
                {
                    input = input.ToUpper();

                    Console.WriteLine(input);
                }
                else if (command.Contains("DefensiveStance"))
                {
                    input = input.ToLower();

                    Console.WriteLine(input);
                }
                else if (command.Contains("Dispel"))
                {
                    int index = int.Parse(splitted[1]);
                    char letter = char.Parse(splitted[2]);

                    if (index < 0 || index >= input.Length)
                    {
                        Console.WriteLine("Dispel too weak.");
                    }
                    else
                    {
                        char[] temp = input.ToCharArray();
                        temp[index] = letter;
                        input = new string(temp);
                        Console.WriteLine("Success!");


                        // or
                        //StringBuilder sb = new StringBuilder();

                        //for (int i = 0; i < input.Length; i++)
                        //{
                        //    sb.Append(input[i]);
                        //}

                        //sb[index] = letter;

                        //input = sb.ToString();

                        //Console.WriteLine("Success!");


                        //or
                        //input = input.Remove(index, 1);
                        //input = input.Insert(index, letter);

                        //Console.WriteLine("Success!");
                    }

                }
                else if (command.Contains("Target Change"))
                {
                    string oldString = splitted[2];
                    string newString = splitted[3];

                    input = input.Replace(oldString, newString);

                    Console.WriteLine(input);
                }
                else if (command.Contains("Target Remove"))
                {
                    string toRemove = splitted[2];

                    int index = input.IndexOf(toRemove);

                    input = input.Remove(index, toRemove.Length);

                    Console.WriteLine(input);
                }
                else
                {
                    Console.WriteLine("Command doesn't exist!");
                }

                command = Console.ReadLine();
            }

        }
    }
}
