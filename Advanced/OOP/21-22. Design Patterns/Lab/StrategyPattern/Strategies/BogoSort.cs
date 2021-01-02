using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Strategies
{
    public class BogoSort : ISortingStrategy
    {
        public void Sort(List<int> collection)
        {
            Console.WriteLine("Bogo sort");
        }
    }
}
