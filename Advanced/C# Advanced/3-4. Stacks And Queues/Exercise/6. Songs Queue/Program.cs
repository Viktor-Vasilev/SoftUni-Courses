using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Exer_6._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ").ToArray();

            Queue<string> queue = new Queue<string>(songs);

            string command = Console.ReadLine();
           

            while (queue.Count > 0)
            {
                string tokens = command.Substring(0, 4);

                if (tokens == "Play")
                {
                    queue.Dequeue();
                }
                else if (tokens == "Add ")
                {
                    string song = command.Substring(4, command.Length - 4);

                    if (queue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(song);
                    }
                }
                else if (tokens == "Show")
                {
                    Console.WriteLine(String.Join(", ", queue));
                }


                command = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");
        }
    }
}
