using System;

namespace Izpit_20190727_6._1_Baking_Competition
{
    class Program
    {
        static void Main(string[] args)
        {
            int bakers = int.Parse(Console.ReadLine());

            double price = 0;

            int counterProduct = 0;

            double allSales = 0;

            for (int numBakers = 1; numBakers <= bakers; numBakers++)
            {
                string bakerName = Console.ReadLine();               

                double salesCurrentBaker = 0;

                string product = Console.ReadLine();

                int numCookies = 0;
                int numCakes = 0;
                int numWaffles = 0;

                while (product != "Stop baking!")
                {
                    
                    int numProduct = int.Parse(Console.ReadLine());

                    counterProduct += numProduct;                    

                    if (product == "cookies")
                    {
                        price = 1.50;
                        numCookies += numProduct;
                    }
                    else if (product == "cakes")
                    {
                        price = 7.80;
                        numCakes += numProduct;
                    }
                    else
                    {
                        price = 2.30;
                        numWaffles += numProduct;
                    }

                    salesCurrentBaker = price * numProduct;

                    allSales += salesCurrentBaker;

                    product = Console.ReadLine();
                }

                Console.WriteLine($"{bakerName} baked {numCookies} cookies, {numCakes} cakes and {numWaffles} waffles.");
                

            }            
            Console.WriteLine($"All bakery sold: {counterProduct}");
            Console.WriteLine($"Total sum for charity: {allSales:F2} lv.");

        }
    }
}
