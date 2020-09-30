using System;
using System.Linq;

namespace _20191217_Retake_02._Present_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int presentsCount = int.Parse(Console.ReadLine());

            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int santaRow = -1;
            int santaCol = -1;

            int niceKids = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rawData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rawData[col];

                    if (matrix[row, col] == 'S') // взимаме стартовата позиция
                    {
                        santaRow = row;
                        santaCol = col;
                    }
                    else if (matrix[row, col] == 'V')
                    {
                        niceKids++; // взимаме броя на добрите деца
                    }                
                }
            }      

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Christmas morning")
                {
                    break;
                }


                matrix[santaRow, santaCol] = '-'; // текущото ни местоположение става -

                if (command == "up") // променяме местоположението
                {
                    santaRow--;
                }
                else if (command == "down")
                {
                    santaRow++;
                }
                else if (command == "left")
                {
                    santaCol--;
                }
                else if (command == "right")
                {
                    santaCol++;
                }



                if (matrix[santaRow, santaCol] == '-') // ако новото местоположение е -
                {
                    matrix[santaRow, santaCol] = 'S';  // маркираме новото ниместоположение да стане S
                }

                else if (matrix[santaRow, santaCol] == 'V') // ако новото местоположение е V
                {
                    matrix[santaRow, santaCol] = 'S'; // маркираме новото ниместоположение да стане S

                    presentsCount--;

                    if (presentsCount == 0)
                    {
                        Console.WriteLine("Santa ran out of presents!");
                        break;
                    }
                }

                else if (matrix[santaRow, santaCol] == 'X') // ако новото местоположение е X
                {
                    matrix[santaRow, santaCol] = 'S'; // маркираме новото ниместоположение да стане S

                    continue;
                }

                else if (matrix[santaRow, santaCol] == 'C') // ако новото местоположение е C
                {
                    matrix[santaRow, santaCol] = 'S'; // маркираме новото ниместоположение да стане S


                    if (matrix[santaRow, santaCol + 1] != '-') // надясно 
                    {
                        presentsCount--; // нямаляме подаръците

                        matrix[santaRow, santaCol + 1] = '-'; // едно поле надясно става -

                        if (presentsCount == 0) // ако подаръците станат 0
                        {
                            break;
                        }
                    }
                    if (matrix[santaRow, santaCol - 1] != '-') // наляво
                    {
                        presentsCount--;

                        matrix[santaRow, santaCol - 1] = '-'; // едно поле наляво става -

                        if (presentsCount == 0)
                        {
                            break;
                        }
                    }
                    if (matrix[santaRow - 1, santaCol] != '-') // нагоре
                    {
                        presentsCount--;

                        matrix[santaRow - 1, santaCol] = '-'; // едно поле нагоре става -

                        if (presentsCount == 0)
                        {
                            break;
                        }
                    }
                    if (matrix[santaRow + 1, santaCol] != '-') // надолу
                    {
                        presentsCount--;

                        matrix[santaRow + 1, santaCol] = '-'; // едно поле надолу става -

                        if (presentsCount == 0)
                        {
                            break;
                        }
                    }
                }
            }

            int niceKidsLeft = 0;

            //foreach (var kid in matrix)
            //{
            //    if (kid == 'V')
            //    {
            //        niceKidsLeft++;
            //    }
            //}

            for (int row = 0; row < matrix.GetLength(0); row++) // джуркаме матрицата да видим дали има останали деца без подаръци
            {              
                for (int col = 0; col < matrix.GetLength(1); col++)
                {                       
                    if (matrix[row, col] == 'V')
                    {
                        niceKidsLeft++;
                    }
                }
            }

            Print(matrix); // принтитаме матрицата във всички случаи

            if (niceKidsLeft == 0) // ако няма деца без подаръци
            {
                Console.WriteLine($"Good job, Santa! {niceKids} happy nice kid/s.");
            }
            else // има останали деца без подаръци
            {
                Console.WriteLine($"No presents for {niceKidsLeft} nice kid/s.");
            }
        }

        static void Print(char[,] matrix)
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
