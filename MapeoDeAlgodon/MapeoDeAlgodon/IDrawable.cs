using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapeoDeAlgodon
{
    interface IDrawable
    {
        void Draw(Core.Data.Nudo n, System.Drawing.Graphics g);
    }
}
