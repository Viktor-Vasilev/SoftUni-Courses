using System;

namespace _2.Ex_05._Add_And_Substract
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int sum = Sum(num1, num2);
            int result = Substract(sum, num3);

            Console.WriteLine(result);


        }
        static int Sum(int a, int b)
        {
            return a + b;
        }

        static int Substract(int c, int d)
        {
            return c - d;
        }

    }
}
