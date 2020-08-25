using System;

namespace _01._USD_to_BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());
            double leva = usd * 1.79549;
            Console.WriteLine($"{leva:f2}");
        }
    }
}
