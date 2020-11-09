using System;

namespace _03._Fixing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weekdays = new string[5]
           {
                "Sunday",
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday"
           };

            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(weekdays[i].ToString());
                }
                Console.ReadLine();
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
