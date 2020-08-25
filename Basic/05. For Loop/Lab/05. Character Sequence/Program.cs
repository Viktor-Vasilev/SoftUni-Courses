using System;

namespace _05._Character_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            int length = text.Length;

            for (int i = 0; i <= length - 1; i++)
            {
                Console.WriteLine(text[i]);
            }
        }
    }
}
