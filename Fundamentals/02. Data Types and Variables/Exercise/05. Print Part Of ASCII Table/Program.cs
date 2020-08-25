using System;

namespace _05._Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int charStart = int.Parse(Console.ReadLine());
            int charEnd = int.Parse(Console.ReadLine());
            string newString = "";

            for (int currentChar = charStart; currentChar <= charEnd; currentChar++)
            {
                newString += (char)currentChar + " ";
            }

            Console.WriteLine(newString);
        }
    }
}
