using System;

namespace Podgotovka_za_izpit_201912_1._Koledni_Lakomstva
{
    class Program
    {
        static void Main(string[] args)
        {
            double prBaklava = double.Parse(Console.ReadLine());
            double prMufini = double.Parse(Console.ReadLine());
            double kgShtolen = double.Parse(Console.ReadLine());
            double kgBonboni = double.Parse(Console.ReadLine());
            double kgBiskviti = double.Parse(Console.ReadLine());

            double prShtonel = prBaklava * 1.6;
            double prBonboni = prMufini * 1.8;
            double prBiskviti = 7.50;

            double total = kgShtolen * prShtonel + kgBonboni * prBonboni + kgBiskviti * prBiskviti;

            Console.WriteLine($"{total:F2}");


        }
    }
}
