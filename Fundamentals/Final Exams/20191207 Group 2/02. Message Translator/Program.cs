using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;


namespace _20191207_Group_2_02_Message_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"!([A-Z][a-z]{2,})!:\[([A-Za-z]{8,})\]";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Regex regex = new Regex(pattern);

                Match match = regex.Match(input);

                if (match.Success)
                {
                    string command = match.Groups[1].Value;

                    string message = match.Groups[2].Value;

                    List<int> asciiValues = new List<int>();

                    for (int j = 0; j < message.Length; j++)
                    {
                        asciiValues.Add((int)message[j]);
                    }

                    Console.WriteLine($"{command}: {String.Join(" ", asciiValues)}");
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }

            }

            //string pattern = @"![A-Z]{1}[a-z]{2,}!:\[[A-Za-z]{8,}\]";


            //int n = int.Parse(Console.ReadLine());

            //for (int i = 0; i < n; i++)
            //{
            //    string input = Console.ReadLine();

            //    bool isValid = Regex.IsMatch(input, pattern);

            //    if (!isValid)
            //    {
            //        Console.WriteLine("The message is invalid");
            //        continue;
            //    }

            //    string[] inputInfo = input.Split(':');
            //    string command = inputInfo[0].Replace("!", "");
            //    string message = inputInfo[1].Replace("[", "").Replace("]", "");

            //    int[] result = message.Select(x => (int)x).ToArray();



            //    Console.WriteLine($"{command}: {string.Join(" ", result)}");

            //}






            //int m = int.Parse(Console.ReadLine());

            //string text = @"\A\!([A-Z][a-z]{2,})\!\:\[([a-zA-z]{8,})\]\Z";

            //var regex = new Regex(text);

            //for (int i = 1; i <= m; i++)
            //{
            //    string message = Console.ReadLine();

            //    var match = regex.Match(message);

            //    if (match.Success)
            //    {
            //        string command = match.Groups[1].Value;
            //        string addition = match.Groups[2].Value;
            //        Console.Write(command + ":" + " ");

            //        foreach (var ch in addition)
            //        {
            //            int result = ch;
            //            Console.Write(result + " ");
            //        }
            //        Console.WriteLine();
            //    }
            //    else
            //    {
            //        Console.WriteLine("The message is invalid");
            //    }
            //}


        }
    }
}
