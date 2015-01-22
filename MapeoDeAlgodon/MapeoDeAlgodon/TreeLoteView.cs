using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapeoDeAlgodon
{
    class TreeLoteView : System.Windows.Forms.TreeView
    {

        public TreeLoteView()
        {
            InitializeComponent();
        }
        private void BindControls()
        {

        }


        private IList<Core.Data.Lote> lotes = null;

        private List<Core.Data.Planta> Plantas { get; set; }
        public void Add(IList<Core.Data.Lote> lotes)
        {

            this.lotes = lotes;

            this.Nodes.Clear();

            foreach (Core.Data.Lote l in lotes)
            {
                this.Nodes.Add(l.LoteID, l.Nombre);//new TreeNode(l.Nombre));
            
                foreach (TreeNode nodo in this.Nodes)
                {
                    if (nodo.Text == l.Nombre)
                    {
                        foreach (Core.Data.Planta p in l.Plantas)
                        {
                            nodo.Nodes.Add(p.Id, p.Codigo, 0);
                        }
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TreeLoteView
            // 
            this.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeLoteView_AfterSelect);
            this.ResumeLayout(false);

        }

        private void TreeLoteView_AfterSelect(object sender, TreeViewEventArgs e)
        {
           TreeNode tn =  e.Node.NextNode;

           if (tn  != null)
           {
                TreeNode tc = tn.NextNode;
           }
        }
    }
}