using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting.ChartTypes;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.DataVisualization;


namespace MapeoDeAlgodon
{
    public partial class FrmMain : Form, IView
    {
        public FrmMain()
        {
            CrearPlanta = new FrmCreatePlanta();
            InitializeComponent();
            this.BindControl();
        }
        private FrmCreatePlanta CrearPlanta = new FrmCreatePlanta();
        private FrmCreateLote CrearLote = new FrmCreateLote();
        public event Action CreatedPlanta;
        public event Action CreatedNudo;
        public event Action SelectedPlanta;
        public event Action CreatedLote;
        public event Action SelectedLote;
        public event Action SelectedNudo;

        private List<Core.Data.Lote> loteList;
        private List<Core.Data.Planta> plantaList;
        private List<Core.Data.Nudo> nudoList;
        private List<Core.Data.State> estadoList;

        int ActualPlanta;
        int ActulaLote;

        private void BindControl()
        {
            LoteList.SelectedIndexChanged += OnSelectedLote;
            PlantaList.SelectedIndexChanged += OnSelectedPlanta;
            this.NudolistBox.SelectedIndexChanged += OnSelectedNudo;
            CrearPlanta.button1.Click += OnCreatePlanta;
            ctrlPlanta1.contextMenuStrip1.ItemClicked += OnCreateNudo;
            //ctrlPlanta1.MouseMove+=Mouse_Move_Nudo;
            CrearLote.button1.Click += OnCreateLote;
            
            
        }
        //void Mouse_Move_Nudo(object sender, MouseEventArgs e) {

