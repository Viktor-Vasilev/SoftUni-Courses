using System;

namespace _5._Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            //int clicks = int.Parse(Console.ReadLine());
            //string message = string.Empty;

            //for (int i = 0; i < clicks; i++)
            //{
            //    string digits = Console.ReadLine();
            //    int digitLength = digits.Length;
            //    int digit = digits[0] - '0';    // ASCII hack hehehe
            //    int offset = (digit - 2) * 3;

            //    if (digit == 0)
            //    {
            //        message += (char)(digit + 32);
            //        continue;
            //    }

            //    if (digit == 8 || digit == 9)
            //    {
            //        offset++;
            //    }
            //    int letterIndex = offset + digitLength - 1;
            //    message += (char)(letterIndex + 97);
            //}

            //Console.WriteLine(message);

            int n = int.Parse(Console.ReadLine());

            string two = "abc";
            string three = "def";
            string four = "ghi";
            string five = "jkl";
            string six = "mno";
            string seven = "pqrs";
            string eight = "tuv";
            string nine = "wxyz";

            string message = "";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                char current = input[0];

                switch (current)
                {
                    case '2':
                        message += two[input.Length - 1];
                        break;
                    case '3':
                        message += three[input.Length - 1];
                        break;
                    case '4':
                        message += four[input.Length - 1];
                        break;
                    case '5':
                        message += five[input.Length - 1];
                        break;
                    case '6':
                        message += six[input.Length - 1];
                        break;
                    case '7':
                        message += seven[input.Length - 1];
                        break;
                    case '8':
                        message += eight[input.Length - 1];
                        break;
                    case '9':
                        message += nine[input.Length - 1];
                        break;
                    case '0':
                        message += ' ';
                        break;
                }

            }

            Console.WriteLine(message);




        }
    }
}
