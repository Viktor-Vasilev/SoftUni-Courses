using System;

namespace Simple_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            IAnimal lion = AnimalFactory.CreateAnimal("lion");
            Console.WriteLine(lion.Name);
        }
    }
}
