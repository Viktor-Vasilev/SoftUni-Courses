using System;

namespace _03._Floating_Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            double number1 = double.Parse(Console.ReadLine());

            double number2 = double.Parse(Console.ReadLine());

            double eps = 0.000001;

            bool isTrue = false;
            
            if (Math.Abs(number1 - number2) < eps)
            {
                isTrue = true;
            }
            else
            {
                isTrue = false;
            }

            Console.WriteLine(isTrue);

        }
    }
}
