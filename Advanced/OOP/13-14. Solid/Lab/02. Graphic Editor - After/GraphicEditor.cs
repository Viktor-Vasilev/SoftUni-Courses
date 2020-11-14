using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        public GraphicEditor()
        {

        }

        public void DrawShape(IShape shape)
        {
            Type classType = shape.GetType();
            Shape instance = Activator.CreateInstance(classType) as Shape;

            Console.WriteLine(instance.DrawShape());
        }

    }
}
