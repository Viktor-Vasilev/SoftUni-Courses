using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;


namespace gg
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Finish")
            {
                string[] splitted = command.Split();

                if (command.Contains("Replace"))
                {
                    char currentChar = char.Parse(splitted[1]);
                    char newChar = char.Parse(splitted[2]);

                    input = input.Replace(currentChar, newChar);

                    Console.WriteLine(input);
                }
                else if (command.Contains("Cut"))
                {
                    int startIndex = int.Parse(splitted[1]);
                    int endIndex = int.Parse(splitted[2]);

                    if (startIndex >= 0 && endIndex < input.Length)
                    {
                        input = input.Remove(startIndex, endIndex - startIndex + 1);

                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }

                }
                else if (command.Contains("Upper"))
                {
                    input = input.ToUpper();

                    Console.WriteLine(input);
                }
                else if (command.Contains("Lower"))
                {
                    input = input.ToLower();

                    Console.WriteLine(input);
                }
                else if (command.Contains("Check"))
                {
                    string toCheck = splitted[1];

                    if (input.Contains(toCheck))
                    {
                        Console.WriteLine($"Message contains {toCheck}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {toCheck}");
                    }

                }
                else if (command.Contains("Sum"))
                {
                    int startIndex = int.Parse(splitted[1]);
                    int endIndex = int.Parse(splitted[2]);

                    if (startIndex >= 0 && endIndex < input.Length)
                    {
                        string toSum = input.Substring(startIndex, endIndex - startIndex + 1);

                        int sum = 0;

                        for (int i = 0; i < toSum.Length; i++)
                        {

                            sum += toSum[i];

                        }

                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }


                }

                command = Console.ReadLine();
            }



            //string message = Console.ReadLine();

            //string command = Console.ReadLine();

            //while (command != "Finish")
            //{
            //    if (command.Contains("Replace"))
            //    {
            //        var splitted = command.Split();
            //        string currentChar = splitted[1];
            //        string newChar = splitted[2];

            //        message = message.Replace(currentChar, newChar);

            //        Console.WriteLine(message);
            //    }
            //    if (command.Contains("Cut"))
            //    {
            //        var splitted = command.Split();
            //        int startIndex = int.Parse(splitted[1]);
            //        int endIndex = int.Parse(splitted[2]);

            //        if (startIndex < 0 || endIndex >= message.Length || startIndex >= message.Length || endIndex < 0) // може да проверим и дали началния е по-малък от крайния, ако се налага!!
            //        {
            //            Console.WriteLine("Invalid indexes!");
            //        }
            //        else
            //        {
            //            message = message.Substring(0, startIndex) + message.Substring(endIndex + 1);

            //            //message = message.Remove(startIndex, endIndex); - Това дава един грешен тест! - 90 точки!

            //            Console.WriteLine(message);
            //        }


            //    }
            //    if (command.Contains("Make"))
            //    {
            //        if (command.Contains("Lower"))
            //        {
            //            message = message.ToLower();
            //        }
            //        else
            //        {
            //            message = message.ToUpper();
            //        }

            //        Console.WriteLine(message);
            //    }
            //    if (command.Contains("Check"))
            //    {
            //        var splitted = command.Split();

            //        var stringToCheck = splitted[1];

            //        if (message.Contains(stringToCheck))
            //        {
            //            Console.WriteLine($"Message contains {stringToCheck}");
            //        }
            //        else
            //        {
            //            Console.WriteLine($"Message doesn't contain {stringToCheck}");
            //        }

            //    }
            //    if (command.Contains("Sum"))
            //    {
            //        var splitted = command.Split();
            //        int startIndex = int.Parse(splitted[1]);
            //        int endIndex = int.Parse(splitted[2]);

            //        if (startIndex < 0 || endIndex >= message.Length || startIndex >= message.Length || endIndex < 0)
            //        {
            //            Console.WriteLine("Invalid indexes!");
            //        }
            //        else
            //        {
            //            int sum = 0;

            //            for (int i = startIndex; i <= endIndex; i++)
            //            {
            //                sum += message[i];
            //            }

            //            Console.WriteLine(sum);
            //        }


            //    }

            //    command = Console.ReadLine();
            //}

        }
    }
}
