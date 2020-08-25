using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace _1._Lab_2._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] words = Console.ReadLine().Split();

            //for (int i = 0; i < words.Length; i++)
            //{
            //    for (int j = 0; j < words[i].Length; j++)
            //    {
            //        Console.Write(words[i]);
            //    }
            //}


            string[] words = Console.ReadLine().Split();

            StringBuilder result = new StringBuilder();

            foreach (string word in words)
            {
                int count = word.Length;

                for (int i = 0; i < count; i++)
                {
                    result.Append(word);
                }

            }

            Console.WriteLine(result);

        }
    }
}
