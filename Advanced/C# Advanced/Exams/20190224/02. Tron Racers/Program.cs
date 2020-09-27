using System;

namespace _20190224_02._Tron_Racers
{
    class Program
    {
                                              // ДЕКЛАРИРАМЕ ГЛОБАЛНО!!!
        static char[,] matrix;
        static int firstPlayerRow;
        static int secondPlayerRow;

        static int firstPlayerCol;
        static int secondPlayerCol;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;

            char[,] matrix = ReadMatrix(rows, cols);

            while (true)
            {
                string[] moves = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currentMoveFirstPlayer = moves[0];
                string currentMoveSecondPlayer = moves[1];

                // ПЪРВИ ИГРАЧ:

                if (currentMoveFirstPlayer == "up")
                {
                    firstPlayerRow--;

                    if (firstPlayerRow < 0) // ако сме излезли отгоре
                    {
                        firstPlayerRow = matrix.GetLength(0) - 1; // отиваме най-отдолу
                    }
                }

                else if (currentMoveFirstPlayer == "down")
                {
                    firstPlayerRow++;

                    if (firstPlayerRow > matrix.GetLength(0) - 1) // ако сме излезли отдолу
                    {
                        firstPlayerRow = 0; // отиваме наи-отгоре
                    }
                }

                else if (currentMoveFirstPlayer == "left")
                {
                    firstPlayerCol--;

                    if (firstPlayerCol < 0) // ако сме излезли отляво
                    {
                        firstPlayerCol = matrix.GetLength(1) - 1; // отиваме най-вдясно
                    }
                }

                else if (currentMoveFirstPlayer == "right")
                {
                    firstPlayerCol++;

                    if (firstPlayerCol > matrix.GetLength(1) - 1) // ако сме излезли отдясно
                    {
                        firstPlayerCol = 0; // отиваме най-вляво
                    }
                }

                if (matrix[firstPlayerRow, firstPlayerCol] == 's') // ако сме уцелили "s" сме умрели
                {
                    matrix[firstPlayerRow, firstPlayerCol] = 'x'; // маркираме текущото местоположение 
                    PrintMatrix(matrix); // принтираме
                    return; // излизаме

                }
                else
                {
                    matrix[firstPlayerRow, firstPlayerCol] = 'f'; // маркираме сегашното си местоположение
                }

                // ВТОРИ ИГРАЧ:


                if (currentMoveSecondPlayer == "up")
                {
                    secondPlayerRow--;

                    if (secondPlayerRow < 0)
                    {
                        secondPlayerRow = matrix.GetLength(0) - 1;
                    }
                }

                else if (currentMoveSecondPlayer == "down")
                {
                    secondPlayerRow++;

                    if (secondPlayerRow > matrix.GetLength(0) - 1)
                    {
                        secondPlayerRow = 0;
                    }
                }

                else if (currentMoveSecondPlayer == "left")
                {
                    secondPlayerCol--;

                    if (secondPlayerCol < 0)
                    {
                        secondPlayerCol = matrix.GetLength(1) - 1;
                    }
                }

                else if (currentMoveSecondPlayer == "right")
                {

                    secondPlayerCol++;
                    if (secondPlayerCol > matrix.GetLength(1) - 1)
                    {
                        secondPlayerCol = 0;
                    }
                }

                if (matrix[secondPlayerRow, secondPlayerCol] == 'f')
                {
                    matrix[secondPlayerRow, secondPlayerCol] = 'x';
                    PrintMatrix(matrix);
                    return;

                }
                else
                {
                    matrix[secondPlayerRow, secondPlayerCol] = 's';
                }

            }


        }
        static char[,] ReadMatrix(int rows, int cols)
        {

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }
                    else if (matrix[row, col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }
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