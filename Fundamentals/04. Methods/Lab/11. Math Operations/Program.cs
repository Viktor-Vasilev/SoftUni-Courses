using System;

namespace _11._Math_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            string operatora = Console.ReadLine();
            double num2 = double.Parse(Console.ReadLine());


            double result = MathOperations(num1, operatora, num2);

            Console.WriteLine(result);




        }

        static double MathOperations(double num1, string operatora, double num2)
        {
            double result = 0.0;

            if(operatora == "+")
            {
                result = num1 + num2;
            }
            else if (operatora == "-")
            {
                result = num1 - num2;
            }
            else if (operatora == "*")
            {
                result = num1 * num2;
            }
            else if (operatora == "/")
            {
                result = num1 / num2;
            }

            return result;
        }



    }
}
