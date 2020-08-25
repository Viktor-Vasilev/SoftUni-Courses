using System;

namespace _02._Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfProjection = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int column = int.Parse(Console.ReadLine());

            int seats = row * column;
            double price = 0;

            switch (typeOfProjection)
            {
                case "Premiere":
                    price = 12.00;
                    break;
                case "Normal":
                    price = 7.50;
                    break;
                case "Discount":
                    price = 5.00;
                    break;
            }

            double income = seats * price;

            Console.WriteLine($"{income:F2} leva");
        }
    }
}
