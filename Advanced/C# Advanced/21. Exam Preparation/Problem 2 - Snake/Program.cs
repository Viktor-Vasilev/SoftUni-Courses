using System;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int snakeRow = -1;
            int snakeCol = -1;

            int foodCount = 0;

            FillMatrix(size, matrix, ref snakeRow, ref snakeCol);

            // Print(matrix);  

            while (true)
            {
                string command = Console.ReadLine();

                matrix[snakeRow, snakeCol] = '.'; // маркираме текущото местопожение

                if (command == "up")  // местим кораба
                {
                    snakeRow--;
                }
                else if (command == "down")
                {
                    snakeRow++;
                }
                else if (command == "left")
                {
                    snakeCol--;
                }
                else if (command == "right")
                {
                    snakeCol++;
                }

                // Print(matrix);

                if (snakeRow > size - 1 || snakeRow < 0 || snakeCol < 0 || snakeCol > size - 1) // проверяваме дали не сме излезли
                {
                    break; // ако сме излезли - приключваме
                }

                if ((matrix[snakeRow, snakeCol]) == '*') // ако срещнем храна
                {


                    foodCount++;

                    if (foodCount == 10) // проверяваме дали трябва да приключим
                    {
                        matrix[snakeRow, snakeCol] = 'S'; // маркираме последното местоположение
                        break;
                    }
                }

                //Print(matrix);

                if (matrix[snakeRow, snakeCol] == 'B') // ако влезем в черна дупка
                {
                    matrix[snakeRow, snakeCol] = '.';   // маркираме текущото местопожение

                    for (int row = 0; row < size; row++)
                    {
                        for (int col = 0; col < size; col++)
                        {
                            if (matrix[row, col] == 'B') // взимаме си местоположението на другата черна дупка
                            {
                                snakeRow = row;
                                snakeCol = col;
                            }
                        }

                    }

                }

                matrix[snakeRow, snakeCol] = 'S'; //ако не сме излезли маркираме новото местоположенние


            }

            if (foodCount == 10) // ако сме събрали достатъчно
            {
                Console.WriteLine("You won! You fed the snake.");
                Console.WriteLine($"Food eaten: {foodCount}");
            }
            else
            {
                Console.WriteLine("Game over!");
                Console.WriteLine($"Food eaten: {foodCount}");
            }

            Print(matrix);








        }

        private static void FillMatrix(int size, char[,] matrix, ref int snakeRow, ref int snakeCol)
        {
            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'S') 
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }

            }
        }

        static void Print(char[,] matrix)
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
