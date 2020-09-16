using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Lab_6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> clients = new Queue<string>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    Console.WriteLine($"{clients.Count} people remaining.");
                    break;
                }
                if (command == "Paid")
                {
                    while (clients.Count > 0)
                    {
                        Console.WriteLine(clients.Dequeue());
                    }
                }
                else
                {
                    clients.Enqueue(command);
                }

            }

        }
    }
}
