using System;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int copyNum = num;

            int currentNum = 0;
            int factorialSum = 0;

            while (copyNum != 0)
            {
                currentNum = copyNum % 10;
                copyNum = copyNum / 10;

                int factorial = 1;

                for (int i = 1; i <= currentNum; i++)
                {
                    factorial *= i;
                }
                factorialSum += factorial;

            }

            if (num == factorialSum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }





        }
    }
}
