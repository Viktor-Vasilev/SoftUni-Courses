using System;

namespace Test_Exam_Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyForFoodFor1Day = double.Parse(Console.ReadLine());
            double moneyForSouvenirsFor1Day = double.Parse(Console.ReadLine());
            double moneyForHotelFor1Day = double.Parse(Console.ReadLine());

            double distance = 420;

            

            double moneyFoodAll = moneyForFoodFor1Day * 3;

            
            double moneySouvenirsAll = moneyForSouvenirsFor1Day * 3;

            
            double moneyBenzin = (distance / 100 * 7 * 1.85);

            

            double moneyHotel = (moneyForHotelFor1Day * 0.9) + (moneyForHotelFor1Day * 0.85) + (moneyForHotelFor1Day * 0.80);

            double total = (moneyFoodAll + moneySouvenirsAll + (moneyBenzin) + moneyHotel);

            Console.WriteLine($"Money needed: {total:F2}");


        }
    }
}
