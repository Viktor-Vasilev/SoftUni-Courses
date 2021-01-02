using FactoryMethod.Contracts;
using FactoryMethod.Contracts.Factories;
using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which contitnent do you want to play?");

            string contitnent = Console.ReadLine();

            IAnimalFactory factory = null;

            if (contitnent == "Africa")
            {
                factory = new AfricaFactory();
            }
            else if (contitnent == "Europe")
            {
                factory = new EuropeFactory();
            }

            ICarnivore animal = factory.GetCarnivore();
        }
    }
}
