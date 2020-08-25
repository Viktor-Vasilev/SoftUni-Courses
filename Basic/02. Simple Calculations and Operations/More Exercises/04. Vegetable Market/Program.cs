using System;

namespace _04._Vegetable_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceVeget = double.Parse(Console.ReadLine());
            double priceFruit = double.Parse(Console.ReadLine());
            double vegetkg = double.Parse(Console.ReadLine());
            double fruitkg = double.Parse(Console.ReadLine());
            double incomeLeva = ((priceVeget * vegetkg) + (priceFruit * fruitkg));
            double incomeEuro = incomeLeva / 1.94;
            Console.WriteLine($"{incomeEuro:F2}");
        }
    }
}
