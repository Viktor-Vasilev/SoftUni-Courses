using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());

            int days = 0;

            double harvest = 0;

            while (yield >= 100)
            {
                harvest += (yield - 26);

                yield -= 10;

                days++;

            }

            if (harvest >= 26)
            {
               harvest -= 26;
                
            }

            Console.WriteLine(days);
            Console.WriteLine(harvest);
        }
    }
}
