using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MapeoDeAlgodon
{
    public partial class Nudo : UserControl
    {
        public Nudo()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(pen,
            new Rectangle(1, 1, this.Width - 2, this.Height - 2));
            GraphicsPath Gpath = new GraphicsPath();
            Gpath.AddEllipse(new Rectangle(0, 0, this.Width, this.Height));
            this.Region = new Region(Gpath);
            base.OnPaint(e);
        }
        private Pen pen = new Pen(Color.Black, 1);
        public string Id { get; set; }
        public int Estado { get; set; }

        //public Core.Data.Nudo Nudo { get; set; }
        private void Nudo_Click(object sender, EventArgs e)
        {
            //pen = new Pen(Color.Blue, 2);
            //this.Refresh();
        }
        private void Nudo_MouseEnter(object sender, EventArgs e)
        {
            pen = new Pen(Color.Blue, 2);
            this.Refresh();
        }
        private void Nudo_MouseLeave(object sender, EventArgs e)
        {
            pen = new Pen(Color.Black, 1);
            this.Refresh();
        }
    }
}