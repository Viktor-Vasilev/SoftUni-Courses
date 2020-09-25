using System;
using System.Collections.Generic;

namespace _1._Lab_07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vips = new HashSet<string>();

            HashSet<string> guests = new HashSet<string>();

            string ïnput = Console.ReadLine();

            while (ïnput != "PARTY")
            {
                if (Char.IsDigit(ïnput[0]))
                {
                    vips.Add(ïnput);
                }
                else
                {
                    guests.Add(ïnput);
                }
                ïnput = Console.ReadLine();
            }

            ïnput = Console.ReadLine();

            while (ïnput != "END")
            {
                if (Char.IsDigit(ïnput[0]))
                {
                    vips.Remove(ïnput);
                }
                else
                {
                    guests.Remove(ïnput);
                }
                ïnput = Console.ReadLine();
            }

            Console.WriteLine(guests.Count + vips.Count);

            foreach (var vip in vips)
            {
                Console.WriteLine(vip);
            }

            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }


        }
    }
}
