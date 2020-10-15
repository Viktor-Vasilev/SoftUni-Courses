using System;
using System.Collections.Generic;
using System.Text;

namespace E3GenericSwapMethodStrings
{
    public class Box<T>
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
