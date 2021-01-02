using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    public class Address : ICloneable
    {

        public City City { get; set; }

        public Country Country { get; set; }

        public string Street { get; set; }

        public object Clone()
        {

            // shallow clone:
            // return new Address() { City = City, Country = Country, Street = Street };

            // deep clone:
            var clone = (Address)this.MemberwiseClone();
            clone.City = (City)City.Clone();
            clone.Country = (Country)Country.Clone();

            return clone;

            // or
            // return DeepClone<Address>(this);

            // or           
            // return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"Country - {Country.Name}, City - {City.Name}, Street - {Street}";
        }
    }
}
