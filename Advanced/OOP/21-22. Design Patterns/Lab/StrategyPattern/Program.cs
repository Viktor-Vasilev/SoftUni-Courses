using StrategyPattern.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            string sortType = Console.ReadLine();

            Type strategyType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(ISortingStrategy).IsAssignableFrom(t) &&
                t.Name.StartsWith(sortType))
                .FirstOrDefault();

            ISortingStrategy strategy = (ISortingStrategy)Activator.CreateInstance(strategyType);

            Sorter sorter = new Sorter(strategy);

            sorter.Sort(new List<int>() { 1, 5, 2, 3, 7, 9 });
        }
    }
}
