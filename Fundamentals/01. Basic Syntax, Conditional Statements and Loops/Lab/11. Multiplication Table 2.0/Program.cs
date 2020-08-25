using System;

namespace _11._Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            int product1 = 0;
            int product2 = 0;

            if (num2 > 10)
            {
                product1 = num1 * num2;
                Console.WriteLine($"{num1} X {num2} = {product1}");
                return;
            }

            for (int i = num2; i <= 10; i++)
            {
                product2 = num1 * i;
                Console.WriteLine($"{num1} X {i} = {product2}");
            }
        }
    }
}
