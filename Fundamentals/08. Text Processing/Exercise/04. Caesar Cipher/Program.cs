using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace _2._Exer_4._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
                        // 1
            
            //string input = Console.ReadLine();

            //string encrypted = string.Empty;

            //foreach (char symbol in input)
            //{
            //    encrypted += (char)(symbol + 3);
            //}

            //Console.WriteLine(encrypted);



                        // 2


            //string text = Console.ReadLine();

            //string encrypted = String.Empty;

            //for (int i = 0; i < text.Length; i++)
            //{
            //    encrypted += (char)(text[i] + 3);
            //}

            //Console.WriteLine(encrypted);

                        // 3

            char[] outText = Console.ReadLine()
                .Select(x => x + 3)
                .Select(x => (char)x)
                .ToArray();
            Console.WriteLine(String.Join("", outText));
        }
    }
}
