using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Data;

namespace _20200815_Retake_Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Decode")
            {
                string[] splitted = command.Split('|');

                if (command.Contains("Move"))
                {
                    int number = int.Parse(splitted[1]);

                    string toMove = input.Substring(0, number);

                    input = input.Remove(0, toMove.Length);

                    input = input.Insert(input.Length, toMove);

                }
                else if (command.Contains("Insert"))
                {
                    int index = int.Parse(splitted[1]);
                    string value = splitted[2];

                    input = input.Insert(index, value);
                }
                else if (command.Contains("ChangeAll"))
                {
                    string toChange = splitted[1];
                    string replacement = splitted[2];

                    input = input.Replace(toChange, replacement);

                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {input}");
        }
    }
}