        //    Nudo n = (Nudo)sender;
            
           
        //}
        void OnSelectedNudo(object sender, EventArgs e)
        {
            if (this.SelectedNudo != null)
            {
                this.SelectedNudo();
            }
        }
        void OnCreateLote(object sender, EventArgs e)
        {
            if (CreatedLote != null)
            {
                this.CreatedLote();
            }
        }
        void OnSelectedLote(object sender, EventArgs e)
        {
            if (SelectedLote != null)
            {
                SelectedLote();
            }
        }
        void OnCreateNudo(object sender, ToolStripItemClickedEventArgs e)
        {
            if (CreatedNudo != null)
            {
                this.ActulaLote = LoteList.SelectedIndex;
                this.ActualPlanta = this.PlantaList.SelectedIndex;
                this.CreatedNudo();
            }
        }
        void OnCreatePlanta(object sender, EventArgs e)
        {
            if (CreatedPlanta != null)
            {
                CreatedPlanta();
            }
        }
        public Core.Data.Planta SelectPlanta
        {
            get { return PlantaList.SelectedItem as Core.Data.Planta; }
        }
        public void LoadPlantas(List<Core.Data.Planta> plantas)
        {
            //listBox1.DataSource = plantas;    
        }
        public void LoadPlanta(Core.Data.Planta p)
        {
            NudolistBox.DataSource = p.Nudo;
            ctrlPlanta1.DataSouce = p;
            PlantaLabel.Text = p.Codigo;

            TempPlanta(p, "19/01/2015");

        }
        private void addDataListView(Core.Data.Nudo n) {

            this.listView1.Items.Clear();

            foreach(Core.Data.State s in n.Estado)
            {
                this.listView1.Items.Add(new ListViewItem(new string[]
                { 
                    s.Fecha.ToShortDateString(), s.Descripcion
                },0));
              
            }
        }
        private void TempPlanta(Core.Data.Planta p, string fecha)
        {

            //this.nudoList = pl
            //this.NudolistBox.DataSource = nudoList;
            tempPlanta.Nudo = new List<Core.Data.Nudo>();
            tempPlanta.Id = p.Id;
            tempPlanta.Codigo = p.Codigo;

            foreach (Core.Data.Nudo n in p.Nudo)
            {
                if (tempPlanta.Id == n.plantaID)
                {
                    foreach (Core.Data.State s in n.Estado)
                    {
                        if (n.Id == s.NudoID)
                        {
                            string f = s.Fecha.ToShortDateString();
                            //FechaComboBox.Items.Add(f);

                            if (f == fecha)
                            {
                                tempPlanta.Nudo.Add(n);
                            }
                        }
                    }
                }
            }
        }
        private void OnSelectedPlanta(object sender, EventArgs e)
        {
            if (SelectedPlanta != null)
            {
                SelectedPlanta();
            }
        }
        public void LoadLotes(IList<Core.Data.Lote> lotes)
        {
            if (lotes.Count > 0)
            {

                LoteList.DataSource = lotes;
                CrearPlanta.comboBox2.DataSource = lotes;
                PlantaList.DataSource = ((Core.Data.Lote)LoteList.SelectedItem).Plantas;
                ////ctrlPlanta1.DataSouce = listBox1.SelectedItem;   
                this.LoteList.SelectedIndex = ActulaLote;


                if (PlantaList.SelectedItem != null)
                {
                    this.PlantaList.SelectedIndex = ActualPlanta;

                    this.LoadNudos(((Core.Data.Planta)PlantaList.SelectedItem).Nudo);
                }

                this.AddLoteTreeView(lotes);

               
            }

            this.loteList = lotes.ToList();
            this.LoteList.DataSource = loteList;
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //CrearPlanta = new FrmCreatePlanta();                             
        }
        private void nuevaPlantaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearPlanta.ShowDialog();
        }
        public Core.Data.Planta SelectNewPlanta
        {
            get { return CrearPlanta.Planta; }
        }
        public void LoadLote(Core.Data.Lote lote)
        {
            if (lote != null)
            {
                PlantaList.DataSource = lote.Plantas;
                this.AddLoteTreeView(lote);
            }
        }
        public Core.Data.Lote SelectLote
        {
            get { return this.LoteList.SelectedItem as Core.Data.Lote; }
        }
        public Core.Data.Lote CreateLote
        {
            get { return CrearLote.Lote; }
        }
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearLote.ShowDialog();
        }
        public Core.Data.Planta CreatePlanta
        {
            get { return CrearPlanta.Planta; }
        }
        public void LoadNudo(Core.Data.Nudo nudo)
        {
            //EstadolistBox.DataSource = nudo.Estado;
            addDataListView(nudo);

        }
        void FiltrePlanta() {         
        }
        void AddLoteTreeView(IList<Core.Data.Lote> lotes)
        {
            this.treeLoteView1.Add(lotes);
        }
        void AddLoteTreeView(Core.Data.Lote l)
        {
            //treeView1.Nodes.Clear();

            //TreeNode tNode;
            
            //tNode = treeView1.Nodes.Add(l.Nombre);

            //foreach (Core.Data.Planta p in l.Plantas)
            //{
            //    treeView1.Nodes[0].Nodes.Add(p.Codigo); 
            //}

            //treeView1.Nodes[0].Nodes.Add("Net-informations.com");
            //treeView1.Nodes[0].Nodes[0].Nodes.Add("CLR");

            //treeView1.Nodes[0].Nodes.Add("Vb.net-informations.com");
            //treeView1.Nodes[0].Nodes[1].Nodes.Add("String Tutorial");
            //treeView1.Nodes[0].Nodes[1].Nodes.Add("Excel Tutorial");

            //treeView1.Nodes[0].Nodes.Add("Csharp.net-informations.com");
            //treeView1.Nodes[0].Nodes[2].Nodes.Add("ADO.NET");
            //treeView1.Nodes[0].Nodes[2].Nodes[0].Nodes.Add("Dataset");
         
        }
        public void LoadNudos(List<Core.Data.Nudo> nudos)
        {
            //this.nudoList = nudos;
            //this.NudolistBox.DataSource = nudoList;

            //tempPlanta.Nudo = new List<Core.Data.Nudo>();
            //tempPlanta.Id = "55";
            //tempPlanta.Codigo = "P1_PLANTA1";

            //foreach (Core.Data.Nudo n in nudos)
            //{
            //    if (tempPlanta.Id == n.plantaID)
            //    {
            //        foreach (Core.Data.State s in n.Estado)
            //        {
            //            if (n.Id == s.NudoID)
            //            {
            //                string f = s.Fecha.ToShortDateString();

            //                if (f == "19/01/2015")
            //                {

            //                    tempPlanta.Nudo.Add(n);
            //                }
            //            }
            //        }
            //    }
            //}
        }
        public Core.Data.Nudo SelectNudo
        {
            get { return this.NudolistBox.SelectedItem as Core.Data.Nudo; }
        }
        Core.Data.Nudo IView.CreateNudo
        {
            get { return ctrlPlanta1.Nudo; }
        }

        private List<Core.Data.Nudo> tempNudos = new List<Core.Data.Nudo>();
        private Core.Data.Planta tempPlanta = new Core.Data.Planta();

        private void button1_Click(object sender, EventArgs e)
        {
            ////if (tempPlanta != null)
            ////tempPlanta = null;
            ctrlPlanta1.DataSouce = tempPlanta;
        }
        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox1.Items.Clear();

            ListView.SelectedListViewItemCollection breakfast =
            this.listView1.SelectedItems;

            //double price = 0.0;
            foreach (ListViewItem item in breakfast)
            {
                //price += Double.Parse(item.SubItems[1].Text);
                 dateTimePicker1.Value = Convert.ToDateTime(item.SubItems[0].Text);
                 comboBox1.Text = item.SubItems[1].Text;
            }

            // Output the price to TextBox1.
            //TextBox1.Text = price.ToString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            this.ctrlPlanta1.Fecha = dateTimePicker2.Value;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }       
    }
}