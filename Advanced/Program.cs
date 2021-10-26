using System;
using System.Collections.Generic;

namespace PawnWars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] chessMatrix = new char[8][]; // матрица само за печатане :(

            for (int row = 0; row < chessMatrix.Length; row++)
            {
                char[] rawData = new char[8] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', };

                chessMatrix[row] = rawData;

                for (int col = 0; col < chessMatrix[row].Length; col++) 
                {
                    chessMatrix[row][col] = rawData[col];
                }
            }

            char[][] matrix = new char[8][]; // правим си празна матрица 8Х8
            
            // променливи за бялата пешка
            int whiteRow = -1;
            int whiteCol = -1;

            // променливи за черната пешка
            int blackRow = -1;
            int blackCol = -1;

            // приемаме данните за матрицата
            for (int row = 0; row < matrix.Length; row++)
            {
                char[] rawData = Console.ReadLine().ToCharArray();

                matrix[row] = rawData;

                for (int col = 0; col < matrix[row].Length; col++) // взимаме положението на пешките
                {
                    if (matrix[row][col] == 'w') // бяла пешка
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }

                    if (matrix[row][col] == 'b') // черна пешка
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }

            while (true) // докато не завърши играта
            {
                //  МЕСТИМ БЯЛА ПЕШКА
                matrix[whiteRow][whiteCol] = '-'; // маркираме текущото местоположение с -
                
                if (whiteRow - 1 == 0) //проверяваме дали не сме стигнали края
                {                  
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {chessMatrix[whiteRow][whiteCol]}8."); // ако сме стигнали края сме спечелили
                    return;
                }

                // проверяваме дали не може да вземем черна пешка
                if (whiteCol == 0) // ако сме на вертикал "a" проверяваме само отдясно, за да не излезнем от матрицата
                {
                    if (matrix[whiteRow - 1][whiteCol + 1] == 'b') // ако е черна пешка отгоре отдясно сме спечелили
                    {
                        Console.WriteLine($"Game over! White capture on {chessMatrix[blackRow][blackCol]}{matrix[blackCol].Length - blackRow}.");
                        return;
                    }
                }
                else if (whiteCol == 7) // ако сме на вертикал "h" проверяваме само отляво, за да не излезнем от матрицата
                {
                    if (matrix[whiteRow - 1][whiteCol - 1] == 'b') // ако е черна пешка отгоре отляво сме спечелили
                    {
                        Console.WriteLine($"Game over! White capture on {chessMatrix[blackRow][blackCol]}{matrix[blackCol].Length - blackRow}.");
                        return;
                    }
                }
                else // не сме на "a" или "h" проверяваме от двете страни
                {
                    if (matrix[whiteRow - 1][whiteCol - 1] == 'b' || matrix[whiteRow - 1][whiteCol + 1] == 'b') // ако е черна пешка отгоре ляво/дясно сме спечелили
                    {
                        Console.WriteLine($"Game over! White capture on {chessMatrix[blackRow][blackCol]}{matrix[blackCol].Length - blackRow}.");
                        return;
                    }
                }

                whiteRow--; //придвижваме бялата пешка нагоре

                matrix[whiteRow][whiteCol] = 'w'; // маркираме новото местоположение

                // -------------------------------------------------------------------------------------------------------------------//

                //  МЕСТИМ ЧЕРНА ПЕШКА
                matrix[blackRow][blackCol] = '-'; // маркираме текущото местоположение с -

                if (blackRow + 1 == 8) //проверяваме дали не сме стигнали края
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {chessMatrix[blackRow][blackCol]}1."); // ако сме стигнали края сме спечелили
                    return;
                }

                // проверяваме дали не може да вземем бяла пешка
                if (blackCol == 0) // ако сме на вертикал "a" проверяваме само отдясно, за да не излезнем от матрицата
                {
                    if (matrix[blackRow + 1][blackCol + 1] == 'w') // ако е бяла пешка по диагонал надолу сме спечелили
                    {
                        Console.WriteLine($"Game over! Black capture on {chessMatrix[whiteRow][whiteCol]}{matrix[whiteCol].Length - whiteRow}."); // печатаме точните полета
                        return;
                    }
                }
                else if (blackCol == 7) // ако сме на вертикал "h" проверяваме само отляво, за да не излезнем от матрицата
                {
                    if (matrix[blackRow + 1][blackCol - 1] == 'w') // ако е бяла пешка по диагонал надолу сме спечелили
                    {
                        Console.WriteLine($"Game over! Black capture on {chessMatrix[whiteRow][whiteCol]}{matrix[whiteCol].Length - whiteRow}."); // печатаме точните полета
                        return;
                    }
                }
                else // не сме на "a" или "h" проверяваме от двете страни
                {
                    if (matrix[blackRow + 1][blackCol + 1] == 'w' || matrix[blackRow + 1][blackCol - 1] == 'w') // ако е бяла пешка отдолу ляво/дясно сме спечелили
                    {
                        Console.WriteLine($"Game over! Black capture on {chessMatrix[whiteRow][whiteCol]}{matrix[whiteCol].Length - whiteRow}."); // печатаме точните полета
                        return;
                    }
                }
               

                blackRow++; //придвижваме черната пешка надолу

                matrix[blackRow][blackCol] = 'b'; // маркираме новото местоположение

                //Console.WriteLine();
                //Print(matrix);
            }

        }

        private static void Print(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }

    }
}