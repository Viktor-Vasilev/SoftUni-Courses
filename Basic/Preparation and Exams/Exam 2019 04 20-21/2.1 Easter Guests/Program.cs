using System;

namespace Izpit_20190420_2._1_Christmas_Guests
{
    class Program
    {
        static void Main(string[] args)
        {
            int numGuests = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double priceKozunak = 4.00;
            double priceEgg = 0.45;

            double numKozunaks = Math.Ceiling (numGuests * 1.0 / 3);
            double numEggs = Math.Ceiling(numGuests * 1.0 * 2.0);
            // Console.WriteLine(numEggs);

            double totalExpenses = ((numKozunaks * priceKozunak) + (numEggs * priceEgg));
            // Console.WriteLine(totalExpenses);

            if (budget >= totalExpenses)
            {
                Console.WriteLine($"Lyubo bought {numKozunaks} Easter bread and {numEggs} eggs.");
                Console.WriteLine($"He has {budget - totalExpenses:F2} lv. left.");
            }
            else if (budget < totalExpenses)
                    {
                Console.WriteLine("Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {totalExpenses - budget:F2} lv. more.");
            }



         

        }
    }
}
