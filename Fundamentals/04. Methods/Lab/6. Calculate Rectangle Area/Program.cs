using System;

namespace _6._Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {

            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int result = CalculateRectangleArea(a, b);
            Console.WriteLine(result);


           // Console.WriteLine(CalculateRectangleArea(a, b));

        }
        static int CalculateRectangleArea(int a, int b)
        {
            return a * b;
        }


    }
}
