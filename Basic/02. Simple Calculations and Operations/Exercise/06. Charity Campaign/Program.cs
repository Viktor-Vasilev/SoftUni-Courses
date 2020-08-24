using System;

namespace _06._Charity_Campaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int cookers = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int goffrets = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());
            double priceCake = 45.00;
            double pricegoffret = 5.80;
            double pricepancake = 3.20;
            double sumAll = days * cookers * ((cakes * priceCake) + (goffrets * pricegoffret) + (pancakes * pricepancake));
            double charitySum = sumAll - (sumAll / 8);
            Console.WriteLine($"{charitySum:F2}");
        }
    }
}
