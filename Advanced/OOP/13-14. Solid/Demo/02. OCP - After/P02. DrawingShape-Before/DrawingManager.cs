namespace P02._DrawingShape_Before
{
    using Contracts;
    using P02._DrawingShape_Before.Strategies;
    using System.Collections.Generic;
    using System.Linq;

    class DrawingManager : IDrawingManager
    {

        private List<IDrawingStrategy> strategies;

        public DrawingManager()
        {
            strategies = new List<IDrawingStrategy>()
            { 
             new CircleDrawer(),
             new RectangleDrawer()      
            };

        }
        
        
        
        
        public void Draw(IShape shape)
        {

            IDrawingStrategy drawer = strategies.First(s => s.isMatch(shape));        

            drawer.Draw(shape);
        }

       
    }
}
