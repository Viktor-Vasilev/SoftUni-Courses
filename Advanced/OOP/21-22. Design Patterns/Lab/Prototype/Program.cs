using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {

            Country country = new Country() {Name = "Uzbekistan"};

            City city = new City() { Name = "Uzbekistan City" };

            Address address = new Address() {Street = "Uzbeki 29" };

            address.City = city;

            address.Country = country;

            Address prototypedAddress = (Address)address.Clone();

            prototypedAddress.City.Name = "Sofia";

            prototypedAddress.Street = "Sofia 15";

            Console.WriteLine(address);
            Console.WriteLine(prototypedAddress);



        }
    }
}
