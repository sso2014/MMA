using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Data;
using System.Drawing;

namespace GUI
{
    class Drawable:IDrawable
    {
        public void Display(System.Drawing.Graphics g, Nudo nudo)
        {
            g.FillEllipse(Brushes.Gray, 
                new Rectangle(nudo.point.X, nudo.point.Y, 30,30));
        }
    }
}
