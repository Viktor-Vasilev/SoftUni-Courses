using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Generate")
            {
                if (command.Contains("Contains"))
                {
                    var splitted = command.Split(">>>");

                    string substring = splitted[1];

                    if (key.Contains(substring))
                    {
                        Console.WriteLine($"{key} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }

                }

                if (command.Contains("Flip"))
                {
                    var splitted = command.Split(">>>");
                    string UpperOrLower = splitted[1];
                    int startIndex = int.Parse(splitted[2]);
                    int endIndex = int.Parse(splitted[3]);

                    string toChange = key.Substring(startIndex, endIndex - startIndex);

                    if (UpperOrLower.Contains("Upper"))
                    {
                        string toChangeToUpper = toChange.ToUpper();

                        key = key.Replace(toChange, toChangeToUpper);

                        Console.WriteLine(key);

                    }
                    else
                    {
                        string toChangeToLower = toChange.ToLower();

                        key = key.Replace(toChange, toChangeToLower);

                        Console.WriteLine(key);
                    }


                }

                if (command.Contains("Slice"))
                {
                    var splitted = command.Split(">>>");

                    int startIndex = int.Parse(splitted[1]);
                    int endIndex = int.Parse(splitted[2]);

                    key = key.Remove(startIndex, endIndex - startIndex);

                    Console.WriteLine(key);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {key}");


            //string input = Console.ReadLine();

            //string command = Console.ReadLine();

            //while (command != "Generate")
            //{
            //    string[] splitted = command.Split(">>>");

            //    if (splitted.Contains("Contains"))
            //    {
            //        string substring = splitted[1];

            //        if (input.Contains(substring))
            //        {
            //            Console.WriteLine($"{input} contains {substring}");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Substring not found!");
            //        }

            //    }
            //    else if (splitted.Contains("Upper"))
            //    {
            //        int startIndex = int.Parse(splitted[2]);
            //        int endIndex = int.Parse(splitted[3]);

            //        string toChange = input.Substring(startIndex, endIndex - startIndex);

            //        int index = input.IndexOf(toChange);

            //        input = input.Remove(index, toChange.Length);

            //        toChange = toChange.ToUpper();

            //        input = input.Insert(index, toChange);

            //        Console.WriteLine(input);
            //    }
            //    else if (splitted.Contains("Lower"))
            //    {
            //        int startIndex = int.Parse(splitted[2]);
            //        int endIndex = int.Parse(splitted[3]);

            //        string toChange = input.Substring(startIndex, endIndex - startIndex);

            //        int index = input.IndexOf(toChange);

            //        input = input.Remove(index, toChange.Length);

            //        toChange = toChange.ToLower();

            //        input = input.Insert(index, toChange);


            //        Console.WriteLine(input);
            //    }
            //    else if (splitted.Contains("Slice"))
            //    {
            //        int startIndex = int.Parse(splitted[1]);
            //        int endIndex = int.Parse(splitted[2]);

            //        input = input.Remove(startIndex, endIndex - startIndex);

            //        Console.WriteLine(input);
            //    }
            //    command = Console.ReadLine();
            //}

            //Console.WriteLine($"Your activation key is: {input}");

        }
    }
}
