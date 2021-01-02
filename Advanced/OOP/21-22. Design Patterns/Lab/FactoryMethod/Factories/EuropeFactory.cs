using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Contracts.Factories
{
    public class EuropeFactory : IAnimalFactory
    {
        public INasekomo GetNasekomo()
        {
            throw new NotImplementedException();
        }

        public IVegan GetVegan()
        {
            throw new NotImplementedException();
        }

        ICarnivore IAnimalFactory.GetCarnivore()
        {
            return new EnglishMan();
        }
    }
}
