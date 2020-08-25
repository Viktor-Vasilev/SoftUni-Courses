using System;

namespace Izpit_20190502_4._Cinema_Voucher
{
    class Program
    {
        static void Main(string[] args)
        {
            int voucherValue = int.Parse(Console.ReadLine());
            int moviePrice = 0;
            int productPrice = 0;
            int purchasedProducts = 0;
            int purchasedTickets = 0;

            while (voucherValue >= 0)
            {
                string purchase = Console.ReadLine();
                if (purchase == "End")
                {
                    Console.WriteLine($"{purchasedTickets}");
                    Console.WriteLine($"{purchasedProducts}");
                    break;
                }
                if (purchase.Length > 8)
                {
                    moviePrice = purchase[0] + purchase[1];
                    if (moviePrice > voucherValue)
                    {
                        Console.WriteLine($"{purchasedTickets}");
                        Console.WriteLine($"{purchasedProducts}");
                        break;
                    }
                    voucherValue -= moviePrice;
                    purchasedTickets++;

                }
                else if (purchase.Length <= 8)
                {
                    productPrice = purchase[0];
                    if (productPrice > voucherValue)
                    {
                        Console.WriteLine($"{purchasedTickets}");
                        Console.WriteLine($"{purchasedProducts}");
                        break;
                    }
                    voucherValue -= productPrice;
                    purchasedProducts++;
                }
            }




        }
    }
}
