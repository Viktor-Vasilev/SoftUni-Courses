using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {

            IShape shape = new Circle();

            GraphicEditor grEd = new GraphicEditor();

            grEd.DrawShape(shape);

        }
    }
}
