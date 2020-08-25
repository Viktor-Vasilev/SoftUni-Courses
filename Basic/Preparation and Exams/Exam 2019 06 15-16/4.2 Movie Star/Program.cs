using System;

namespace Izpit_20190615_4._2_Movie_Star
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "ACTION")
            {
                string actor = command;

                if (actor.Length > 15)
                {
                    budget = budget * 0.8;
                }
                if (actor.Length <= 15)
                {
                    double salary = double.Parse(Console.ReadLine());

                    if (salary > budget)
                    {
                        Console.WriteLine($"We need {salary - budget:F2} leva for our actors.");
                        break;
                    }

                    budget -= salary;

                }

                command = Console.ReadLine();
            }

            if (command == "ACTION")
            {
                Console.WriteLine($"We are left with {budget:F2} leva.");
            }


        }
    }
}
