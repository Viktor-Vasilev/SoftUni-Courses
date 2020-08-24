using System;

namespace _03._2D_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double a1 = double.Parse(Console.ReadLine());
            double b1 = double.Parse(Console.ReadLine());
            double a2 = double.Parse(Console.ReadLine());
            double b2 = double.Parse(Console.ReadLine());
            double lenght = Math.Abs(a1 - a2);
            double width = Math.Abs(b1 - b2);

            double area = lenght * width;
            double perimeter = (lenght + width) * 2;
            Console.WriteLine($"{area:F2}");
            Console.WriteLine($"{perimeter:F2}");

        }
    }
}
