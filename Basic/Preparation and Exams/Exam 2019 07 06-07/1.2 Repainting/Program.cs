using System;

namespace Izpit_20190706_1._2_Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            int nylon = int.Parse(Console.ReadLine());
            int boq = int.Parse(Console.ReadLine());
            int razreditel = int.Parse(Console.ReadLine());
            int chasove = int.Parse(Console.ReadLine());

            double priceNylon = 1.50;
            double priceboq = 14.50;
            double priceRazreditel = 5.00;

            double realnoboq = boq * 1.10;
            double realnonylon = nylon + 2;
            double torbichki = 0.40;

            double totalMateriali = ((realnoboq * priceboq) + (realnonylon * priceNylon) + (razreditel * priceRazreditel) + torbichki);
            double cenaMaistoriNaChas = totalMateriali * 0.30;
            double grandTotal = totalMateriali + (cenaMaistoriNaChas * chasove);
            Console.WriteLine($"Total expenses: {grandTotal:F2} lv.");


        }
    }
}
