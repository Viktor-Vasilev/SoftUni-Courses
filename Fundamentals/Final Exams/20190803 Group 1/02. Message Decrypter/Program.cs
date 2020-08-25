using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20190803_Group_1_02_Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"^([$\|%])([A-Z][a-z]{3,})\1:\s\[([0-9]+)\]\|\[([0-9]+)\]\|\[([0-9]+)\]\|$";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    int group1 = int.Parse(match.Groups[3].Value);
                    int group2 = int.Parse(match.Groups[4].Value);
                    int group3 = int.Parse(match.Groups[5].Value);

                    string tag = match.Groups[2].Value;

                    string message = string.Empty;
     
                    message += (char)group1;
                    message += (char)group2;
                    message += (char)group3;

                    Console.WriteLine($"{tag}: {message}");

                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }

            //int n = int.Parse(Console.ReadLine());

            //string pattern = @"^([$ \/ %])([A-Z][a-z]{2,})\1:\s\[([0-9]+)\]\|\[([0-9]+)\]\|\[([0-9]+)\]\|$";

            //Regex regex = new Regex(pattern);

            //for (int i = 0; i < n; i++)
            //{
            //    string input = Console.ReadLine();

            //    Match match = regex.Match(input);

            //    if (match.Success)
            //    {
            //        string tag = match.Groups[2].Value;

            //        int letter1 = int.Parse(match.Groups[3].Value);
            //        int letter2 = int.Parse(match.Groups[4].Value);
            //        int letter3 = int.Parse(match.Groups[5].Value);


            //        StringBuilder sb = new StringBuilder();

            //        sb.Append((char)(letter1));
            //        sb.Append((char)(letter2));
            //        sb.Append((char)(letter3));

            //        string decrypted = sb.ToString();

            //        Console.WriteLine($"{tag}: {decrypted}");

            //    }
            //    else
            //    {
            //        Console.WriteLine("Valid message not found!");
            //    }
            //}
        }
    }
}
