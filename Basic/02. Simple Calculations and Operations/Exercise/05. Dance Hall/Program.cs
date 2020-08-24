using System;

namespace _05._Dance_Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double widht = double.Parse(Console.ReadLine());
            double sideWardrobe = double.Parse(Console.ReadLine());

            double hallArea = lenght * 100 * widht * 100;
            double wardrobe = sideWardrobe * 100 * sideWardrobe * 100;
            double bench = hallArea / 10;
            double freeSpace = hallArea - wardrobe - bench;
            double dancers = freeSpace / (40 + 7000);

            Console.WriteLine(Math.Floor(dancers));
        }
    }
}
