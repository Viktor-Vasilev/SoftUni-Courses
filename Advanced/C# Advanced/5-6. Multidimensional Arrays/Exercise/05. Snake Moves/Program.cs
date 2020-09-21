using System;
using System.Linq;

namespace _2._Exer_05._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            string snakeName = Console.ReadLine();

            char[,] matrix = new char[rows, cols];

            // PrintMatrix(matrix); 

            int currentLetter = 0;

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = snakeName[currentLetter];

                        currentLetter++;

                        if (currentLetter == snakeName.Length)
                        {
                            currentLetter = 0;
                        }
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snakeName[currentLetter];

                        currentLetter++;

                        if (currentLetter == snakeName.Length)
                        {
                            currentLetter = 0;
                        }
                    }
                }
                
               
            }


            PrintMatrix(matrix);

        }

        static char[,] ReadMatrix(int rows, int cols)
        {

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;

        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

    }
    
}
