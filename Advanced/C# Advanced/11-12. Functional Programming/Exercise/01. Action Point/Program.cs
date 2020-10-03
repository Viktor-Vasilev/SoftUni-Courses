using System;
using System.Linq;

namespace _2._Exer_01._Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {

            //string[] inputNames = Console.ReadLine().Split();

            //Action<string[]> action = name => Console.WriteLine(String.Join(Environment.NewLine, name));

            //action(inputNames);

            Action<string> printAction = Console.WriteLine;

            Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(printAction);

        }
    }
}
