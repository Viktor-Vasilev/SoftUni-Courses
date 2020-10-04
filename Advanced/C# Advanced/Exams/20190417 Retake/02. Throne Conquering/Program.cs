using System;
using System.Collections.Generic;
using System.Linq;

namespace _20190417_Retake_02._Throne_Conquering
{
    class Program
    {

        static char[][] matrix;
        static int parisTargetRow;
        static int parisTargetCol;
        static int parisEnergy;
        static void Main(string[] args)
        {
            parisEnergy = int.Parse(Console.ReadLine());
            int matrixSize = int.Parse(Console.ReadLine());
            matrix = new char[matrixSize][];

            FillMatrix();

            while (true)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string parisDirection = input[0];
                int spartanRow = int.Parse(input[1]);
                int spartanCol = int.Parse(input[2]);
                matrix[spartanRow][spartanCol] = 'S';
                switch (parisDirection)
                {
                    case "up":
                        if (parisTargetRow == 0)
                        {
                            parisEnergy--;
                        }
                        else
                        {
                            matrix[parisTargetRow][parisTargetCol] = '-';
                            parisEnergy--;
                            parisTargetRow--;
                            MoveParis();
                        }
                        break;
                    case "down":
                        if (parisTargetRow == matrixSize - 1)
                        {
                            parisEnergy--;
                        }
                        else
                        {
                            matrix[parisTargetRow][parisTargetCol] = '-';
                            parisEnergy--;
                            parisTargetRow++;
                            MoveParis();
                        }
                        break;
                    case "left":
                        if (parisTargetCol == 0)
                        {
                            parisEnergy--;
                        }
                        else
                        {
                            matrix[parisTargetRow][parisTargetCol] = '-';
                            parisEnergy--;
                            parisTargetCol--;
                            MoveParis();
                        }
                        break;
                    case "right":
                        if (parisTargetCol == matrixSize - 1)
                        {
                            parisEnergy--;
                        }
                        else
                        {
                            matrix[parisTargetRow][parisTargetCol] = '-';
                            parisEnergy--;
                            parisTargetCol++;
                            MoveParis();
                        }
                        break;
                    default:
                        break;
                }
                if (matrix[parisTargetRow][parisTargetCol] == 'X')
                {
                    Console.WriteLine($"Paris died at {parisTargetRow};{parisTargetCol}.");
                    break;
                }
            }
            PrintMatrix();

        }

        private static void MoveParis()
        {
            if (matrix[parisTargetRow][parisTargetCol] == 'S')
            {
                parisEnergy -= 2;
                if (parisEnergy > 0)
                {
                    matrix[parisTargetRow][parisTargetCol] = 'P';
                }
                else
                {
                    matrix[parisTargetRow][parisTargetCol] = 'X';
                }
            }
            else if (matrix[parisTargetRow][parisTargetCol] == 'H')
            {
                matrix[parisTargetRow][parisTargetCol] = '-';
                Console.WriteLine($"Paris has successfully sat on the throne! Energy left: {parisEnergy}");
                PrintMatrix();
                Environment.Exit(0);
            }
            else
            {
                if (parisEnergy > 0)
                {
                    matrix[parisTargetRow][parisTargetCol] = 'P';
                }
                else
                {
                    matrix[parisTargetRow][parisTargetCol] = 'X';
                }

            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join("", matrix[row]));
            }
        }

        private static void FillMatrix()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
                if (matrix[i].Contains('P'))
                {
                    parisTargetRow = i;
                    parisTargetCol = Array.IndexOf(matrix[i], 'P');
                }
            }
        }

    }
}
