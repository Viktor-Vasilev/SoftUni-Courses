using System;

namespace _03._Odd__Even_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());


            double OddSum = 0;
            double OddMin = double.MaxValue;
            double OddMax = double.MinValue;
            double EvenSum = 0;
            double EvenMin = double.MaxValue;
            double EvenMax = double.MinValue;


            if (n == 1)
            {
                double num = double.Parse(Console.ReadLine());

                Console.WriteLine($"OddSum={num:F2},");
                Console.WriteLine($"OddMin={num:F2},");
                Console.WriteLine($"OddMax={num:F2},");

                Console.WriteLine("EvenSum=0.00,");
                Console.WriteLine("EvenMin=No,");
                Console.WriteLine("EvenMax=No");
            }
            else if (n == 0)
            {

                Console.WriteLine("OddSum=0.00,");
                Console.WriteLine("OddMin=No,");
                Console.WriteLine("OddMax=No,");

                Console.WriteLine("EvenSum=0.00,");
                Console.WriteLine("EvenMin=No,");
                Console.WriteLine("EvenMax=No");
            }
            else
            {
                for (int number = 1; number <= n; number++)
                {
                    double value = double.Parse(Console.ReadLine());

                    if (number % 2 != 0)
                    {
                        OddSum += value;
                        if (value < OddMin)
                        {
                            OddMin = value;
                        }
                        if (value > OddMax)
                        {
                            OddMax = value;
                        }

                    }
                    if (number % 2 == 0)
                    {
                        EvenSum += value;
                        if (value < EvenMin)
                        {
                            EvenMin = value;
                        }
                        if (value > EvenMax)
                        {
                            EvenMax = value;
                        }

                    }
                }

                Console.WriteLine($"OddSum={OddSum:F2},");
                Console.WriteLine($"OddMin={OddMin:F2},");
                Console.WriteLine($"OddMax={OddMax:F2},");
                Console.WriteLine($"EvenSum={EvenSum:F2},");
                Console.WriteLine($"EvenMin={EvenMin:F2},");
                Console.WriteLine($"EvenMax={EvenMax:F2}");
            }
        }
    }
}
