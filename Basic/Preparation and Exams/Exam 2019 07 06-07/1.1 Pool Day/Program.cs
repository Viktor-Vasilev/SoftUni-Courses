using System;

namespace Izpit_20190706_1._1_Pool_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPeople = int.Parse(Console.ReadLine());
            double TaksaVhod = double.Parse(Console.ReadLine());
            double PriceShezlong = double.Parse(Console.ReadLine());
            double PriceChadyr = double.Parse(Console.ReadLine());

            double sumVhod = numPeople * TaksaVhod;

            double numChadyri = Math.Ceiling(numPeople * 1.0 / 2);
            double sumChadyri = numChadyri * PriceChadyr;

            double numShezlongi = Math.Ceiling(numPeople * 1.0 * 0.75);
            double sumShezlongi = numShezlongi * PriceShezlong;

            double total = sumVhod + sumChadyri + sumShezlongi;

            Console.WriteLine($"{total:F2} lv.");


        }
    }
}
