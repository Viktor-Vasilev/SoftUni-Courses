using System;
using System.Data;
using System.Linq;

namespace _1_Exam_Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];

            string command = Console.ReadLine();

            while (command != "Bloom Bloom Plow")
            {

                int[] boza = command.Split().Select(int.Parse).ToArray();
                int rowss = boza[0];
                int colss = boza[1];

                if (rowss < 0 || colss > matrix.GetLength(1))
                {
                    Console.WriteLine($"Invalid coordinates.");

                }


                Plant(matrix, rowss, colss);

                //PrintMatrix(matrix);

                command = Console.ReadLine();
            }




            PrintMatrix(matrix);

        }

        private static void Plant(int[,] matrix, int rows, int cols)
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == rows)
                    {
                        matrix[row, col] = matrix[row, col] + 1;
                    }
                    else if (col == cols)
                    {
                        matrix[row, col] = matrix[row, col] + 1;
                    }
                }
            }
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
