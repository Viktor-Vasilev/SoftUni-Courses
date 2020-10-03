﻿using System;
using System.Linq;

namespace _2._Exer_02._Knights_Of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputNames = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> action = name => name.ToList().ForEach(person => Console.WriteLine($"Sir {person}"));

            action(inputNames);

        }
    }
}
