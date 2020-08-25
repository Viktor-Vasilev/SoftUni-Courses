using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string guessPassword = Console.ReadLine();

            string realPassword = "";

            for (int i = username.Length - 1; i >= 0; i--)
            {
                realPassword += username[i];
            }

            int counter = 1;

            while (true)
            {
                if (guessPassword == realPassword)
                {
                    break;
                }


                if (counter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }

                counter++;

                Console.WriteLine("Incorrect password. Try again.");

                guessPassword = Console.ReadLine();
            }

            Console.WriteLine($"User {username} logged in.");



        }
    }
}
