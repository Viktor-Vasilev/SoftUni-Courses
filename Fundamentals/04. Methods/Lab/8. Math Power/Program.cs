using System;

namespace _8._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            double result = CalculatePower(number, power);
            Console.WriteLine(result);
        }

        public static double CalculatePower(double number, int power)
        {
            double result = number;
            for (int num = 1; num < power; num++)
            {
                result *= number;
            }
            return result;
        }
    }




    
}
