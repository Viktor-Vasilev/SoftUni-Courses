using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Strategies
{
    public interface ISortingStrategy
    {
        void Sort(List<int> collection);



    }
}
