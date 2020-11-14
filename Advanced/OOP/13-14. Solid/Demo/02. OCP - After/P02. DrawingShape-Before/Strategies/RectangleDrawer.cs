using P02._DrawingShape_Before.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02._DrawingShape_Before.Strategies
{
    public class RectangleDrawer : IDrawingStrategy
    {
        public void Draw(IShape shape)
        {
            var rectangle = shape as Rectangle;
            Console.WriteLine($"Drawing rectangle{rectangle}");
        }

        public bool isMatch(IShape shape)
        {
            return shape is Rectangle;
        }

    }
}
