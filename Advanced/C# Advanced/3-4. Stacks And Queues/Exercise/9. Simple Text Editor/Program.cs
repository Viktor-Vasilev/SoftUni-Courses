using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Exer_9._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            string text = "";

            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                string[] commands = Console.ReadLine().Split(' ');

                if (commands[0] == "1") // append
                {
                    stack.Push(text);
                    text += commands[1];
                }
                else if (commands[0] == "2") // erase
                {
                    stack.Push(text);
                    text = text.Substring(0, text.Length - int.Parse(commands[1]));
                }
                else if (commands[0] == "3") // returns
                {
                    int index = int.Parse(commands[1]);
                    Console.WriteLine(text[index - 1]);

                }
                else if (commands[0] == "4") // undoes
                {
                    text = stack.Pop();
                }

            }

        }
    }
}
