using System;

namespace _04._Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTables = int.Parse(Console.ReadLine());
            double lenghtTable = double.Parse(Console.ReadLine());
            double widthTable = double.Parse(Console.ReadLine());
            double areaCover = (numberOfTables * (lenghtTable + 2 * 0.30) * (widthTable + 2 * 0.30));
            double areaSquare = (numberOfTables * (lenghtTable / 2) * (lenghtTable / 2));
            int priceCloth = 7;
            int priceSquare = 9;
            double kursLevUsd = 1.85;
            double a = ((areaCover * priceCloth) + (areaSquare * priceSquare));
            double b = (((areaCover * priceCloth) + (areaSquare * priceSquare)) * kursLevUsd);
            Console.WriteLine($"{a:f2} USD");
            Console.WriteLine($"{b:f2} BGN");
            // Console.WriteLine((areaCover * priceCloth) + (areaSquare * priceSquare));
            // Console.WriteLine(((areaCover * priceCloth) + (areaSquare * priceSquare)) * kursLevUsd);
        }
    }
}
