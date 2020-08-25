using System;

namespace Test_Exam_Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string sushiName = Console.ReadLine();
            string restaurant = Console.ReadLine();
            int broiPorcii = int.Parse(Console.ReadLine());
            string symbol = Console.ReadLine();

            double price = 0;

            if (restaurant == "Sushi Zone" || restaurant == "Sushi Time" || restaurant == "Sushi Bar" || restaurant == "Asian Pub")
            {

                if (sushiName == "sashimi")
                {
                    if (restaurant == "Sushi Zone")
                    {
                        price = 4.99;
                    }
                    if (restaurant == "Sushi Time")
                    {
                        price = 5.49;
                    }
                    if (restaurant == "Sushi Bar")
                    {
                        price = 5.25;
                    }
                    if (restaurant == "Asian Pub")
                    {
                        price = 4.50;
                    }
                }

                if (sushiName == "maki")
                {
                    if (restaurant == "Sushi Zone")
                    {
                        price = 5.29;
                    }
                    if (restaurant == "Sushi Time")
                    {
                        price = 4.69;
                    }
                    if (restaurant == "Sushi Bar")
                    {
                        price = 5.55;
                    }
                    if (restaurant == "Asian Pub")
                    {
                        price = 4.80;
                    }
                }

                if (sushiName == "uramaki")
                {
                    if (restaurant == "Sushi Zone")
                    {
                        price = 5.99;
                    }
                    if (restaurant == "Sushi Time")
                    {
                        price = 4.49;
                    }
                    if (restaurant == "Sushi Bar")
                    {
                        price = 6.25;
                    }
                    if (restaurant == "Asian Pub")
                    {
                        price = 5.50;
                    }
                }

                if (sushiName == "temaki")
                {
                    if (restaurant == "Sushi Zone")
                    {
                        price = 4.29;
                    }
                    if (restaurant == "Sushi Time")
                    {
                        price = 5.19;
                    }
                    if (restaurant == "Sushi Bar")
                    {
                        price = 4.75;
                    }
                    if (restaurant == "Asian Pub")
                    {
                        price = 5.50;
                    }
                }

                double total = broiPorcii * price;

                if (symbol == "Y")
                {
                    total *= 1.20;
                }

                Console.WriteLine($"Total price: {Math.Ceiling(total)} lv.");

            }
            else
            {
                Console.WriteLine($"{restaurant} is invalid restaurant!");
            }
        }
    }
}
