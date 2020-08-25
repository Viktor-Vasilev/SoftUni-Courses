using System;

namespace _2.Ex_04_Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            ValidatePassword(password);



        }

        static void ValidatePassword(string password)
        {
            bool isValid = false;
            
            if (password.Length < 6 || password.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValid = true;
            }

            if (!CheckContainsOnlyDigitsAndLetters(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isValid = true;
            }

            if (CountNumOfDigits(password) < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = true;
            }

            if (isValid == false)
            {
                Console.WriteLine("Password is valid");
            }


        }

        static bool CheckContainsOnlyDigitsAndLetters(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                char currentChar = password[i];
                if (!((currentChar >= 48 && currentChar <= 57 || currentChar >= 65 && currentChar <= 90 || currentChar >= 97 && currentChar <= 122)))
                    {
                    return false;
                }
            }
            return true;
        }

        static int CountNumOfDigits(string password)
        {
            int digitsCount = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if(password[i] >= 48 && password[i] < 57)
                {
                    digitsCount++;
                }

            }
            return digitsCount;
        }

    }
}
