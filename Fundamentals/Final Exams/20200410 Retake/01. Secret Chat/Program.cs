using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Reveal")
            {
                var splitted = command.Split(":|:");

                if (command.Contains("InsertSpace"))
                {
                    int index = int.Parse(splitted[1]);

                    message = message.Insert(index, " ");

                    Console.WriteLine(message);
                }
                else if (command.Contains("Reverse"))
                {
                    string substring = splitted[1];

                    if (!message.Contains(substring))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        message = message.Remove(message.IndexOf(substring), substring.Length);

                        var reversed = String.Concat(substring.Reverse());  // var reversed = new string(substring.Reverse().ToArray()); - също може и така!

                        message = message.Insert(message.Length, reversed); // message += reversed; - също може и така!

                        Console.WriteLine(message);
                    }

                }
                else if (command.Contains("ChangeAll"))
                {
                    string substring = splitted[1];
                    string replacement = splitted[2];

                    message = message.Replace(substring, replacement);

                    Console.WriteLine(message);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
