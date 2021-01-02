using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Factory
{
    public class AnimalFactory
    {
        public static IAnimal CreateAnimal(string animal)
        {
            if (animal == "peshojivotnoto")
            {
                return new PeshoJivotnoto();
            }
            if (animal == "lion")
            {
                return new Lion();
            }

            return null;
        }


    }
}
