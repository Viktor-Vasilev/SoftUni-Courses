using System;

namespace _05._Training_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double numberOfDesksWidht = ((width * 100) - 100) / 70;
            double numberofDesks1 = Math.Floor(numberOfDesksWidht);
            // Console.WriteLine(numberofDesks1);
            double numberOfDesksLenght = ((lenght * 100) / 120);
            double numberOfDesks2 = Math.Floor(numberOfDesksLenght);
            // Console.WriteLine(numberOfDesks2);
            double seats = (numberofDesks1 * numberOfDesks2) - 3;
            Console.WriteLine(seats);
        }
    }
}
