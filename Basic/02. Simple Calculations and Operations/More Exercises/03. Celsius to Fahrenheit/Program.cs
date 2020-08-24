using System;

namespace _03._Celsius_to_Fahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            double degreeCelsium = double.Parse(Console.ReadLine());
            double degreeFahrenheit = (degreeCelsium * 1.8) + 32;
            Console.WriteLine($"{degreeFahrenheit:F2}");
        }
    }
}
