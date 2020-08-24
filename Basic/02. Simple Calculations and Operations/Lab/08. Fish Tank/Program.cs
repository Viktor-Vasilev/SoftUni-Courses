using System;

namespace _08._Fish_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());
            double liters = lenght * width * height * 0.001;
            double realno = (liters - (percent * liters * 0.01));
            Console.WriteLine($"{realno:f3}");
        }
    }
}
