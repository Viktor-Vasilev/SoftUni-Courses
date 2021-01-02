using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    public class CarBuilder : ICarBuilder
    {
        public ICarBuilder BuildEngine(Car car)
        {
            car.Engine = "BestEngine";
            return this;
        }       

        public ICarBuilder BuildKutiq(Car car)
        {
            car.Kitiq = "Best Kutiq";
            return this;
        }

        public ICarBuilder BuildTyres(Car car)
        {
            car.Tyres = "Michelin";
            return this;
        }
    }
}
