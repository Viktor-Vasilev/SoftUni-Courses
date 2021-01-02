using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    public class CarBuilder : ICarBuilder
    {
        public void BuildEngine(Car car)
        {
            car.Engine = "BestEngine";
        }

        public void BuildKutiq(Car car)
        {
            car.Kitiq = "Best Kutiq";
        }

        public void BuildTyres(Car car)
        {
            car.Tyres = "Michelin";
        }
    }
}
