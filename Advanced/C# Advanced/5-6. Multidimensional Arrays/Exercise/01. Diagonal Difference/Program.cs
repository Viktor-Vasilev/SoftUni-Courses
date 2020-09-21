using System;
using System.Globalization;
using System.Linq;

namespace _2._Exer_01._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            int[,] matrix = ReadMatrix(n, n);

            // PrintMatrix(matrix);

            //int primaryDiagonalSum = 0;

            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    primaryDiagonalSum += matrix[i, i];
            //}

            //int secondaryDiagonalSum = 0;

            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    secondaryDiagonalSum += matrix[row, (matrix.GetLength(1) - 1) - row];
            //}

            //Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));

            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    int currentNumber = matrix[row, col];

                    if (row == col) // за главния диагонал
                    {
                        primaryDiagonalSum += currentNumber;
                    }

                    if (col == n -1 - row) // Формула за второстепенен диагонал !!!
                    {
                        secondaryDiagonalSum += currentNumber;
                    }
                }
            }

            Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));

        }

        static int[,] ReadMatrix(int rows, int cols)
        {

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;

        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
