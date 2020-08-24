using System;

namespace _08._Circle_Area_and_Perimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());
            double surface = Math.PI * r * r;
            double perimeter = 2 * Math.PI * r;
            Console.WriteLine($"{surface:F2}");
            Console.WriteLine($"{perimeter:F2}");
        }
    }
}
