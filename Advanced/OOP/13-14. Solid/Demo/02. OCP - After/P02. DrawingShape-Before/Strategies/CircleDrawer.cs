using P02._DrawingShape_Before.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02._DrawingShape_Before.Strategies
{
    public class CircleDrawer : IDrawingStrategy
    {
        public void Draw(IShape shape)
        {
            var circle = shape as Circle;
            Console.WriteLine($"Drawing circle{circle}");
        }

        public bool isMatch(IShape shape)
        {
            return shape is Circle; 
        }
    }
}
