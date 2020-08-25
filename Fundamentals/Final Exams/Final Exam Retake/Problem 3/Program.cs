using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Data;

namespace _20200815_Retake_Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> pieces = new Dictionary<string, List<string>>();

            // composer - 0;
            // key - 1;

            for (int i = 0; i < n; i++)
            {
                string songInfo = Console.ReadLine();
                string[] splitted = songInfo.Split('|');

                string piece = splitted[0];
                string composer = splitted[1];
                string key = splitted[2];

                pieces.Add(piece, new List<string> { composer, key });
            }

            string input = Console.ReadLine();

           

            while (input != "Stop")
            {
                string[] command = input.Split('|');

                string piece = command[1];

                if (command.Contains("Add"))
                {
                    string composer = command[2];
                    string key = command[3];

                    if (pieces.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        pieces.Add(piece, new List<string> {composer, key});

                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }

                }
                else if (command.Contains("Remove"))
                {
                    if (pieces.ContainsKey(piece))
                    {
                        pieces.Remove(piece);

                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }


                }
                else if (command.Contains("ChangeKey"))
                {
                    string newKey = command[2];

                    if (pieces.ContainsKey(piece))
                    {
                        pieces[piece][1] = newKey;

                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var piece in pieces.OrderBy(x => x.Key).ThenBy(x => x.Value[0]).ThenBy(x => x.Value[1]))
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value[0]}, Key: {piece.Value[1]}");
            }

        }
    }
}
