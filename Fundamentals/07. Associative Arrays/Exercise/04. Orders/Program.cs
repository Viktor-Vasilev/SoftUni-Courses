﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_Exer_04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            // с клас и обект !!!!!!!!!

            //    var products = new Dictionary<string, Product>();

            //    while (true)
            //    {
            //        string input = Console.ReadLine();
            //        if (input == "buy")
            //        {
            //            break;
            //        }

            //        string[] splittedInput = input.Split();

            //        string name = splittedInput[0];
            //        double price = double.Parse(splittedInput[1]);
            //        int quantity = int.Parse(splittedInput[2]);

            //        Product product = new Product(name, price, quantity);

            //        // нямаме го в речника

            //        if (!products.ContainsKey(name))
            //        {
            //            products.Add(name, product);
            //        }
            //        else // ако го имаме
            //        {
            //            products[name].Price = price;
            //            products[name].Quantity += quantity;
            //        }

            //    }

            //    foreach (var pair in products)
            //    {
            //        Console.WriteLine($"{pair.Key} -> {pair.Value.Price * pair.Value.Quantity:f2}");
            //    }


            //}

            //class Product
            //{
            //    string name;
            //    double price;
            //    int quantity;

            //    public Product(string name, double price, int quantity)
            //    {
            //        this.name = name;
            //        this.price = price;
            //        this.quantity = quantity;
            //    }

            //    public double Price
            //    {
            //        get
            //        {
            //            return price;
            //        }
            //        set
            //        {
            //            price = value;
            //        }
            //    }

            //    public int Quantity
            //    {
            //        get
            //        {
            //            return quantity;
            //        }
            //        set
            //        {
            //            quantity = value;
            //        }
            //    }

            Dictionary<string, List<double>> goods = new Dictionary<string, System.Collections.Generic.List<double>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "buy")
                {
                    break;
                }

                string[] splitted = input.Split();

                string good = splitted[0];
                double price = double.Parse(splitted[1]);
                double quantity = double.Parse(splitted[2]);


                if (!goods.ContainsKey(good))
                {
                    goods.Add(good, new List<double>() { price, quantity });
                }
                else
                {
                    goods[good][0] = price;
                    goods[good][1] += quantity;
                }

            }

            foreach (var pair in goods)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value[0] * pair.Value[1]:f2}");
            }


        }
    }
}
