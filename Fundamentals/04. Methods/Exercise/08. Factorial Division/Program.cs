using System;

namespace _2.Ex_08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {

            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());


            decimal result = CalcFactorial(num1) / CalcFactorial(num2);

            Console.WriteLine($"{result:F2}");



        }
        static decimal CalcFactorial(int num)
        {
            

            decimal factorial = 1;

            for (int i = 1; i <= num; i++)
            {
                factorial *= i;
            }

            return factorial;


        }


    }
}
