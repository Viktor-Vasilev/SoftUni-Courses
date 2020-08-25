using System;
using System.Net.Http.Headers;

namespace _5._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());


            Orders(product, quantity);



        }

        static void Orders(string product, int quantity)
        {
            double price = 0;

            if (product == "coffee")
            {
                price = 1.50;
            }
            else if (product == "water")
            {
                price = 1.00;
            }
            else if (product == "coke")
            {
                price = 1.40;
            }
            else if (product == "snacks")
            {
                price = 2.00;
            }

            double sum = price * quantity;

            Console.WriteLine($"{sum:f2}");

        }






    }
}
