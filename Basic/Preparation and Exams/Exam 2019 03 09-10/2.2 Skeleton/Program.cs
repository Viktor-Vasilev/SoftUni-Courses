using System;

namespace Izpit_20190309_2._2_Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {
            double kontrolaMin = double.Parse(Console.ReadLine());
            double kontrolaSec = double.Parse(Console.ReadLine());
            double lenghtUlej = double.Parse(Console.ReadLine());
            double secsPer100m = double.Parse(Console.ReadLine());
            double kontrola = (kontrolaMin * 60 + kontrolaSec);
            double patiNamalenoVreme = lenghtUlej / 120;
            // Console.WriteLine(patiNamalenoVreme);
            double namalenovreme = patiNamalenoVreme * 2.5;
            // Console.WriteLine(namalenovreme);
            double realnoVreme = (lenghtUlej / 100) * secsPer100m - namalenovreme;
            // Console.WriteLine(realnoVreme);
            double nestignali = realnoVreme - kontrola;
            if (kontrola >= realnoVreme)
            {
                Console.WriteLine("Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {realnoVreme:F3}.");

            }
            else

                Console.WriteLine($"No, Marin failed! He was {nestignali:F3} second slower.");




        }
    }
}
