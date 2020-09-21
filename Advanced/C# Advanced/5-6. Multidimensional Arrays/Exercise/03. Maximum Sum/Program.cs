using System;
using System.Linq;

namespace _2._Exer_03._Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            int[,] matrix = ReadMatrix(rows, cols);

            // PrintMatrix(matrix);

            int maxSum = int.MinValue;

            int maxRow = -1;

            int maxCol = -1;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int i = maxRow; i <= maxRow + 2; i++)
            {
                for (int j = maxCol; j <= maxCol + 2; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }

            //Console.WriteLine($"{matrix[indexRow, indexCol]} {matrix[indexRow, indexCol + 1]} {matrix[indexRow, indexCol + 2]}");
            //Console.WriteLine($"{matrix[indexRow + 1, indexCol]} {matrix[indexRow + 1, indexCol + 1]} " +
            //    $"{matrix[indexRow + 1, indexCol + 2]}");
            //Console.WriteLine($"{matrix[indexRow + 2, indexCol]} {matrix[indexRow + 2, indexCol + 1]} " +
            //    $"{matrix[indexRow + 2, indexCol + 2]}");




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

        static int[,] ReadMatrix(int rows, int cols)
        {

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;

        }

    }
}
