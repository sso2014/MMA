using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Core.Data;

namespace GUI
{
    public partial class CtrlPlanta : UserControl
    {
        public CtrlPlanta()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            InitializeComponent();
            CreateList();
        }
        private DataSet ds = new System.Data.DataSet();

        Dictionary<Point, Core.Data.Nudo> _NudoDictionary =
               new Dictionary<Point, Core.Data.Nudo>();

        //private List<Core.Data.Nudo> _nudoList;

        List<Core.Data.Nudo> _nudoList;
        private Core.Data.Planta _planta;
        private DateTime _fecha = DateTime.Now;

        private List<Core.Data.Nudo> nudos;
        private Core.Data.Nudo _nudo;
        public delegate void PlantaHadler(object sender, EventArgs e);
        public event PlantaHadler SelectedNudoEvent;
        public object DataSouce
        {
            set
            {
                if (value != null)
                {
                    this._planta = value as Core.Data.Planta;
                    //this.nudos = p.Nudo;
                    //this.Drawer();
                    foreach(Core.Data.Nudo n in this._nudoList){
                        if (n.Estado != null){
                            n.plantaID = string.Empty;
                            n.Id = 0;
                            n.Estado = null;
                        }
                    }
                    foreach (Core.Data.Nudo n in this._planta.Nudo)
                    {
                        foreach(Core.Data.Nudo nl in this._nudoList){
                            if (n.Pos == nl.Pos){
                                nl.Id = n.Id;
                                nl.plantaID = n.plantaID;
                                nl.Estado = n.Estado;
                            }
                        }
                    }
                    this.Drawer2();
                }
            }
        }
        private void DrawerStateColor(Core.Data.Nudo n, Graphics g)
        {
            if (n.Estado != null)
            {
                if (n.Estado.Count > 0)
                {
                    DateTime d  =  n.Estado.Max(s => s.Fecha);

                    foreach (State s in n.Estado)
                    {
                        if (s.Fecha == d)
                        {
                            switch (s.StateID)
                            {
                                case 1:
                                    //System.Drawing.Drawing2D.LinearGradientBrush lg1 = new System.Drawing.Drawing2D.LinearGradientBrush(
                                    //   new Rectangle(n.point, n.size), Color.LightSlateGray, Color.Red, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
                                    g.DrawEllipse(new Pen(Brushes.DarkBlue,2),
                                        new Rectangle(n.point, n.size));
                                    g.FillEllipse(Brushes.Red,
                                        new Rectangle(n.point, n.size));
                                    //lg1.Dispose();

                                    break;
                                case 2:
                                    //System.Drawing.Drawing2D.LinearGradientBrush lg2 = new System.Drawing.Drawing2D.LinearGradientBrush(
                                    //     new Rectangle(n.point, n.size), Color.LightSlateGray, Color.Blue, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
                                    g.DrawEllipse(Pens.Black,
                                        new Rectangle(n.point, n.size));
                                    g.FillEllipse(Brushes.Blue,
                                        new Rectangle(n.point, n.size));
                                    //lg2.Dispose();
                                    break;
                                case 3:
                                    //System.Drawing.Drawing2D.LinearGradientBrush lg3 = new System.Drawing.Drawing2D.LinearGradientBrush(
                                    //     new Rectangle(n.point, n.size), Color.LightSlateGray, Color.Yellow, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
                                    g.DrawEllipse(Pens.Black,
                                        new Rectangle(n.point, n.size));
                                    g.FillEllipse(Brushes.Yellow,
                                        new Rectangle(n.point, n.size));
                                    //lg3.Dispose();
                                    break;
                                case 4:
                                    //System.Drawing.Drawing2D.LinearGradientBrush lg4 = new System.Drawing.Drawing2D.LinearGradientBrush(
                                    //     new Rectangle(n.point, n.size), Color.LightSlateGray, Color.Lime, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
                                    g.DrawEllipse(Pens.Black,
                                        new Rectangle(n.point, n.size));
                                    g.FillEllipse(Brushes.Lime,
                                        new Rectangle(n.point, n.size));
                                    //lg4.Dispose();
                                    break;
                                case 5:
                                    //System.Drawing.Drawing2D.LinearGradientBrush lg5 = new System.Drawing.Drawing2D.LinearGradientBrush(
                                    //     new Rectangle(n.point, n.size), Color.LightSlateGray, Color.Green, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
                                    g.DrawEllipse(Pens.Black,
                                        new Rectangle(n.point, n.size));
                                    g.FillEllipse(Brushes.Green,
                                        new Rectangle(n.point, n.size));
                                    //lg5.Dispose();
                                    break;
                                case 6:
                                    //System.Drawing.Drawing2D.LinearGradientBrush lg6 = new System.Drawing.Drawing2D.LinearGradientBrush(
                                    //     new Rectangle(n.point, n.size), Color.LightSlateGray, Color.White, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
                                    g.DrawEllipse(Pens.Black,
                                        new Rectangle(n.point, n.size));
                                    g.FillEllipse(Brushes.White,
                                        new Rectangle(n.point, n.size));
                                    //lg6.Dispose();
                                    break;
                                case 7:
                                    //System.Drawing.Drawing2D.LinearGradientBrush lg7 = new System.Drawing.Drawing2D.LinearGradientBrush(
                                    //     new Rectangle(n.point, n.size), Color.LightSlateGray, Color.CadetBlue, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
                                    g.DrawEllipse(Pens.Black,
                                        new Rectangle(n.point, n.size));
                                    g.FillEllipse(Brushes.DarkSlateGray,
                                        new Rectangle(n.point, n.size));
                                    //lg7.Dispose();
                                    break;
                                case 8:
                                    //System.Drawing.Drawing2D.LinearGradientBrush lg8 = new System.Drawing.Drawing2D.LinearGradientBrush(
                                    //    new Rectangle(n.point, n.size), Color.LightSlateGray, Color.Brown, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
                                    g.DrawEllipse(Pens.Black,
                                        new Rectangle(n.point, n.size));
                                    g.FillEllipse(Brushes.SaddleBrown,
                                        new Rectangle(n.point, n.size));
                                    //lg8.Dispose();
                                    break;
                                default:
                                    g.FillEllipse(Brushes.Black,
                                        new Rectangle(n.point, n.size));
                                    break;
                            }
                        }
                    }
                }
            }
        }
        private void CreateList()
        {
            ds.ReadXml("Nudo.xml");
            _nudoList = new List<Core.Data.Nudo>();

            foreach (DataRow dr in ds.Tables["Nudo"].Rows)
            {
                _nudoList.Add(new Core.Data.Nudo()
                {
                    Pos = dr["Name"].ToString().Substring(4,2),
                    point = new Point(Convert.ToInt32(dr["posx"]), Convert.ToInt32(dr["posy"])),
                    size = new System.Drawing.Size(Convert.ToInt32(dr["Width"]), Convert.ToInt32(dr["height"])),
                    Estado = null
                });
            }
        }
        private Image img;
        private void Drawer2()
        {
            img = new Bitmap(GUI.Properties.Resources.Grid4);
            Graphics g = Graphics.FromImage(img);
            foreach(Core.Data.Nudo n in _nudoList){

                if (n.Estado != null)
                {
                    //System.Drawing.Drawing2D.LinearGradientBrush lg = new System.Drawing.Drawing2D.LinearGradientBrush(
                    //            new Rectangle(n.point, n.size), Color.LightGray, Color.Blue, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
                    //g.DrawEllipse(Pens.Black,
                    //    new Rectangle(n.point, n.size));
                    //g.FillEllipse(lg,
                    //    new Rectangle(n.point, n.size));
                    //lg.Dispose();
                    this.DrawerStateColor(n, g);
                }
                else
                {
                    Pen p = new Pen(Color.Black, 2);
                    g.DrawEllipse(p,
                           new Rectangle(n.point, n.size));
                    g.FillEllipse(Brushes.LightGray,
                        new Rectangle(n.point, n.size));
                }
            }
            this.BackgroundImage = img;
        }
        private void Drawer()
        {
            //ds.ReadXml(@"C:\Users\Administrador\Documents\Visual Studio 2013\Projects\MapeoDeAlgodon\GUI\bin\Debug\nudo.xml");
            ds.ReadXml("Nudo.xml");
            //Image img = new Bitmap(@"c:\grid4.png");
            Image img = new Bitmap("grid4.png");
            Graphics g = Graphics.FromImage(img);
            g.DrawImage(img, new Point(0, 0));
            foreach (DataRow dr in ds.Tables["Nudo"].Rows)
            {
                g.DrawEllipse(Pens.Black,
                    new Rectangle(
                        Convert.ToInt32(dr["posx"]),
                        Convert.ToInt32(dr["posy"]),
                        Convert.ToInt32(dr["Width"]),
                        Convert.ToInt32(dr["height"])));

                g.FillEllipse(Brushes.LightGray,
                    new Rectangle(
                        Convert.ToInt32(dr["posx"]),
                        Convert.ToInt32(dr["posy"]),
                        Convert.ToInt32(dr["Width"]),
                        Convert.ToInt32(dr["height"])));
            }
            foreach (Core.Data.Nudo n in nudos)
            {
                foreach (DataRow dr in ds.Tables["Nudo"].Rows)
                {
                    if (n.Pos == dr["name"].ToString().Substring(4, 2))
                    {

                        n.point = new Point(Convert.ToInt32(dr["posx"]),
                        Convert.ToInt32(dr["posy"]));
                        n.size = new System.Drawing.Size(
                        Convert.ToInt32(dr["Width"]),
                        Convert.ToInt32(dr["height"]));
                        System.Drawing.Drawing2D.LinearGradientBrush lg = new System.Drawing.Drawing2D.LinearGradientBrush(
                            new Rectangle(n.point, n.size), Color.LightGray, Color.Blue, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
                        g.FillEllipse(lg,
                            new Rectangle(n.point.X, n.point.Y, n.size.Width, n.size.Height));
                        g.DrawEllipse(Pens.Black,
                            new Rectangle(n.point.X, n.point.Y, n.size.Width, n.size.Height));
                        lg.Dispose();
                    }
                }
            }
            //}            
            //img.Save(@"c:\Planta.jpg");
            this.BackgroundImage = img;
        }
        public Core.Data.Nudo SelectedNudo
        {
            get { return _nudo; }
            set { _nudo = value; }
        }
        private void Trigger()
        {
            if (this.SelectedNudoEvent != null)
            {
                this.SelectedNudoEvent(this, null);
            }
        }
        private void CtrlPlanta_MouseMove(object sender, MouseEventArgs e)
        {
            if (this._nudoList != null)
            {
                foreach (Core.Data.Nudo n in this._nudoList)
                {
                    if (e.X >= n.point.X && e.X <= (n.point.X + n.size.Width) && e.Y >= n.point.Y && e.Y <= (n.point.Y + n.size.Height))
                    {                      
                        this._nudo = n;
                       this.Trigger();                       
                    }           
                }               
            }
        }
        public DateTime fecha {
            get {return this._fecha; }
            set { this._fecha = value;}
        }
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (this._nudo.Id == 0)
            {                
                switch(e.ClickedItem.Text.Substring(0,2)){
                    case "A ":
                        this._nudo.Estado = new List<State>();
                        this._nudo.plantaID = this._planta.Id;
                        this._nudo.Estado.Add(new State() { 
                            StateID = 1,
                            Fecha = this._fecha
                        });
                        break;
                    case "P ":
                        this._nudo.Estado = new List<State>();
                        this._nudo.plantaID = this._planta.Id;
                        this._nudo.Estado.Add(new State() { 
                            StateID = 2,
                            Fecha = this._fecha
                        });
                         break;
                    case "F ":
                         this._nudo.Estado = new List<State>();
                         this._nudo.plantaID = this._planta.Id;
                         this._nudo.Estado.Add(new State() { 
                            StateID = 3,
                            Fecha = this._fecha
                        });
                         break;
                    case "V ":
                         this._nudo.Estado = new List<State>();
                         this._nudo.plantaID = this._planta.Id;
                         this._nudo.Estado.Add(new State() { 
                            StateID = 4,
                            Fecha = this._fecha
                        });
                         break;
                    case "B ":
                         this._nudo.Estado = new List<State>();
                         this._nudo.plantaID = this._planta.Id;
                         this._nudo.Estado.Add(new State() { 
                            StateID = 5,
                            Fecha = this._fecha
                        });
                        break;
                    case "C ":
                         this._nudo.Estado = new List<State>();
                         this._nudo.plantaID = this._planta.Id;
                         this._nudo.Estado.Add(new State() { 
                            StateID = 6,
                            Fecha = this._fecha
                        });
                        break;
                    case "Pd":
                         this._nudo.Estado = new List<State>();
                         this._nudo.plantaID = this._planta.Id;
                         this._nudo.Estado.Add(new State() { 
                            StateID = 7,
                            Fecha = this._fecha
                        });
                        break;
                    case "Dp":
                         this._nudo.Estado = new List<State>();
                         this._nudo.plantaID = this._planta.Id;
                         this._nudo.Estado.Add(new State() { 
                            StateID = 8,
                            Fecha = this._fecha
                        });
                        break;
                    default :
                        break;
                }
            }         
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
        //private void CtrlPlanta_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (nudos != null)
        //    {
        //        foreach (Core.Data.Nudo n in this.nudos)
        //        {
        //            if (e.X >= n.point.X && e.X <= (n.point.X + n.size.Width) && e.Y >= n.point.Y && e.Y <= (n.point.Y + n.size.Height))
        //            {
        //                this._nudo = n;
        //                this.Trigger();
        //            }
        //        }
        //    }
        //}
    }
}