using System;

namespace _04._Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // без булева също си работи 100/100!!!!

            //int startNumber = int.Parse(Console.ReadLine());
            //int endNumber = int.Parse(Console.ReadLine());
            //int magicNumber = int.Parse(Console.ReadLine());

            //int counter = 0;

            //for (int num1 = startNumber; num1 <= endNumber; num1++)
            //{
            //    for (int num2 = startNumber; num2 <= endNumber; num2++)
            //    {
            //        counter++;
            //        int sum = num1 + num2;
            //        if (sum == magicNumber)
            //        {
            //            Console.WriteLine($"Combination N:{counter} ({num1} + {num2} = {magicNumber})");
            //            return;
            //        }

            //    }

            //}

            //Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");




            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int counter = 0;

            bool isFound = false;

            for (int num1 = startNumber; num1 <= endNumber; num1++)
            {
                for (int num2 = startNumber; num2 <= endNumber; num2++)
                {
                    counter++;
                    int sum = num1 + num2;
                    if (sum == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{counter} ({num1} + {num2} = {magicNumber})");
                        isFound = true;
                        break;
                    }
                }
                if (isFound)
                {
                    break;
                }

            }

            if (!isFound)
            Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");
        }
    }
}
