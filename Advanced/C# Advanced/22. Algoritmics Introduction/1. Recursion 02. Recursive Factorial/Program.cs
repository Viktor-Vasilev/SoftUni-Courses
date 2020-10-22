using System;

namespace _1._Recursion_02._Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {

            int input = int.Parse(Console.ReadLine());
            int result = Factorial(input);
            Console.WriteLine(result);


        }

        private static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }

    }
}
