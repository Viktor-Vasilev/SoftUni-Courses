using System;

namespace _06._Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int firstDigit = 97; firstDigit < 97 + n; firstDigit++)
            {
                for (int secondDigit = 97; secondDigit < 97 + n; secondDigit++)
                {
                    for (int thirdDigit = 97; thirdDigit < 97 + n; thirdDigit++)
                    {
                        Console.WriteLine($"{(char)firstDigit}{(char)secondDigit}{(char)thirdDigit}");
                    }

                }
            }

        }
    }
}
