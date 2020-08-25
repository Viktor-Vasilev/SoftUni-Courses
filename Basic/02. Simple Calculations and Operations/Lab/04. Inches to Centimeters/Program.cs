using System;

namespace _04._Inches_to_Centimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inches = ");
            var Inches = double.Parse(Console.ReadLine());
            Console.WriteLine("Centimeters = " + Inches * 2.54);
        }
    }
}
