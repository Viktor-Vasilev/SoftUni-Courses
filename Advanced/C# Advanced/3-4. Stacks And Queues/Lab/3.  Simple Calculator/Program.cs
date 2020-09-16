using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Lab_3.__Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine().Split(' ').Reverse().ToArray();

            //Stack<string> stack = new Stack<string>();

            //for (int i = 0; i < expression.Length; i++)
            //{
            //    stack.Push(expression[i]);
            //}

            Stack<string> stack = new Stack<string>(expression);

            while (stack.Count > 1)
            {
                int first = int.Parse(stack.Pop());
                string sign = (stack.Pop());
                int second = int.Parse(stack.Pop());

                switch (sign)
                {
                    case "+":
                        stack.Push((first + second).ToString());
                        break;
                    case "-":
                        stack.Push((first - second).ToString());
                        break;
                }

            }

            Console.WriteLine(stack.Pop());

        }
       
    }
}
