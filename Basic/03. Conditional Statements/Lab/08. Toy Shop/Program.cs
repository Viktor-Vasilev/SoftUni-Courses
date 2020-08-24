using System;

namespace _08._Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceTrip = double.Parse(Console.ReadLine());
            int numPuzzle = int.Parse(Console.ReadLine());
            int numDoll = int.Parse(Console.ReadLine());
            int numTeddybear = int.Parse(Console.ReadLine());
            int numMinion = int.Parse(Console.ReadLine());
            int numTruck = int.Parse(Console.ReadLine());
            double pricePuzzle = 2.60;
            double priceDoll = 3.00;
            double priceTeddybear = 4.10;
            double priceMinion = 8.20;
            double priceTruck = 2.00;

            double prihodi = ((numPuzzle * pricePuzzle) + (numDoll * priceDoll) + (numTeddybear * priceTeddybear) + (numMinion * priceMinion) + (numTruck * priceTruck));
            int numBuyedToys = numPuzzle + numDoll + numTeddybear + numMinion + numTruck;
            // Console.WriteLine(prihodi);
            if (numBuyedToys >= 50)
            {
                prihodi = prihodi * 0.75;
            }
            prihodi = prihodi * 0.90;
            // Console.WriteLine(prihodi);
            if (prihodi >= priceTrip)
            {
                Console.WriteLine($"Yes! {prihodi - priceTrip:F2} lv left.");
            }
            else if (prihodi < priceTrip)
            {
                Console.WriteLine($"Not enough money! {priceTrip - prihodi:F2} lv needed.");
            }
        }
    }
}
