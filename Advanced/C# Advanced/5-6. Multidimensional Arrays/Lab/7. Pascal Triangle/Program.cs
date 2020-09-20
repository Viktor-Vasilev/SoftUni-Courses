﻿using System;
using System.Data;
using System.Linq;

namespace _1._Lab_07._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] pascal = new long[n][];

            int cols = 1;

            for (int row = 0; row < pascal.Length; row++)
            {
                pascal[row] = new long[cols];

                pascal[row][0] = 1;  // винаги започваме с единица
                pascal[row][pascal[row].Length - 1] = 1; // последния елемент е винаги единица

                if (row > 1)
                {
                    for (int col = 1; col < pascal[row].Length - 1; col++)
                    {
                        long[] prevRow = pascal[row - 1];
                        long firstNum = prevRow[col];
                        long secondNum = prevRow[col - 1];

                        pascal[row][col] = firstNum + secondNum;
                    }
                }

                cols++;

            }

            for (int row = 0; row < pascal.Length; row++)
            {
                for (int col = 0; col < pascal[row].Length; col++)
                {
                    Console.Write(pascal[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
