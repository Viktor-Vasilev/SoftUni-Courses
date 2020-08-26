using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Immutable;
using System.Security.Cryptography.X509Certificates;

namespace _000_boza
{

    class Program
    {
        static void Main(string[] args)
        {
            string partPrice = Console.ReadLine();

            double total = 0;

            double currentPrice = 0;

            while (partPrice != "special" && partPrice != "regular")
            {


                currentPrice = double.Parse(partPrice);

                if (currentPrice > 0)
                {
                    total += currentPrice;
                }
                else
                {
                    Console.WriteLine("Invalid price!");
                }

                partPrice = Console.ReadLine();
            }

            if (total == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            double taxes = total * 0.2;

            Console.WriteLine($"Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {total:f2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine("-----------");

            if (partPrice == "regular")
            {
                Console.WriteLine($"Total price: {total + taxes:f2}$");
            }
            else
            {
                double finalTotal = (total + taxes) * 0.9;
                Console.WriteLine($"Total price: {finalTotal:f2}$");
            }


        }

    }
}

