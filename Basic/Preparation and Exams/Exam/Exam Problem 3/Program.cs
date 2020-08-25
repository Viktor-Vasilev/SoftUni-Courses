using System;

namespace Exam_Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string set = Console.ReadLine();
            int numOrderedSets = int.Parse(Console.ReadLine());
            double total = 0;

            double price = 0;

            if (set == "small")
            {
                if (fruit == "Watermelon")
                {
                    price = 56;
                }
                else if (fruit == "Mango")
                {
                    price = 36.66;
                }
                else if (fruit == "Pineapple")
                {
                    price = 42.10;
                }
                else
                {
                    price = 20;
                }
            }
            if (set == "big")
            {
                if (fruit == "Watermelon")
                {
                    price = 28.70;
                }
                else if (fruit == "Mango")
                {
                    price = 19.60;
                }
                else if (fruit == "Pineapple")
                {
                    price = 24.80;
                }
                else
                {
                    price = 15.20;
                }
            }

            if (set == "big")
            {
                total = numOrderedSets * 5 * price;
            }
            if (set == "small")
            {
                total = numOrderedSets * 2 * price;
            }

            if (total >= 400 && total <= 1000)
            {
                total *= 0.85;
            }
            if (total > 1000)
            {
                total /= 2;
            }

            Console.WriteLine($"{total:F2} lv.");
        }
    }
}
