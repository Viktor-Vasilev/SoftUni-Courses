using System;

namespace _11._Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceWashingMachine = double.Parse(Console.ReadLine());
            int priceOfToy = int.Parse(Console.ReadLine());

            int savedMoney = 0;
            int moneyGift = 10;
            int numberOfToys = 0;

            for (int birthday = 1; birthday <= age; birthday++)
            {
                if (birthday % 2 == 0)
                {
                    savedMoney += moneyGift;
                    moneyGift += 10;
                    savedMoney -= 1;
                }
                else
                {
                    numberOfToys++;
                }

            }

            int moneyFromToys = numberOfToys * priceOfToy;

            int allMoney = savedMoney + moneyFromToys;

            double difference = Math.Abs(allMoney - priceWashingMachine);

            if (priceWashingMachine <= allMoney)
            {
                Console.WriteLine($"Yes! {difference:F2}");
            }
            else
            {
                Console.WriteLine($"No! {difference:F2}");
            }
        }
    }
}
