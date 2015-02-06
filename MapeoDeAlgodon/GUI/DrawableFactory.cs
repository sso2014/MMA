using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GUI
{
    class DrawableFactory
    {
        public DrawableFactory()
        {
            Drawables.Clear();
        }

        Dictionary<int, IDrawable> Drawables =
            new Dictionary<int, IDrawable>();
        public IDrawable this[int num]{
            get {
                if (!Drawables.ContainsKey(num)) 
                   Drawables[num] = new DrawablePlanta();
                   return Drawables[num];
            }
        }
    }
}
