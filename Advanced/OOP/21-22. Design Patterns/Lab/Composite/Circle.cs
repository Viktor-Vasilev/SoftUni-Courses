using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    public class Circle : SimpleShape
    {

        public Circle() : base("Circle")
        {

        }

        public Circle(string name) : base(name)
        {
        }
    }
}
