using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;

namespace _20191210_Retake_3._School_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> books = Console.ReadLine().Split('&').ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split(" | ");

                if (command[0] == "Done")
                {
                    break;
                }
                if (command[0] == "Add Book")
                {
                    string bookName = command[1];

                    if (!books.Contains(bookName))
                    {
                        books.Insert(0, bookName);
                    }

                }
                if (command[0] == "Take Book")
                {
                    string bookName = command[1];

                    if (books.Contains(bookName))
                    {
                        books.Remove(bookName);
                    }
                }
                if (command[0] == "Swap Books")
                {
                    string bookName1 = command[1];
                    string bookName2 = command[2];
                    
                    if (books.Contains(bookName1) && books.Contains(bookName2))
                    {
                        int bookName1Index = books.IndexOf(bookName1);
                        int bookName2Index = books.IndexOf(bookName2);

                        string temp = books[bookName1Index];
                        books[bookName1Index] = books[bookName2Index];
                        books[bookName2Index] = temp;
                    }

                }
                if (command[0] == "Insert Book")
                {
                    string bookName = command[1];

                    books.Add(bookName);
                }
                if (command[0] == "Check Book")
                {
                    int index = int.Parse(command[1]);

                    if (index >= 0 && index < books.Count)
                    {
                        Console.WriteLine($"{books[index]}");
                    }
                }
            }
            Console.Write(String.Join(", ", books));
        }
    }
}
