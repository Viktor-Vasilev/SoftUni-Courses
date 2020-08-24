using System;

namespace _02._Sleepy_Tom_Cat
{
    class Program
    {
        static void Main(string[] args)
        {
            int pochivniDni = int.Parse(Console.ReadLine());
            int rabotniDni = 365 - pochivniDni;
            int vremeZaIgra = ((pochivniDni * 127) + (rabotniDni * 63));
            if (vremeZaIgra > 30000)
            {
                int ChasovePoveche = (vremeZaIgra - 30000) / 60;
                int MinutiPoveche = (vremeZaIgra - 30000) % 60;
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{ChasovePoveche} hours and {MinutiPoveche} minutes more for play");
            }
            else if (vremeZaIgra < 30000)
            {
                int ChasovePoveche = (30000 - vremeZaIgra) / 60;
                int MinutiPoveche = (30000 - vremeZaIgra) % 60;
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{ChasovePoveche} hours and {MinutiPoveche} minutes less for play");
            }
        }
    }
}
