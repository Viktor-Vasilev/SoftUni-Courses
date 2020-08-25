using System;

namespace _03._Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {

            string command = Console.ReadLine();

            int primeNumberSum = 0;
            int NonPrimeNumberSum = 0;


            while (command != "stop")
            {
                int currentNumber = int.Parse(command);
                if (currentNumber < 0)
                {
                    Console.WriteLine("Number is negative.");
                    command = Console.ReadLine();
                    continue;
                }

                bool isPrime = true;

                if (currentNumber == 1)
                {
                    isPrime = false;
                }
                else
                {
                    for (int i = currentNumber; i >= 2; i--)
                    {
                        if (currentNumber % i == 0 && i != currentNumber)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                }

                if (isPrime)
                {
                    primeNumberSum += currentNumber;
                }
                else
                {
                    NonPrimeNumberSum += currentNumber;
                }

                command = Console.ReadLine();
            }

            if (command == "stop")
            {
                Console.WriteLine($"Sum of all prime numbers is: {primeNumberSum}");
                Console.WriteLine($"Sum of all non prime numbers is: {NonPrimeNumberSum}");
            }

        }
    }
}
