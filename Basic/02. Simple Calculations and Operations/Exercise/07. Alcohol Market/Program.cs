using System;

namespace _07._Alcohol_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceWhiskey = double.Parse(Console.ReadLine());
            double beer = double.Parse(Console.ReadLine());
            double wine = double.Parse(Console.ReadLine());
            double rakia = double.Parse(Console.ReadLine());
            double whiskey = double.Parse(Console.ReadLine());
            double priceRakia = priceWhiskey / 2;
            double priceWine = priceRakia * 0.60;
            double priceBeer = priceRakia * 0.20;
            double costs = (beer * priceBeer) + (whiskey * priceWhiskey) + (wine * priceWine) + (rakia * priceRakia);
            Console.WriteLine($"{costs:f2}");
        }
    }
}
