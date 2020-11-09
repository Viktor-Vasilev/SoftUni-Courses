

using E7MilitaryElite.Contracts;
using E7MilitaryElite.Enumerations;
using E7MilitaryElite.Exceptions;
using System;
using System.Dynamic;

namespace E7MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = TryParseCorps(corps);
        }

        public Corps Corps {get; private set;}

        private Corps TryParseCorps(string corpsStr)
        {           
            bool parsed = Enum.TryParse<Corps>(corpsStr, out Corps corps);

            if (!parsed)
            {
                throw new InvalidCorpsException();
            }

            return corps;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {this.Corps.ToString()}";
        }

    }
}
