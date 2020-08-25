using System;

namespace _10._Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int product = 0;

            for (int num2 = 1; num2 <=10 ; num2++)
            {
                product = num * num2;
                Console.WriteLine($"{num} X {num2} = {product}");
            }
        }
    }
}
