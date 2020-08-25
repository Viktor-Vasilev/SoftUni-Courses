using System;

namespace _04._Refactoring_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());

            for (int i = 2; i <= times; i++)
            {
                bool isPrime = true;

                for (int divider = 2; divider < i; divider++)
                {
                    if (i % divider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime == true)
                {
                    Console.WriteLine("{0} -> {1}", i, "true");
                }
                else
                {
                    Console.WriteLine("{0} -> {1}", i, "false"); ;
                }
            }
        }
    }
}
