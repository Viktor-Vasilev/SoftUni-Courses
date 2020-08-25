using System;

namespace _02._Bike_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            int juniorVelo = int.Parse(Console.ReadLine());
            int seniorVelo = int.Parse(Console.ReadLine());
            string trace = Console.ReadLine();

            double taxJunior = 0;
            double taxSenior = 0;

            if (trace == "trail")
            {
                taxJunior = 5.50;
                taxSenior = 7.00;
            }
            else if (trace == "cross-country" && (juniorVelo + seniorVelo) < 50)
            {
                taxJunior = 8.00;
                taxSenior = 9.50;
            }
            else if (trace == "cross-country" && (juniorVelo + seniorVelo) >= 50)
            {
                taxJunior = 8.00 * 0.75;
                taxSenior = 9.50 * 0.75;
            }
            else if (trace == "downhill")
            {
                taxJunior = 12.25;
                taxSenior = 13.75;
            }
            else
            {
                taxJunior = 20.00;
                taxSenior = 21.50;
            }


            double total = (((juniorVelo * taxJunior) + (seniorVelo * taxSenior))) * 0.95;

            Console.WriteLine($"{total:F2}");

        }
    }
}
