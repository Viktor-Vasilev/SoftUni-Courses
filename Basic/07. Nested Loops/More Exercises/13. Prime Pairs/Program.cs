using System;

namespace _13._Prime_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // НАМИРАНЕ ДАЛИ ЕДНО ЧИСЛО Е ПРОСТО!!!!!
            //int num = int.Parse(Console.ReadLine());
            //int counter = 0;

            //for (int i = 1; i <= num; i++) // Задължително трябва да има в проверката и РАВНО(=)!!!
            //{
            //    if (num % i == 0)
            //    {
            //        counter++;
            //    }
            //}
            //if (counter == 2)
            //{
            //    Console.WriteLine($"The number {num} is Prime");
            //}
            //else
            //{
            //    Console.WriteLine($"The number {num} is not Prime");
            //}

            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());

                int num1To = int.Parse(Console.ReadLine());
                int num2To = int.Parse(Console.ReadLine());

                for (int n = num1; n <= num1 + num1To; n++)
                {
                    for (int m = num2; m <= num2 + num2To; m++)
                    {
                        bool isNPrime = true;
                        bool isMPrime = true;

                        for (int i = 2; i <= Math.Sqrt(n); i++)
                        {
                            if (n % i == 0)
                            {
                                isNPrime = false;
                                break;
                            }
                        }
                        for (int j = 2; j <= Math.Sqrt(m); j++)
                        {
                            if (m % j == 0)
                            {
                                isMPrime = false;
                                break;
                            }
                        }

                        if (isNPrime && isMPrime)
                        {
                            Console.WriteLine($"{n}{m}");
                        }
                    }
                }
            }
        }
    }





}

//100/100!

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Prime_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int firstDif = int.Parse(Console.ReadLine());
            int secondDif = int.Parse(Console.ReadLine());

            for (int a = firstNum; a <= firstNum + firstDif; a++)
            {
                for (int b = secondNum; b <= secondNum + secondDif; b++)
                {
                    if (a % 2 != 0 && a % 3 != 0 && a % 5 != 0 && a % 7 != 0 && b % 2 != 0 && b % 3 != 0 && b % 5 != 0 && b % 7 != 0)
                    {
                        Console.WriteLine($"{a}{b}");
                    }
                }
            }
        }
    }
}


