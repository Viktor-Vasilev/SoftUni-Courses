using FactoryMethod.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    public interface IAnimalFactory
    {
        public ICarnivore GetCarnivore();

        public IVegan GetVegan();

        public INasekomo GetNasekomo();


    }
}
