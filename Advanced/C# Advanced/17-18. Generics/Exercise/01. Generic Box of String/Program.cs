using System;

namespace GenericBoxofString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string currentValue = Console.ReadLine();

                Box<string> box = new Box<string>(currentValue);

                Console.WriteLine(box);
            }


        }
    }
}
