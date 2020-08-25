using System;

namespace Izpit_20190420_4._2_Easter_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggs = int.Parse(Console.ReadLine());

            int soldAll = 0;

            string command = Console.ReadLine();

            while (command != "Close")
            {

                if (command == "Fill")
                {
                    int buyedEggs = int.Parse(Console.ReadLine());
                    eggs += buyedEggs;
                }

                if (command == "Buy")
                {
                    int soldEggs = int.Parse(Console.ReadLine());
                    if (soldEggs <= eggs)
                    {
                        eggs -= soldEggs;
                        soldAll += soldEggs;
                    }
                    else
                    {
                        Console.WriteLine("Not enough eggs in store!");
                        Console.WriteLine($"You can buy only {eggs}.");
                        break;
                    }
                }
                command = Console.ReadLine();

            }

            if (command == "Close")
            {
                Console.WriteLine("Store is closed!");
                Console.WriteLine($"{soldAll} eggs sold.");
            }

        }
    }
}
