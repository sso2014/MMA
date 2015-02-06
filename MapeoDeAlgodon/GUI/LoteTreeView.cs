using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    class LoteTreeView : System.Windows.Forms.TreeView
    {
        public LoteTreeView()
        {
            InitializeComponent();
        }

        private ImageList imageList1;
        private System.ComponentModel.IContainer components;
        private Core.Data.Planta _planta = new Core.Data.Planta();

        public object DataSouce
        {
            set
            {
                List<Core.Data.Lote> lotes = value as List<Core.Data.Lote>;
                TreeNode LoteNode = new TreeNode("LOTES");
                //TreeNode PlantaNode = new TreeNode("PLANTAS");

                this.Nodes.Clear();

                foreach (Core.Data.Lote l in lotes)
                {
                    LoteNode.Nodes.Add(l.LoteID, l.Nombre);
                    //TreeNode nPlanta = new TreeNode("PLANTAS");
                    foreach (TreeNode node in LoteNode.Nodes)
                    {
                        if (l.Plantas != null)
                        {

                            foreach (Core.Data.Planta p in l.Plantas)
                            {
                                if (node.Name == p.LoteID)
                                {
                                    //PlantaNode.Nodes.Add(p.Id, p.Codigo);
                                    ////nPlanta.Nodes.Add(p.Id, p.Codigo);
                                    LoteNode.Nodes[node.Name].Nodes.Add(p.Id, p.Codigo, 1, 2);
                                }
                            }
                        }
                        //LoteNode.Nodes[node.Name].Nodes.Add(nPlanta);
                        //break;
                    }
                }
                this.Nodes.Add(LoteNode);
            }
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoteTreeView));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "images (7).jpg");
            this.imageList1.Images.SetKeyName(1, "images (4).jpg");
            this.imageList1.Images.SetKeyName(2, "images (4)2.jpg");
            // 
            // LoteTreeView
            // 
            this.AllowDrop = true;
            this.ImageIndex = 0;
            this.ImageList = this.imageList1;
            this.LineColor = System.Drawing.Color.Black;
            this.SelectedImageIndex = 1;
            this.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.LoteTreeView_NodeMouseClick);
            this.ResumeLayout(false);

        }
        public Core.Data.Planta Planta {
            get { return _planta; }
            set { _planta = value; }
        }
        private void LoteTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 2)
            {
                if (this._planta != null)
                {
                    this._planta.Id = e.Node.Name;
                    this._planta.Codigo = e.Node.Text;
                    this.Planta = _planta;
                }
                else {
                    this._planta = new Core.Data.Planta();
                    this._planta.Id = e.Node.Name;
                    this._planta.Codigo = e.Node.Text;
                    this.Planta = _planta;
                }             
            }
            else {
                this._planta = null;
            }
            //MessageBox.Show("Lote: " + e.Node.Name + "Planta: " + e.Node.Text + "level: " +  e.Node.Level.ToString() );
        }
    }
}