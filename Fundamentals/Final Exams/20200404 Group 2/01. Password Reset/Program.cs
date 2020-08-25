using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20200729_Prep___Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Done")
            {
                if (command.Contains("TakeOdd"))
                {
                    StringBuilder oddChars = new StringBuilder();
                    for (int i = 1; i < password.Length; i+=2)
                    {
                        oddChars.Append(password[i]);
                    }

                    password = oddChars.ToString();
                    Console.WriteLine(password);

                    //string odd = string.Empty;

                    //for (int i = 1; i < password.Length; i += 2)
                    //{
                    //    odd += password[i];
                    //}

                    //password = odd;


                    //Console.WriteLine(password);


                }

                if (command.Contains("Cut"))
                {
                    var splitted = command.Split();

                    int index = int.Parse(splitted[1]);
                    int length = int.Parse(splitted[2]);

                    password = password.Remove(index, length);

                    Console.WriteLine(password);
                }

                if (command.Contains("Substitute"))
                {
                    var splitted = command.Split();

                    string oldSubstring = splitted[1];
                    string newSubstring = splitted[2];

                    if (password.Contains(oldSubstring))
                    {
                        password = password.Replace(oldSubstring, newSubstring);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }

                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {password}");

        }
    }
}
