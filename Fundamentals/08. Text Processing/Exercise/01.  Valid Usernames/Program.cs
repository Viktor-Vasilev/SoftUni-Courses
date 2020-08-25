using System;
using System.Collections.Generic;

namespace _2._Exer_1.__Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            //    string[] userNames = Console.ReadLine().Split(", ");

            //    List<string> validUserNames = new List<string>();

            //    foreach (string userName in userNames)
            //    {
            //        if (userName.Length >= 3 && userName.Length <= 16)
            //        {
            //            bool isValid = true;

            //            foreach (char symbol in userName)
            //            {
            //                if (!(char.IsLetterOrDigit(symbol)) || symbol == '-' || symbol == '_')
            //                {
            //                    isValid = false;
            //                    break;
            //                }
            //            }

            //            if (isValid)
            //            {
            //                validUserNames.Add(userName);
            //            }


            //        }
            //    }

            //    Console.WriteLine(string.Join("\n", validUserNames));
            //}

            var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            var validUserNames = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                string current = input[i];

                if (current.Length >= 3 && current.Length <= 16)
                {
                    bool IsValid = true;

                    for (int j = 0; j < current.Length; j++)
                    {
                        if (!(char.IsLetterOrDigit(current[j]) || current[j] == '-' || current[j] == '_'))
                        {
                            IsValid = false;
                        }
                    }

                    if (IsValid)
                    {
                        validUserNames.Add(current);
                    }

                }

            }

            Console.WriteLine(String.Join(Environment.NewLine, validUserNames));
        }
    }
}
