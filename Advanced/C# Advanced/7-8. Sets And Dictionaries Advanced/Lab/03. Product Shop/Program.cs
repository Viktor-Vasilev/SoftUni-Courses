using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Lab_03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();

            while (input != "Revision")
            {
                string[] splitted = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shopName = splitted[0];
                string product = splitted[1];
                double price = double.Parse(splitted[2]);

                if (!shops.ContainsKey(shopName))
                {
                    shops.Add(shopName, new Dictionary<string, double>());
                }

                if (!shops[shopName].ContainsKey(product))
                {
                    shops[shopName].Add(product, price);
                }                

                input = Console.ReadLine();
            }

            shops = shops.OrderBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }

        }
    }
}
