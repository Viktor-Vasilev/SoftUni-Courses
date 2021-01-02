﻿using System;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            IDrawable picture = new ComplexShape("Picture");

            IDrawable sky = new ComplexShape("Sky");
            IDrawable cloud = new ComplexShape("Cloud");
            // IDrawable circle = new Circle("Circle");
            cloud.AddChild(new Circle());
            cloud.AddChild(new Circle());
            cloud.AddChild(new Circle());


            IDrawable cloud2 = new ComplexShape("Cloud 2");           
            cloud2.AddChild(new Circle());
            cloud2.AddChild(new Circle());
            cloud2.AddChild(new Circle());

            sky.AddChild(cloud);
            sky.AddChild(cloud2);
             
            IDrawable ground = new ComplexShape("Ground");
            ground.AddChild(new SimpleShape("Line"));

            picture.AddChild(sky);
            picture.AddChild(ground);

            picture.Draw(0);
        }
    }
}
