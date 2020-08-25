using System;

namespace Izpit_20190309_1._1_Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int taksa = int.Parse(Console.ReadLine());
            double kecove = taksa * 0.6;
            double ekip = kecove * 0.8;
            double topka = ekip * 0.25;
            double aksesoari = topka * 0.2;
            double all = taksa + kecove + ekip + topka + aksesoari;
            Console.WriteLine($"{all:F2}");
        }
    }
}
