using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;

namespace _1_Lab_1._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateString = Console.ReadLine();

            DateTime date = DateTime.ParseExact(dateString, "d-M-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(date.DayOfWeek);
        }
    }
}
