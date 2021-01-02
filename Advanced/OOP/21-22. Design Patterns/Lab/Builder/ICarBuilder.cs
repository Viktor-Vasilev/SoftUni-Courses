using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    public interface ICarBuilder
    {
        void BuildTyres(Car car);

        void BuildEngine(Car car);

        void BuildKutiq(Car car);

    }
}
