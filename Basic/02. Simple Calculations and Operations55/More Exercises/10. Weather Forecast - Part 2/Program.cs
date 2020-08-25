using System;

namespace _10._Weather_Forecast___Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double weather = double.Parse(Console.ReadLine());
            if (weather >= 35.00)
            {
                Console.WriteLine("unknown");
            }
            else if (weather >= 26.00)
            {
                Console.WriteLine("Hot");
            }
            else if (weather >= 20.10)
            {
                Console.WriteLine("Warm");
            }
            else if (weather >= 15.00)
            {
                Console.WriteLine("Mild");
            }
            else if (weather >= 20.10)
            {
                Console.WriteLine("Warm");
            }
            else if (weather >= 12.00)
            {
                Console.WriteLine("Cool");
            }
            else if (weather >= 5.00)
            {
                Console.WriteLine("Cold");
            }
            else if (weather >= 5.0)
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
