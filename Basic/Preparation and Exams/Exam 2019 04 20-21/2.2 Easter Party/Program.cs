using System;

namespace Izpit_20190420_2._2_Velikdensko_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int numGuests = int.Parse(Console.ReadLine());
            double initialPriceKuvert = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double priceCake = budget * 0.10;
            double totalExpensesKuverti = 0;
            

            if (numGuests < 10)
            {
                double totalExpenses = ((numGuests * initialPriceKuvert) + priceCake);
                if (budget >= totalExpenses)
                {
                    Console.WriteLine($"It is party time! {budget - totalExpenses:F2} leva left.");
                }
                else if (budget < totalExpenses)
                {
                    Console.WriteLine($"No party! {totalExpenses - budget:F2} leva needed.");
                }
            }
            else if (numGuests >= 10 && numGuests <= 15)
            {
                double totalExpenses = ((numGuests * initialPriceKuvert * 0.85) + priceCake);
                if (budget >= totalExpenses)
                {
                    Console.WriteLine($"It is party time! {budget - totalExpenses:F2} leva left.");
                }
                else if (budget < totalExpenses)
                {
                    Console.WriteLine($"No party! {totalExpenses - budget:F2} leva needed.");
                }
            }
            else if (numGuests >= 16 && numGuests <= 20)
            {
                double totalExpenses = ((numGuests * initialPriceKuvert * 0.80) + priceCake);
                if (budget >= totalExpenses)
                {
                    Console.WriteLine($"It is party time! {budget - totalExpenses:F2} leva left.");
                }
                else if (budget < totalExpenses)
                {
                    Console.WriteLine($"No party! {totalExpenses - budget:F2} leva needed.");
                }
            }
            else if (numGuests >= 21)
            {
                double totalExpenses = ((numGuests * initialPriceKuvert * 0.75) + priceCake);
                if (budget >= totalExpenses)
                {
                    Console.WriteLine($"It is party time! {budget - totalExpenses:F2} leva left.");
                }
                else if (budget < totalExpenses)
                {
                    Console.WriteLine($"No party! {totalExpenses - budget:F2} leva needed.");
                }
            }

            // Великденско парти -изпитна задача

            // int guests = int.Parse(Console.ReadLine());
            // double pricePerOneGuest = double.Parse(Console.ReadLine());
            // double budget = double.Parse(Console.ReadLine());

            // double totalCost = 0.0;
            // double pricePerGuestAfterDiscount = 0.0;
            // double cakePrice = budget * 0.10;

            // if (guests < 10)
            //{
            //    pricePerGuestAfterDiscount = pricePerOneGuest;
            //    totalCost = guests * pricePerGuestAfterDiscount + cakePrice;
            //}
            // else if (guests >= 10 && guests <= 15)
            //  {
            //  pricePerGuestAfterDiscount = pricePerOneGuest * (1 - 0.15);
            //  totalCost = guests * pricePerGuestAfterDiscount + cakePrice;
            // }
            // else if (guests > 15 && guests <= 20)
            // {
            //   pricePerGuestAfterDiscount = pricePerOneGuest * (1 - 0.20);
            //   totalCost = guests * pricePerGuestAfterDiscount + cakePrice;
            // }
            // else if (guests > 20)
            // {
            //  pricePerGuestAfterDiscount = pricePerOneGuest * (1 - 0.25);
            //  totalCost = guests * pricePerGuestAfterDiscount + cakePrice;
            //}

            // if (budget >= totalCost)
            // {
            //    Console.WriteLine($"It is party time! {budget - totalCost:F2} leva left.");
            //}
            //else
            // {
            //    Console.WriteLine($"No party! {totalCost - budget:F2} leva needed.");
            // }


        }
    }
}
