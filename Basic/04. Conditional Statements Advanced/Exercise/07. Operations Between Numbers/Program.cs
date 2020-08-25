using System;

namespace _07._Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());

            switch (operation)
            {
                case '+':
                    double sum = num1 + num2;
                    if (sum % 2 == 0)
                    {
                        Console.WriteLine($"{num1} {operation} {num2} = {sum} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{num1} {operation} {num2} = {sum} - odd");
                    }
                    break;
                case '-':
                    double result = num1 - num2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{num1} {operation} {num2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{num1} {operation} {num2} = {result} - odd");
                    }
                    break;
                case '*':
                    double multiply = num1 * num2;
                    if (multiply % 2 == 0)
                    {
                        Console.WriteLine($"{num1} {operation} {num2} = {multiply} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{num1} {operation} {num2} = {multiply} - odd");
                    }
                    break;
                case '/':
                    double division = num1 * 1.0 / num2;

                    if (num2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {num1} by zero");
                    }
                    else
                    {
                        Console.WriteLine($"{num1} / {num2} = {division:F2}");
                    }
                    break;
                case '%':
                    double modul = num1 * 1.0 % num2;

                    if (num2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {num1} by zero");
                    }
                    else
                    {
                        Console.WriteLine($"{num1} % {num2} = {modul}");
                    }
                    break;

            }
        }
    }
}
