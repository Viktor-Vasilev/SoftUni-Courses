using System;

namespace _1._Square_Root
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine(Calculator.Sqrt(number));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.ParamName, ex.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
