using System;
using System.Collections.Generic;
using System.Linq;

namespace _20190623_03._Spaceship_Station
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int shipRow = -1;
            int shipCol = -1;

            int starPower = 0;

            FillMatrix(size, matrix, ref shipRow, ref shipCol);

            // Print(matrix);         

            while (true)
            {
                string command = Console.ReadLine();

                matrix[shipRow, shipCol] = '-'; // маркираме текущото местопожение

                if (command == "up")  // местим кораба
                {
                    shipRow--;
                }
                else if (command == "down")
                {
                    shipRow++;
                }
                else if (command == "left")
                {
                    shipCol--;
                }
                else if (command == "right")
                {
                    shipCol++;
                }

                // Print(matrix);

                if (shipRow > size - 1 || shipRow < 0 || shipCol < 0 || shipCol > size - 1) // проверяваме дали не сме излезли
                {
                    break; // ако сме излезли - приключваме
                }

                if (char.IsDigit(matrix[shipRow, shipCol])) // ако срещнем число
                {
                    int foundStarPower = int.Parse(matrix[shipRow, shipCol].ToString());

                    starPower += foundStarPower;

                    if (starPower == 50) // проверяваме дали трябва да приключим
                    {
                        matrix[shipRow, shipCol] = 'S'; // маркираме последното местоположение
                        break;
                    }
                }

                //Print(matrix);

                if (matrix[shipRow, shipCol] == 'O') // ако влезем в черна дупка
                {
                    matrix[shipRow, shipCol] = '-';   // маркираме текущото местопожение

                    for (int row = 0; row < size; row++)
                    {
                        for (int col = 0; col < size; col++)
                        {
                            if (matrix[row, col] == 'O') // взимаме си местоположението на другата черна дупка
                            {
                                shipRow = row;
                                shipCol = col;
                            }
                        }

                    }

                }

                matrix[shipRow, shipCol] = 'S'; //ако не сме излезли маркираме новото местоположенние


            }

            if (starPower >= 50) // ако сме събрали достатъчно
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                Console.WriteLine($"Star power collected: {starPower}");              
            }
            else
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
                Console.WriteLine($"Star power collected: {starPower}");              
            }

            Print(matrix);
        }

        private static void FillMatrix(int size, char[,] matrix, ref int shipRow, ref int shipCol)
        {
            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'S') // взимаме си местоположението на кораба
                    {
                        shipRow = row;
                        shipCol = col;
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
