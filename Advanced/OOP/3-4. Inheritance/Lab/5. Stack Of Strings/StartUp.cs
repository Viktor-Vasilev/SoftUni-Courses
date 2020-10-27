using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stackOfStrings = new StackOfStrings();
            List<string> strings = new List<string>();
            strings.Add("123");
            strings.Add("boza");
            strings.Add("chess");

            Stack<string> newStack = stackOfStrings.AddRange(strings);
            Console.WriteLine(String.Join(", ", newStack));

            

        }
    }
}
