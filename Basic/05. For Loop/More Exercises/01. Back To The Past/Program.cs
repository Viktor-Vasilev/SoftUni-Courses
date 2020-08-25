using System;

namespace _01._Back_To_The_Past
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int yearToLive = int.Parse(Console.ReadLine());

            int spendMoney = 0;
            int age = 18;

            for (int year = 1800; year <= yearToLive; year++)
            {
                if (year % 2 == 0)
                {
                    spendMoney += 12000;
                    age++;
                }

                if (year % 2 != 0)
                {
                    spendMoney += 12000 + (50 * age);

                    age++;
                }
            }

            double difference = Math.Abs(money - spendMoney);

            if (money - spendMoney >= 0)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {difference:F2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {difference:F2} dollars to survive.");
            }
        }
    }
}
