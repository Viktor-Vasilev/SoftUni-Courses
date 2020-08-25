using System;

namespace _2._English_Name_of_the_Last_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            //string num = Console.ReadLine();
            //char lastDigit = (num[num.Length - 1]);

            //switch (lastDigit)
            //{
            //    case '0':
            //        Console.WriteLine("zero");
            //        break;
            //    case '1':
            //        Console.WriteLine("one");
            //        break;
            //    case '2':
            //        Console.WriteLine("two");
            //        break;
            //    case '3':
            //        Console.WriteLine("three");
            //        break;
            //    case '4':
            //        Console.WriteLine("four");
            //        break;
            //    case '5':
            //        Console.WriteLine("five");
            //        break;
            //    case '6':
            //        Console.WriteLine("six");
            //        break;
            //    case '7':
            //        Console.WriteLine("seven");
            //        break;
            //    case '8':
            //        Console.WriteLine("eight");
            //        break;
            //    case '9':
            //        Console.WriteLine("nine");
            //        break;

            int num = int.Parse(Console.ReadLine());

            int last = Math.Abs(num % 10);

            string output = "";

            switch (last)
            {
                case 1:
                    output = "one";
                    break;
                case 2:
                    output = "two";
                    break;
                case 3:
                    output = "three";
                    break;
                case 4:
                    output = "four";
                    break;
                case 5:
                    output = "five";
                    break;
                case 6:
                    output = "six";
                    break;
                case 7:
                    output = "seven";
                    break;
                case 8:
                    output = "eight";
                    break;
                case 9:
                    output = "nine";
                    break;
                default:
                    output = "zero";
                    break;

            }

            Console.WriteLine(output);

        }
    }
}

