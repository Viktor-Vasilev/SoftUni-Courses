using E3ShoppingSpree.Core;
using System;

namespace E3ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Engine engine = new Engine();
                engine.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }




        }
    }
}
