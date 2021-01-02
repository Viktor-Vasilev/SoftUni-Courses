using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Strategies
{
    public class QuickSort : ISortingStrategy
    {
        public void Sort(List<int> collection)
        {
            Console.WriteLine("Quick Sort");
        }
    }
}
