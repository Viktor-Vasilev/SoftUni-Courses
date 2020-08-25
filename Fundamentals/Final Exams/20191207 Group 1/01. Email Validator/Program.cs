using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20191207_Group_1_01_Email_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Complete")
            {
                string[] splitted = command.Split();

                if (command.Contains("Upper"))
                {
                    email = email.ToUpper();

                    Console.WriteLine(email);
                }
                else if (command.Contains("Lower"))
                {
                    email = email.ToLower();

                    Console.WriteLine(email);
                }
                else if (command.Contains("GetDomain"))
                {
                    int count = int.Parse(splitted[1]);

                    string domainName = email.Substring(email.Length - count, count);


                    Console.WriteLine(domainName);

                }
                else if (command.Contains("GetUsername"))
                {
                    if (!email.Contains("@"))
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                    else
                    {
                        int index = email.IndexOf("@");

                        string userName = email.Substring(0, index);

                        Console.WriteLine(userName);
                    }
                }
                else if (command.Contains("Replace"))
                {
                    char charToReplace = char.Parse(splitted[1]);

                    email = email.Replace(charToReplace, '-');

                    Console.WriteLine(email);
                }
                else if (command.Contains("Encrypt"))
                {
                    List<int> encrypted = new List<int>();

                    for (int i = 0; i < email.Length; i++)
                    {
                        encrypted.Add(email[i]);
                    }

                    Console.WriteLine(String.Join(" ", encrypted));
                }
                command = Console.ReadLine();
            }



            //string input = Console.ReadLine();

            //string command = Console.ReadLine();

            //while (command != "Complete")
            //{
            //    var splitted = command.Split();

            //    if (command.Contains("Upper"))
            //    {
            //        input = input.ToUpper();
            //        Console.WriteLine(input);
            //    }
            //    else if (command.Contains("Lower"))
            //    {
            //        input = input.ToLower();
            //        Console.WriteLine(input);
            //    }
            //    else if (command.Contains("GetDomain"))
            //    {
            //        int count = int.Parse(splitted[1]);

            //        string domain = input.Substring(input.Length - count);

            //        Console.WriteLine(domain);
            //    }
            //    else if (command.Contains("GetUsername"))
            //    {
            //        int index = input.IndexOf("@");

            //        if (index < 0)
            //        {
            //            Console.WriteLine($"The email {input} doesn't contain the @ symbol.");
            //        }
            //        else
            //        {
            //            Console.WriteLine(input.Substring(0, index));
            //        }

            //    }
            //    else if (command.Contains("Replace"))
            //    {
            //        var charToReplace = char.Parse(splitted[1]);

            //        input = input.Replace(charToReplace, '-');

            //        Console.WriteLine(input);
            //    }
            //    else if (command.Contains("Encrypt"))
            //    {
            //        for (int i = 0; i < input.Length; i++)
            //        {
            //            Console.Write($"{(int)input[i]} ");
            //        }

            //        Console.WriteLine();
            //    }

            //    command = Console.ReadLine();
        }
        }
    }
}
