﻿using System;

namespace _1._Lab_3._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            string text = Console.ReadLine();

            int index = text.IndexOf(word);

            while (index >= 0)
            {
                text = text.Remove(index, word.Length);
                index = text.IndexOf(word);
            }

            Console.WriteLine(text);

        }
    }
}
