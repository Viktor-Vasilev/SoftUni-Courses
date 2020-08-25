using System;

namespace Podgotovka_za_izpit_201912_2._Koleden_Bazar
{
    class Program
    {
        static void Main(string[] args)
        {
            double celPari = double.Parse(Console.ReadLine());
            int fanBooks = int.Parse(Console.ReadLine());
            int horBooks = int.Parse(Console.ReadLine());
            int romBooks = int.Parse(Console.ReadLine());

            double prFan = 14.90;
            double prHor = 9.80;
            double prRom = 4.30;

            double total = fanBooks * prFan + horBooks * prHor + romBooks * prRom;

            double totalChisto = total * 0.80;



            if (totalChisto > celPari)
            {
                double gornica = totalChisto - celPari;
                double bonus = Math.Floor(gornica * 0.1);
                double darenie = totalChisto - bonus;
                Console.WriteLine($"{darenie:F2} leva donated.");
                Console.WriteLine($"Sellers will receive {bonus:F2} leva.");
            }
            else
            {
                double nedostig = celPari - totalChisto;
                Console.WriteLine($"{nedostig:F2} money needed.");
            }



        }
    }
}
