using System;

namespace Izpit_20190706_2._1_Family_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numNoshtuvki = int.Parse(Console.ReadLine());
            double priceFor1Noshtuvka = double.Parse(Console.ReadLine());
            int percentDopRazhodi = int.Parse(Console.ReadLine());

            double sumDopRazhodi = (percentDopRazhodi * budget) / 100;

            double sumNoshtuvki = 0;

            if (numNoshtuvki > 7)
            {
                priceFor1Noshtuvka = priceFor1Noshtuvka * 0.95;
            }
            
            sumNoshtuvki = priceFor1Noshtuvka * numNoshtuvki;

            double allcosts = sumDopRazhodi + sumNoshtuvki;

            if (allcosts <= budget)
            {
                Console.WriteLine($"Ivanovi will be left with {budget - allcosts:F2} leva after vacation.");
            }
            else
                Console.WriteLine($"{allcosts - budget:F2} leva needed.");
        }
    }
}
