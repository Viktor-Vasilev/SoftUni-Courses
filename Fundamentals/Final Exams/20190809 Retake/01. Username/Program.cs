using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20190809_Retake_01_Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Sign up")
            {
                string[] splitted = command.Split();
                
                if (command.Contains("lower"))
                {
                    userName = userName.ToLower();
                    Console.WriteLine(userName);
                }
                if (command.Contains("upper"))
                {
                    userName = userName.ToUpper();
                    Console.WriteLine(userName);
                }
                else if (command.Contains("Reverse"))
                {
                    int startIndex = int.Parse(splitted[1]);
                    int endIndex = int.Parse(splitted[2]);

                    if (startIndex >= 0 && endIndex < userName.Length )
                    {
                        string stringToReverse = userName.Substring(startIndex, endIndex - startIndex + 1);

                        Console.WriteLine(String.Join("", stringToReverse.Reverse())); ;

                        // or

                        //char[] chars = stringToReverse.Reverse().ToArray();
                        //Console.WriteLine(String.Join("", chars));

                        // or

                        //StringBuilder sb = new StringBuilder();

                        //for (int i = endIndex; i >= startIndex; i--)
                        //{
                        //    sb.Append(username[i]);
                        //}

                        //string reversed = sb.ToString();

                        //Console.WriteLine(reversed);
                    }
                    

                }
                else if (command.Contains("Cut"))
                {
                    string substring = splitted[1];

                    if (!userName.Contains(substring))
                    {
                        Console.WriteLine($"The word {userName} doesn't contain {substring}.");
                    }
                    else
                    {
                        userName = userName.Remove(userName.IndexOf(substring), substring.Length);
                        Console.WriteLine(userName);
                    }
                    
                }
                else if (command.Contains("Replace"))
                {
                    char toChange = char.Parse(splitted[1]);
                    
                    userName = userName.Replace(toChange, '*');

                    Console.WriteLine(userName);

                }
                else if (command.Contains("Check"))
                {
                    char toCheck = char.Parse(splitted[1]);
                    
                    if (!userName.Contains(toCheck))
                    {
                        Console.WriteLine($"Your username must contain {toCheck}.");
                    }
                    else
                    {
                        Console.WriteLine("Valid");
                    }


                }

                command = Console.ReadLine();
            }


        }
    }
}
