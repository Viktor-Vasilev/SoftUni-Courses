using System;
using System.Linq;

namespace _1._Lab_03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(w => char.IsUpper(w[0])).ToList().ForEach(Console.WriteLine);

            //Func<string, bool> func = word => char.IsUpper(word[0]);

            //Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(func).ToList().ForEach(word => Console.WriteLine(word));

        }
    }
}
