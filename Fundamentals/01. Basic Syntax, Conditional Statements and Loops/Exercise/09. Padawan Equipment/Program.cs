using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numStudents = int.Parse(Console.ReadLine());
            double priceLightsaber = double.Parse(Console.ReadLine());
            double priceRobe = double.Parse(Console.ReadLine());
            double priceBelt = double.Parse(Console.ReadLine());

            double sumLightsabers = (Math.Ceiling(numStudents * 1.1) * priceLightsaber); // ВАЖНО Е КОЕ СЕ ЗАКРЪГЛЯ!!!!
            double sumRobes = priceRobe * numStudents;
            double sumBelts = (priceBelt * numStudents) - ((numStudents / 6) * priceBelt);

            double total = (sumLightsabers + sumRobes + sumBelts);

            if (total <= budget)
            {
                Console.WriteLine($"The money is enough - it would cost {total:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {total - budget:F2}lv more.");
            }
        }
    }
}
