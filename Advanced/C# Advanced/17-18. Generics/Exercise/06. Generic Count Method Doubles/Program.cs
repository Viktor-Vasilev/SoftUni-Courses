using System;
using System.Collections.Generic;

namespace E6GenericCountMethodDoubles
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<double> values = new List<double>();

            for (int i = 0; i < n; i++)
            {
                double currentValue = double.Parse(Console.ReadLine());

                values.Add(currentValue);

            }

            double valueToCompare = double.Parse(Console.ReadLine());

            Box<double> box = new Box<double>(values);

            int countOfGreaterValues = box.GetCountOfGreaterValues(valueToCompare);

            Console.WriteLine(countOfGreaterValues);

        }
    }
}
