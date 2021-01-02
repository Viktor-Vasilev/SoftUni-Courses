using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    public interface IDrawable
    {
        public string Name { get; set; }

        void Draw(int level);

        void AddChild(IDrawable child);

    }
}
