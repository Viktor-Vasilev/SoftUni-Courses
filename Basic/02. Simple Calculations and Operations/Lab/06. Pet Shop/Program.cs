using System;

namespace _06._Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numDogs = int.Parse(Console.ReadLine());
            int numOthers = int.Parse(Console.ReadLine());
            double priceDogs = 2.50;
            double priceOthers = 4.00;
            double suma = ((numDogs * priceDogs) + (numOthers * priceOthers));
            Console.WriteLine($"{suma:f2} lv.");
        }
    }
}
