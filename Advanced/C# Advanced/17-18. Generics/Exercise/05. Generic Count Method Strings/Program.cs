using System;
using System.Collections.Generic;

namespace E5GenericCountMethodStrings
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> values = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string currentValue = Console.ReadLine();

                values.Add(currentValue);

            }

            string valueToCompare = Console.ReadLine();

            Box<string> box = new Box<string>(values);

            int countOfGreaterValues = box.GetCountOfGreaterValues(valueToCompare);

            Console.WriteLine(countOfGreaterValues);

        }
    }
}
