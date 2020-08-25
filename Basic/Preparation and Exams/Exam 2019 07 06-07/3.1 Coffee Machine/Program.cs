using System;

namespace Izpit_20190706_3._1_Coffee_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfCoffee = Console.ReadLine();
            string sugar = Console.ReadLine();
            int numberOfCoffees = int.Parse(Console.ReadLine());

            double price = 0;

            if (typeOfCoffee == "Espresso")
            {
                if (sugar == "Without")
                {
                    price = 0.90;
                }
                else if (sugar == "Normal")
                {
                    price = 1.00;
                }
                else
                {
                    price = 1.20;
                }
            }
            else if (typeOfCoffee == "Cappuccino")
            {
                if (sugar == "Without")
                {
                    price = 1.00;
                }
                else if (sugar == "Normal")
                {
                    price = 1.20;
                }
                else
                {
                    price = 1.60;
                }
            }
            else
            {
                if (sugar == "Without")
                {
                    price = 0.50;
                }
                else if (sugar == "Normal")
                {
                    price = 0.60;
                }
                else
                {
                    price = 0.70;
                }
            }

            double total = numberOfCoffees * price;

            if (sugar == "Without")
            {
                total = total * 0.65;
            }

            if (typeOfCoffee == "Espresso" && numberOfCoffees >= 5)
            {
                total = total * 0.75;
            }

            if (total > 15.00)
            {
                total = total * 0.80;
            }

            Console.WriteLine($"You bought {numberOfCoffees} cups of {typeOfCoffee} for {total:F2} lv.");


        }
    }
}
