using System;

namespace _05._Decrypting_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int interval = int.Parse(Console.ReadLine());
            string message = "";

            for (int currentLetter = 1; currentLetter <= interval; currentLetter++)
            {
                char letter = char.Parse(Console.ReadLine());
                message += (char)(key + letter);
            }

            Console.WriteLine(message);

        }
    }
}
