﻿
using System;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        
        public Circle(double radius)
        {
            this.Radius = radius;
        }

       
        public double Radius
        {
            get { return this.radius; }
            private set { this.radius = value; }
        }

        
        public override double CalculateArea() => Math.PI * Math.Pow(this.Radius, 2);

        public override double CalculatePerimeter() => 2 * Math.PI * this.Radius;

        public override string Draw()
        {
            return base.Draw() + "Circle";
        }



    }
}