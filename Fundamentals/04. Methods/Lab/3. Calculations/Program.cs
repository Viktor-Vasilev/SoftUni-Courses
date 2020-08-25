using System;

namespace _3._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string action = Console.ReadLine();

            double num1 =double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());


            Calculations(action, num1, num2);


        }

        static void Calculations(string action, double num1, double num2)
        {
            double result = 0;

            if(action == "add")
            {
                result = num1 + num2;
            }
            if (action == "substract")
            {
                result = num1 - num2;
            }
            if (action == "divide")
            {
                result = num1 / num2;
            }
            if (action == "multiply")
            {
                result = num1 * num2;
            }

            Console.WriteLine(result);

        }


    }
}
