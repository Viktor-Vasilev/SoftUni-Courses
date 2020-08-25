using System;

namespace Izpit_20190706_4._2_Renovation
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine()); 
            int widht = int.Parse(Console.ReadLine()); 
            int percentNotToBePainted = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            double work = Math.Ceiling(((height * 1.0 * widht * 4) * (100 - percentNotToBePainted)) / 100);


            while (command != "Tired!")
            {
                int liters = int.Parse(command);

                if (liters < work)
                {
                    work -= liters;
                }
                else if (liters > work)
                {
                    Console.WriteLine($"All walls are painted and you have {liters - work} l paint left!");
                    break;
                }
                else
                {
                    Console.WriteLine($"All walls are painted! Great job, Pesho!");
                    break;
                }
                

                command = Console.ReadLine();
            }

            if (command == "Tired!")
            {
                Console.WriteLine($"{work} quadratic m left.");
            }


        }
    }
}
