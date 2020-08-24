using System;

namespace _04._Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string vhod = Console.ReadLine();
            string izhod = Console.ReadLine();
            if (vhod == "mm" && izhod == "cm")
            {
                Console.WriteLine($"{number / 10:F3}");
            }
            else if (vhod == "mm" && izhod == "m")
            {
                Console.WriteLine($"{number / 1000:F3}");
            }
            else if (vhod == "cm" && izhod == "mm")
            {
                Console.WriteLine($"{number * 10:F3}");
            }
            else if (vhod == "cm" && izhod == "m")
            {
                Console.WriteLine($"{number / 100:F3}");
            }
            else if (vhod == "m" && izhod == "mm")
            {
                Console.WriteLine($"{number * 1000:F3}");
            }
            else if (vhod == "m" && izhod == "cm")
            {
                Console.WriteLine($"{number * 100:F3}");
            }
        }
    }
}
