using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var scale = new EqualityScale<int>(5, 6);
            Console.WriteLine(scale.AreEqual());

            var scale2 = new EqualityScale<int>(5, 5);
            Console.WriteLine(scale2.AreEqual());




        }
    }
}
