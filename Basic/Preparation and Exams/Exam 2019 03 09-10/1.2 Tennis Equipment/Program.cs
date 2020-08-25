using System;

namespace Izpit_20190309_1._2_Tennis_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceRaketa = double.Parse(Console.ReadLine());
            int numRaketi = int.Parse(Console.ReadLine());
            int numMaratonki = int.Parse(Console.ReadLine());
            double sumaRaketi = priceRaketa * numRaketi;
            double priceMaratonki = priceRaketa / 6;
            // Console.WriteLine(priceMaratonki);
            double sumaMaratonki = priceMaratonki * numMaratonki;
            // Console.WriteLine(sumaMaratonki);
            double sumaOborudvane = (sumaRaketi + sumaMaratonki) * 0.2;
            // Console.WriteLine(sumaOborudvane);
            double Djokovich = Math.Floor((sumaMaratonki + sumaRaketi + sumaOborudvane) / 8);
            double sponsori = Math.Ceiling((sumaMaratonki + sumaRaketi + sumaOborudvane) * 7 / 8);
            Console.WriteLine($"Price to be paid by Djokovic {Djokovich}");
            Console.WriteLine($"Price to be paid by sponsors {sponsori}");



        }
    }
}
