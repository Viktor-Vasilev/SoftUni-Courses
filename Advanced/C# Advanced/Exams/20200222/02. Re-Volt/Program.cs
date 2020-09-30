using System;
using System.Linq;

namespace _20200222_02._Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int moves = int.Parse(Console.ReadLine());

            char[][] matrix = new char[size][];

            int playerRow = -1;
            int playerCol = -1;

            //for (int row = 0; row < size; row++)
            //{
            //    string data = Console.ReadLine();

            //    matrix[row] = new char[data.Length];

            //    for (int col = 0; col < data.Length; col++)
            //    {
            //        matrix[row][col] = data[col];

            //        if (data[col] == 'f')
            //        {
            //            playerRow = row;
            //            playerCol = col;

            //        }
            //    }
            //}

            for (int row = 0; row < matrix.Length; row++)
            {
                char[] rawData = Console.ReadLine().ToCharArray();

                matrix[row] = rawData;

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }



            bool playerWon = false;

            for (int i = 0; i < moves; i++)
            {
                string command = Console.ReadLine();

                matrix[playerRow][playerCol] = '-'; // маркираме текущото местоположение с -

                if (command == "up")
                {
                    if (playerRow - 1 >= 0) //проверяваме дали не излизаме отгоре
                    {
                        playerRow--; // ако не излизаме се качваме един ред
                    }
                    else
                    {
                        playerRow = matrix.Length - 1; // ако излизаме отиваме отдолу
                    }

                    // проверяваме какво има на новото местоположение


                    if (matrix[playerRow][playerCol] == 'T') // наказват ни - една позиция назад
                    {
                        playerRow++;
                    }
                    else if (matrix[playerRow][playerCol] == 'B') // бонус - една позиция напред
                    {
                        playerRow--;
                    }

                    if (playerRow < 0) // пак проверяваме дали не сме излезли след бонуса
                    {
                        playerRow = matrix.Length - 1;
                    }



                    if (matrix[playerRow][playerCol] == 'F') // спечлили сме
                    {
                        playerWon = true;
                        break;
                    }

                    matrix[playerRow][playerCol] = 'f'; // маркираме новото местоположение



                }
                else if (command == "down")
                {
                    if (playerRow + 1 < matrix.Length)
                    {
                        playerRow++;
                    }
                    else
                    {
                        playerRow = 0;
                    }



                    if (matrix[playerRow][playerCol] == 'T')
                    {
                        playerRow--;
                    }
                    else if (matrix[playerRow][playerCol] == 'B')
                    {
                        playerRow++;
                    }

                    if (playerRow == matrix.Length)
                    {
                        playerRow = 0;
                    }


                    if (matrix[playerRow][playerCol] == 'F')
                    {
                        playerWon = true;
                        break;
                    }

                    matrix[playerRow][playerCol] = 'f';



                }
                else if (command == "right")
                {
                    if (playerCol + 1 < matrix.Length)
                    {
                        playerCol++;
                    }
                    else
                    {
                        playerCol = 0;
                    }


                    if (matrix[playerRow][playerCol] == 'T')
                    {
                        playerCol--;
                    }
                    else if (matrix[playerRow][playerCol] == 'B')
                    {
                        playerCol++;
                    }

                    if (playerRow == matrix.Length)
                    {
                        playerRow = 0;
                    }


                    if (matrix[playerRow][playerCol] == 'F')
                    {
                        playerWon = true;
                        break;
                    }

                    matrix[playerRow][playerCol] = 'f';



                }
                else if (command == "left")
                {
                    if (playerCol - 1 >= 0)
                    {
                        playerCol--;
                    }
                    else
                    {
                        playerCol = matrix.Length - 1;
                    }


                    if (playerCol < 0)
                    {
                        playerCol = matrix.Length - 1;
                    }

                    if (matrix[playerRow][playerCol] == 'T')
                    {
                        playerCol++;
                    }
                    else if (matrix[playerRow][playerCol] == 'B')
                    {
                        playerCol--;
                    }

                    if (playerCol < 0)
                    {
                        playerCol = matrix.Length - 1;
                    }


                    if (matrix[playerRow][playerCol] == 'F')
                    {
                        playerWon = true;
                        break;
                    }

                    matrix[playerRow][playerCol] = 'f';

                }
            }

            if (playerWon)
            {
                matrix[playerRow][playerCol] = 'f';

                Console.WriteLine($"Player won!");
            }
            else
            {
                Console.WriteLine($"Player lost!");
            }

            Print(matrix);

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
