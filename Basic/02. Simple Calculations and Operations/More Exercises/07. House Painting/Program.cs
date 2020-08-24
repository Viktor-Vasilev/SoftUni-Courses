using System;

namespace _07._House_Painting
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double areaVrata = 1.2 * 2.0;
            double areaWindows = 1.5 * 1.5 * 2;
            double areaHouse = (((x * x) + (x * y)) * 2) - (areaVrata + areaWindows);
            double greenPaint = areaHouse / 3.4;
            double areaRoof = (x * y * 2) + ((x * h / 2) * 2);
            // Console.WriteLine(areaRoof);
            double redPaint = areaRoof / 4.3;
            Console.WriteLine($"{greenPaint:F2}");
            Console.WriteLine($"{redPaint:F2}");
        }
    }
}
