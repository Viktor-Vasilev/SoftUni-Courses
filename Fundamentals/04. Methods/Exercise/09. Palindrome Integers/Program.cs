using System;
using System.Linq;

namespace _2.Ex_09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                Console.WriteLine(CheckIfPAlindrome(input).ToString().ToLower());
                input = Console.ReadLine();
            }

        }

        static bool CheckIfPAlindrome(string text)
        {
            var reversed = text.Reverse().ToArray();

            for (int i = 0; i < text.Length; i++)
            {
                if (!(reversed[i] == text[i]))
                {
                    return false;
                }
            }
            return true;
        }


    }
}
