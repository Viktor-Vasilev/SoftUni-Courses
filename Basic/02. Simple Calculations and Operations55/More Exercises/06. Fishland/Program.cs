using System;

namespace _06._Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceSkumriq = double.Parse(Console.ReadLine());
            double priceCaca = double.Parse(Console.ReadLine());
            double kgPalamud = double.Parse(Console.ReadLine());
            double kgSafrid = double.Parse(Console.ReadLine());
            double kgMidi = double.Parse(Console.ReadLine());
            double priceMidi = 7.50;
            double pricePalamud = priceSkumriq * 1.60;
            double priceSafrid = priceCaca * 1.80;
            double money = ((pricePalamud * kgPalamud) + (priceSafrid * kgSafrid) + (priceMidi * kgMidi));
            Console.WriteLine($"{money:F2}");
        }
    }
}
