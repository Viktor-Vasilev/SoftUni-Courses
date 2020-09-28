using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20191029_02._Book_Worm
{
    class Program
    {       
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            int size = int.Parse(Console.ReadLine());

            char[][] matrix = new char[size][];

            int row = 0;
            int col = 0;

            for (int i = 0; i < size; i++)
            {
                string data = Console.ReadLine();

                matrix[i] = new char[data.Length];

                for (int j = 0; j < data.Length; j++)
                {
                    matrix[i][j] = data[j];

                    if (matrix[i][j] == 'P')
                    {
                        row = i;
                        col = j;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                matrix[row][col] = '-';

                if (command == "up")
                {
                    row--;

                    if (row < 0)
                    {
                        row = 0;
                        text = MyRemove(text);
                    }
                    else
                    {
                        text = CheckForLetter(text, matrix, row, col);
                    }

                }
                else if (command == "down")
                {
                    row++;

                    if (row == matrix.Length)
                    {
                        row = matrix.Length - 1;

                        text = MyRemove(text);
                    }
                    else
                    {
                        text = CheckForLetter(text, matrix, row, col);
                    }
                }
                else if (command == "left")
                {
                    col--;

                    if (col < 0)
                    {
                        col = 0;

                        text = MyRemove(text);
                    }
                    else
                    {
                        text = CheckForLetter(text, matrix, row, col);
                    }
                }
                else if (command == "right")
                {
                    col++;

                    if (col == matrix.Length)
                    {
                        col = matrix.Length - 1;

                        text = MyRemove(text);
                    }
                    else
                    {
                        text = CheckForLetter(text, matrix, row, col);
                    }
                }

                matrix[row][col] = 'P';
            }

            Console.WriteLine(text);
            Console.WriteLine(Print(matrix));




        }



        private static string MyRemove(string text)
        {
            text = text.Remove(text.Length - 1, 1);
            return text;
        }

        private static string CheckForLetter(string input, char[][] matrix, int row, int col)
        {
            if (char.IsLetter(matrix[row][col]))
            {
                input = input + matrix[row][col];
            }

            return input;
        }

        private static string Print(char[][] matrix)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    sb.Append($"{matrix[i][j]}");
                }

                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }

    }
}
