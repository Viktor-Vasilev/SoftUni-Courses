using System;
using System.Collections.Generic;
using System.Text;

namespace E8Threeuple
{
    public class Threeuple<T1, T2, T3>
    {
        public Threeuple(T1 firstItem, T2 secondItem, T3 thirdItem)
        {
            this.Item1 = firstItem;
            this.Item2 = secondItem;
            this.Item3 = thirdItem;
        }

        public T1 Item1 { get; private set; }
        public T2 Item2 { get; private set; }
        public T3 Item3 { get; private set; }


        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2} -> {this.Item3}";
        }






    }
}
