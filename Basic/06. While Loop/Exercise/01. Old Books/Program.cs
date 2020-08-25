using System;

namespace _01._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookWanted = Console.ReadLine();
            int capacity = int.Parse(Console.ReadLine());

            int numCheckedBooks = 0;           

            while (capacity > 0)
            {
            string bookInProgress = Console.ReadLine();

                if (bookInProgress == bookWanted)
                {
                    Console.WriteLine($"You checked {numCheckedBooks} books and found it.");
                    break;
                }

                numCheckedBooks++;

                capacity--;
            }

            if (capacity == 0)
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {numCheckedBooks} books.");
            }


        }
    }
}
