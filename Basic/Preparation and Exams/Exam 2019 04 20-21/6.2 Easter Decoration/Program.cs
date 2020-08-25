using System;

namespace Izpit_20190420_6._2_Easter_Decoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int numClients = int.Parse(Console.ReadLine());

            double allClientsSum = 0;

            double price = 0;

            for (int client = 0; client < numClients; client++)
            {
                string item = Console.ReadLine();

                int productCounter = 0;

                double currentClientSum = 0;

                while (item != "Finish")
                {
                    if (item == "basket")
                    {
                        price = 1.50;                        
                    }
                    if (item == "wreath")
                    {
                        price = 3.80;
                    }
                    if (item == "chocolate bunny")
                    {
                        price = 7.00;                      
                    }

                    productCounter++;                   

                    currentClientSum += price;

                    item = Console.ReadLine();
                }

                if (productCounter % 2 == 0)
                {
                    currentClientSum *= 0.80;
                }

                Console.WriteLine($"You purchased {productCounter} items for {currentClientSum:F2} leva.");

                allClientsSum += currentClientSum;
            }

            double averageForClient = allClientsSum / numClients;

            Console.WriteLine($"Average bill per client is: {averageForClient:F2} leva.");
        }
    }
}
