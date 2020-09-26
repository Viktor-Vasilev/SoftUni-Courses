using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Exer_04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbers = new Dictionary<int, int>();

            while (n > 0)
            {
                n--;

                int currentNumber = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(currentNumber))
                {
                    numbers.Add(currentNumber, 0);
                }

                numbers[currentNumber]++;
            }

            foreach (var number in numbers.Where(x => x.Value % 2 == 0))
            {
                Console.WriteLine(number.Key);
            }



        }
    }
}
