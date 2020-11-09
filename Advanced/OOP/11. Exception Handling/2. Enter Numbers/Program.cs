using System;

namespace _2._Enter_Numbers
{
    public class Program
    {
        static void Main(string[] args)
        {

            try
            {
                ReadNumbers(10, 20);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ReadNumbers(int start, int end)
        {
            int prevNumber = 0;

            for (int i = 0; i < 10; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (i == 0)
                {
                    prevNumber = number;
                }

                if (number < prevNumber || number < start || number > end)
                {
                    throw new ArgumentOutOfRangeException("Number not in range");
                }
            }



        }
    }
}
