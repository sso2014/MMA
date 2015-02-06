using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Core.Data;

namespace GUI
{
    interface IDrawable
    {
       void Display(Graphics g, Nudo nudo);
    }
}
