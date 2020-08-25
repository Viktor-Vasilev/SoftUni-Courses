using System;

namespace Izpit_20190420_3._2_Painting_Eggs
{
    class Program
    {
        static void Main(string[] args)
        {
            string sizeOfEggs = Console.ReadLine();
            string colorOfEggs = Console.ReadLine();
            int numberOfBatchs = int.Parse(Console.ReadLine());

            double priceFor1Batch = 0;

            if (sizeOfEggs == "Large")
            {
                if (colorOfEggs == "Red")
                {
                    priceFor1Batch = 16;
                }
                else if (colorOfEggs == "Green")
                {
                    priceFor1Batch = 12;
                }
                else
                {
                    priceFor1Batch = 9;
                }
            }
            else if (sizeOfEggs == "Medium")
            {
                if (colorOfEggs == "Red")
                {
                    priceFor1Batch = 13;
                }
                else if (colorOfEggs == "Green")
                {
                    priceFor1Batch = 9;
                }
                else
                {
                    priceFor1Batch = 7;
                }
            }
            else
            {
                if (colorOfEggs == "Red")
                {
                    priceFor1Batch = 9;
                }
                else if (colorOfEggs == "Green")
                {
                    priceFor1Batch = 8;
                }
                else
                {
                    priceFor1Batch = 5;
                }
            }

            double total = priceFor1Batch * numberOfBatchs * 0.65;

            Console.WriteLine($"{total:F2} leva.");



        }
    }
}
