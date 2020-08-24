using System;

namespace _06._Password_Guess
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string userPassword = "s3cr3t!P@ssw0rd";
            if (password == userPassword)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }

        }
    }
}
