using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core.Data;


namespace MapeoDeAlgodon
{
    public partial class CtrlPlanta : UserControl
    {
        public CtrlPlanta()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            //Save........
            ds.Tables.Add("nudo");
            ds.Tables["nudo"].Columns.Add("posx", typeof(int));
            ds.Tables["nudo"].Columns.Add("posy", typeof(int));
            ds.Tables["nudo"].Columns.Add("name", typeof(string));
            ds.Tables["nudo"].Columns.Add("Width", typeof(int));
            ds.Tables["nudo"].Columns.Add("Height", typeof(int));

            InitializeComponent();
        }
        private Core.Data.Planta _planta;
        private List<Core.Data.Nudo> _nudosList;
        private Nudo nudo;
        private DateTime fecha = DateTime.Now;
        private DataSet ds = new DataSet();
        public DateTime Fecha
        {
            get { return this.fecha; }
            set {
                this.fecha = value;
            }
        }
        public object DataSouce
        {
            set
            {
                this.ResetColor();
                _planta = value as Core.Data.Planta;
                this._nudosList = this._planta.Nudo;
                DrawerNudos();
            }
        }
        public void Mouse_Move_Nudo(object sender, MouseEventArgs e) { 
            
        }
        private void ResetColor()
        {

            IEnumerator num = this.Controls.GetEnumerator();

            while (num.MoveNext())
            {
                Nudo nudo = num.Current as Nudo;
                nudo.BackColor = Color.LightGray;
            }
        }
        void SavePosition(Point Point, Size size, string name) {

            //ds.Tables.Add("nudo");
            //ds.Tables["nudo"].Columns.Add("posx",typeof(int));
            //ds.Tables["nudo"].Columns.Add("posy", typeof(int));
            //ds.Tables["nudo"].Columns.Add("posname", typeof(string));

            DataRow dr = ds.Tables["Nudo"].NewRow();
            dr["posx"] = Point.X;
            dr["posy"] = Point.Y;
            dr["name"] = name;
            dr["Width"] = size.Width;
            dr["height"] = size.Height;
            ds.Tables["nudo"].Rows.Add(dr);

        }
        private void DrawerNudos()
        {
            if (this._planta != null)
            {
                IEnumerator num = this.Controls.GetEnumerator();
                while (num.MoveNext())
                {
                    Nudo nudo = num.Current as Nudo;

                    SavePosition(nudo.Location,nudo.Size, nudo.Name);//save...

                    foreach (Core.Data.Nudo n in _planta.Nudo)
                    {
                        if (nudo.Name.Substring(4) == n.Pos)
                        {
                            foreach (Core.Data.State s in n.Estado)
                            {
                                if (Convert.ToDateTime(s.Fecha.ToShortDateString()) <= Convert.ToDateTime(this.fecha.ToShortDateString()))
                                {
                                    nudo.BackColor = GetColor(n);

                                }
                                else {
                                    //nudo.BackColor = Color;
                                }
                              
                            }                          
                        }
                    }
                }

                ds.WriteXml("Nudo.xml");

            }
        }
        private int GetEstado(string estado)
        {
            int num;

            switch (estado)
            {
                case "A ":
                    num = 1;
                    break;
                case "P ":
                    num = 2;
                    break;
                case "F ":
                    num = 3;
                    break;
                case "V ":
                    num = 4;
                    break;
                case "B ":
                    num = 5;
                    break;
                case "C ":
                    num = 6;
                    break;
                case "Pd":
                    num = 7;
                    break;
                case "Dp":
                    num = 8;
                    break;
                //case "Bv":
                //    num = 9;
                //    break;
                //case "Bm":
                //    num = 10;
                //    break;
                default:
                    num = 0;
                    break;
            }
            return num;
        }
        private Color GetColor(Core.Data.Nudo n)
        {
            Color color = Color.Gray;


            if (n.Estado[n.Estado.Count - 1].Descripcion != null)
            {

                switch (n.Estado[n.Estado.Count - 1].Descripcion.Substring(0, 2))
                {
                    case "A ":
                        color = Color.Red;
                        break;
                    case "P ":
                        color = Color.Blue;
                        break;
                    case "F ":
                        color = Color.Yellow;
                        break;
                    case "V ":
                        color = Color.Lime;
                        break;
                    case "B ":
                        color = Color.Green;
                        break;
                    case "C ":
                        color = Color.White;
                        break;
                    case "Pd":
                        color = Color.Navy;
                        break;
                    case "Dp":
                        color = Color.Maroon;
                        break;
                    //case "Bv":
                    //    color = Color.GreenYellow;
                    //    break;
                    //case "Bm":
                    //    color = Color.Teal;
                    //    break;
                    default:
                        color = Color.Gray;
                        break;
                }
                return color;
            }
            return color;

        }
        private Color GetColor(string estado)
        {
            Color color;

            switch (estado)
            {
                case "A ":
                    color = Color.Red;
                    break;
                case "P ":
                    color = Color.Blue;
                    break;
                case "F ":
                    color = Color.Yellow;
                    break;
                case "V ":
                    color = Color.Lime;
                    break;
                case "B ":
                    color = Color.Green;
                    break;
                case "C ":
                    color = Color.White;
                    break;
                case "Pd":
                    color = Color.Navy;
                    break;
                case "Dp":
                    color = Color.Maroon;
                    break;
                //case "Bv":
                //    color = Color.GreenYellow;
                //    break;
                //case "Bm":
                //    color = Color.Teal;
                //    break;
                default:
                    color = Color.Red;
                    break;
            }
            return color;
        }
        private void CreateNudo()
        {

            //Core.Data.Nudo n = new Core.Data.Nudo()
            //{
            //    plantaID = planta.Id,
            //    Pos = nudo.Name.Substring(4)
            //};
            //Core.Data.State estado = new State()
            //{
            //    Fecha = DateTime.Now,
            //    StateID = this.GetEstado(e.ClickedItem.Text.Substring(2))
            //};
            //n.Estados = new List<State>();
            //n.Estados.Add(estado);
            //this.Nudo = n;
        }
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                bool nuevo = true;

