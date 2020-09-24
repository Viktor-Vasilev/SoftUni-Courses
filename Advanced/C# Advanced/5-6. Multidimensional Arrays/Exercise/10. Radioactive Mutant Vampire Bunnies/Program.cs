using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Exer_10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            char[,] matrix = new char[rows, cols];

            bool isWon = false;

            int playerRow = -1;
            int playerRCol = -1;



            for (int row = 0; row < rows; row++)
            {
                char[] colValues = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = colValues[col];

                    if (colValues[col] == 'P')
                    {
                        playerRow = row;
                        playerRCol = col; 

                    }
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();

            foreach (char direction in directions)
            {
                int currentPlayerRow = playerRow;
                int currentPlayerCol = playerRCol;


                switch (direction)
                {
                    case 'U':
                        currentPlayerRow++;

                        break;
                    case 'D':
                        currentPlayerRow++;

                        break;
                    case 'L':
                        currentPlayerCol--;


                        break;
                    case 'R':
                        currentPlayerCol++;

                        break;
                }

                isWon = IsWon(matrix, currentPlayerRow, currentPlayerCol);

                if (isWon)
                {
                    matrix[playerRow, playerRCol] = '.';


                }
                else
                {

                    if (matrix[currentPlayerRow, currentPlayerCol] == 'B')
                    {
                        matrix[playerRow, playerRCol] = '.';
                        playerRow = currentPlayerRow;
                        playerRCol = currentPlayerCol;

                    }
                    else
                    {
                        matrix[playerRow, playerRCol] = '.';
                        matrix[currentPlayerRow, currentPlayerCol] = 'P';
                        playerRow = currentPlayerRow;
                        playerRCol = currentPlayerCol;

                    }

                }

                List<int> bunnies = new List<int>();

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            bunnies.Add(row);
                            bunnies.Add(col);
                        }
                    }
                }

                for (int i = 0; i < bunnies.Count; i += 2)
                {
                    int bunnyRow = bunnies[i];
                    int bunnyCol = bunnies[i + 1];

                    SpredBunny(matrix, bunnyRow, bunnyCol);
                }

                if (isWon || matrix[playerRow, playerRCol] == 'B')
                {
                    break;
                }

            }

            for (int row = 0; row < rows; row++)
            {               
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

            if (isWon)
            {
                Console.WriteLine($"won: {playerRow} {playerRCol}");
            }
            else
            {
                Console.WriteLine($"dead: {playerRow} {playerRCol}");
            }

            //int[] sizes = Console.ReadLine()
            //                     .Split()
            //                     .Select(int.Parse)
            //                     .ToArray();
            //char[,] matrix = new char[sizes[0], sizes[1]];
            //int[] position = new int[2];

            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    char[] elements = Console.ReadLine().ToCharArray();
            //    for (int i = 0; i < matrix.GetLength(1); i++)
            //    {
            //        matrix[row, i] = elements[i];
            //        if (elements[i] == 'P')
            //        {
            //            position[0] = row;
            //            position[1] = i;
            //        }
            //    }
            //}

            //bool isAlive = true;
            //bool hasWon = false;
            //char[] moves = Console.ReadLine().ToCharArray();

            //for (int move = 0; move < moves.Length; move++)
            //{
            //    switch (moves[move])
            //    {
            //        case 'U':
            //            if (position[0] - 1 >= 0)
            //            {
            //                if (matrix[position[0] - 1, position[1]] == 'B')
            //                {
            //                    isAlive = false;
            //                }
            //                else
            //                {
            //                    matrix[position[0] - 1, position[1]] = 'P';
            //                }
            //                matrix[position[0], position[1]] = '.';
            //                position[0] -= 1;
            //            }
            //            else
            //            {
            //                hasWon = true;
            //                matrix[position[0], position[1]] = '.';
            //            }
            //            break;

            //        case 'D':
            //            if (position[0] + 1 < matrix.GetLength(0))
            //            {
            //                if (matrix[position[0] + 1, position[1]] == 'B')
            //                {
            //                    isAlive = false;
            //                }
            //                else
            //                {
            //                    matrix[position[0] + 1, position[1]] = 'P';
            //                }
            //                matrix[position[0], position[1]] = '.';
            //                position[0] += 1;
            //            }
            //            else
            //            {
            //                hasWon = true;
            //                matrix[position[0], position[1]] = '.';
            //            }
            //            break;

            //        case 'L':
            //            if (position[1] - 1 >= 0)
            //            {
            //                if (matrix[position[0], position[1] - 1] == 'B')
            //                {
            //                    isAlive = false;
            //                }
            //                else
            //                {
            //                    matrix[position[0], position[1] - 1] = 'P';
            //                }
            //                matrix[position[0], position[1]] = '.';
            //                position[1] -= 1;
            //            }
            //            else
            //            {
            //                hasWon = true;
            //                matrix[position[0], position[1]] = '.';
            //            }
            //            break;

            //        case 'R':
            //            if (position[1] + 1 < matrix.GetLength(1))
            //            {
            //                if (matrix[position[0], position[1] + 1] == 'B')
            //                {
            //                    isAlive = false;
            //                }
            //                else
            //                {
            //                    matrix[position[0], position[1] + 1] = 'P';
            //                }
            //                matrix[position[0], position[1]] = '.';
            //                position[1] += 1;
            //            }
            //            else
            //            {
            //                matrix[position[0], position[1]] = '.';
            //                hasWon = true;
            //            }
            //            break;
            //    }

            //    char[,] matrixCopy = (char[,])matrix.Clone();

            //    for (int row = 0; row < matrix.GetLength(0); row++)
            //    {
            //        for (int i = 0; i < matrix.GetLength(1); i++)
            //        {
            //            if (matrix[row, i] == 'B')
            //            {
            //                if (row - 1 >= 0)
            //                {
            //                    if (matrix[row - 1, i] == 'P')
            //                    {
            //                        isAlive = false;
            //                    }
            //                    matrixCopy[row - 1, i] = 'B';
            //                }
            //                if (row + 1 < matrix.GetLength(0))
            //                {
            //                    if (matrix[row + 1, i] == 'P')
            //                    {
            //                        isAlive = false;
            //                    }
            //                    matrixCopy[row + 1, i] = 'B';
            //                }
            //                if (i - 1 >= 0)
            //                {
            //                    if (matrix[row, i - 1] == 'P')
            //                    {
            //                        isAlive = false;
            //                    }
            //                    matrixCopy[row, i - 1] = 'B';
            //                }
            //                if (i + 1 < matrix.GetLength(1))
            //                {
            //                    if (matrix[row, i + 1] == 'P')
            //                    {
            //                        isAlive = false;
            //                    }
            //                    matrixCopy[row, i + 1] = 'B';
            //                }
            //            }
            //        }
            //    }

            //    matrix = (char[,])matrixCopy.Clone();
            //    if (isAlive == false)
            //    {
            //        for (int row = 0; row < matrix.GetLength(0); row++)
            //        {
            //            string line = string.Empty;
            //            for (int i = 0; i < matrix.GetLength(1); i++)
            //            {
            //                line += matrix[row, i];
            //            }
            //            Console.WriteLine(line);
            //        }
            //        Console.WriteLine($"dead: {position[0]} {position[1]}");
            //        return;
            //    }

            //    if (hasWon)
            //    {
            //        for (int row = 0; row < matrix.GetLength(0); row++)
            //        {
            //            string line = string.Empty;
            //            for (int i = 0; i < matrix.GetLength(1); i++)
            //            {
            //                line += matrix[row, i];
            //            }
            //            Console.WriteLine(line);
            //        }
            //        Console.WriteLine($"won: {position[0]} {position[1]}");
            //        return;
            //    }
            //}

        }

        private static void SpredBunny(char[,] matrix, int bunnyRow, int bunnyCol)
        {
            if (bunnyRow - 1 >= 0)
            {
                matrix[bunnyRow - 1, bunnyCol] = 'B';
            }
            if (bunnyRow + 1 < matrix.GetLength(0))
            {
                matrix[bunnyRow + 1, bunnyCol] = 'B';
            }
            if (bunnyCol - 1 >= 0)
            {
                matrix[bunnyRow, bunnyCol - 1] = 'B';
            }
            if (bunnyCol + 1 < matrix.GetLength(1))
            {
                matrix[bunnyRow, bunnyCol + 1] = 'B';
            }



        }

        private static bool IsWon(char[,] matrix, int currentPlayerRow, int currentPlayerCol)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            return currentPlayerRow < 0 || currentPlayerRow >= n || currentPlayerCol < 0 || currentPlayerCol >= m;
        }
    }
    
}
