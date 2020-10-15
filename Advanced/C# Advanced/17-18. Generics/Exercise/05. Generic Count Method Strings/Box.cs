using System;
using System.Collections.Generic;
using System.Text;

namespace E5GenericCountMethodStrings
{ 
    public class Box<T> where T : IComparable
    {
        public List<T> Values { get; set; } = new List<T>();

        public Box(List<T> values)
        {
            this.Values = values;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            T tempValue = this.Values[firstIndex];
            this.Values[firstIndex] = this.Values[secondIndex];
            this.Values[secondIndex] = tempValue;

        }

        public int GetCountOfGreaterValues(T value)
        {
            int counter = 0;

            foreach (var currentValue in this.Values)
            {
                if (value.CompareTo(currentValue) < 0)
                {
                    counter++;
                }
            }


            return counter;

        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var value in this.Values)
            {
                stringBuilder.AppendLine($"{value.GetType()}: {value}");
            }

            return stringBuilder.ToString().TrimEnd();
        }

    }
}