                #region DELETE

                if (e.ClickedItem.Text == "Eliminar")
                {

                    if (this._planta != null)
                    {
                        foreach (Core.Data.Nudo n in this._planta.Nudo)
                        {
                            if (this.nudo.Name.Substring(4) == n.Pos)
                            {
                                nudo.BackColor = GetColor(n);

                                this.Nudo = n;
                                this.Nudo.Dead = true;
                                //this.Nudo.Estado.Add(new State()
                                //{
                                //    NudoID = n.Id,
                                //    StateID = GetEstado(e.ClickedItem.Text.Substring(0, 2))
                                //});
                                //nudo.BackColor = GetColor(e.ClickedItem.Text.Substring(0, 2));

                                nuevo = false;
                            }
                        }
                    }
                }
                else
                {
                #endregion
                    #region UPDATE
                    if (this._planta != null)
                    {

                        foreach (Core.Data.Nudo n in this._planta.Nudo)
                        {
                            if (this.nudo.Name.Substring(4) == n.Pos)
                            {
                                nudo.BackColor = GetColor(n);

                                this.Nudo = n;

                                this.Nudo.Estado.Add(new State()
                                {
                                    NudoID = n.Id,
                                    Fecha = this.fecha,
                                    StateID = GetEstado(e.ClickedItem.Text.Substring(0, 2))

                                });
                                nudo.BackColor = GetColor(e.ClickedItem.Text.Substring(0, 2));

                                nuevo = false;
                            }
                        }
                    #endregion
                        #region CREATE

                        if (nuevo)
                        {
                            Core.Data.Nudo newNudo = new Core.Data.Nudo();
                            newNudo.Id = 0;
                            newNudo.plantaID = _planta.Id;
                            newNudo.Pos = nudo.Name.Substring(4);
                            Core.Data.State estado = new State();
                            estado.StateID = GetEstado(e.ClickedItem.Text.Substring(0, 2));
                            estado.Fecha = this.fecha;
                            nudo.BackColor = GetColor(e.ClickedItem.Text.Substring(0, 2));
                            newNudo.Estado = new List<State>();
                            newNudo.Estado.Add(estado);
                            this.Nudo = newNudo;
                        }
                    }

                        #endregion
                }
            }
            catch (Exception exp)
            {
                string msg = exp.Message;
            }
        }
        public Core.Data.Nudo Nudo { get; set; }
        private void nudoS1_Enter(object sender, EventArgs e)
        {
            nudo = sender as Nudo;
        }
        private void nudoBB_Click(object sender, EventArgs e)
        {
            //if (_planta != null)
            //{

            //    foreach (Core.Data.Nudo n in this._planta.Nudo)
            //    {
            //        if (this.nudo.Name.Substring(4) == n.Pos)
            //        {
            //            nudo.BackColor = GetColor(n);

            //            this.Nudo = n;

            //            //this.Nudo.Estado.Add(new State()
            //            //{
            //            //    NudoID = n.Id,
            //            //    //StateID = GetEstado(e.ClickedItem.Text.Substring(0, 2))
            //            //});
            //            //nudo.BackColor = GetColor(e.ClickedItem.Text.Substring(0, 2));

            //            //nuevo = false;
            //        }
            //    }
            //}
        }
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}