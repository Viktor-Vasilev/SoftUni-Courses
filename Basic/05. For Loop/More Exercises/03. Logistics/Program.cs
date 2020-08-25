using System;

namespace _03._Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int numLoads = int.Parse(Console.ReadLine());

            int loadsMikrobus = 0;
            int loadsKamion = 0;
            int loadsVlak = 0;

            int priceForTonMikrobus = 200;
            int priceForTonKamion = 175;
            int priceForTonVlak = 120;


            for (int i = 1; i <= numLoads; i++)
            {
                int tons = int.Parse(Console.ReadLine());
                if (tons <= 3)
                {
                    loadsMikrobus += tons;
                }
                else if (tons > 3 && tons <= 11)
                {
                    loadsKamion += tons;
                }
                else
                {
                    loadsVlak += tons;
                }
            }

            int allTons = loadsMikrobus + loadsKamion + loadsVlak;

            double priceAll = (loadsMikrobus * priceForTonMikrobus) + (loadsKamion * priceForTonKamion) + (loadsVlak * priceForTonVlak);

            double medialPrice = priceAll * 1.0 / allTons;

            double percentMikrobus = (loadsMikrobus * 1.0 / allTons) * 100;
            double percentKamion = (loadsKamion * 1.0 / allTons) * 100;
            double percentVlak = (loadsVlak * 1.0 / allTons) * 100;

            Console.WriteLine($"{medialPrice:F2}");
            Console.WriteLine($"{percentMikrobus:F2}%");
            Console.WriteLine($"{percentKamion:F2}%");
            Console.WriteLine($"{percentVlak:F2}%");
        }
    }
}
