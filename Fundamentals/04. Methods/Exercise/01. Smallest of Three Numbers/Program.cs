using System;

namespace _2.Ex_Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            PrintSmallestNumber(num1, num2, num3);
        }


        static void PrintSmallestNumber (int num1, int num2, int num3)
        {
            int smallestNumber = 0;

            if (num1 <= num2 && num1 <= num3)
            {
                smallestNumber = num1;
            }
            else if (num2 <= num1 && num2 <= num3)
            {
                smallestNumber = num2;
            }
            else
            {
                smallestNumber = num3;
            }

            Console.WriteLine(smallestNumber);






        }
    }
}
