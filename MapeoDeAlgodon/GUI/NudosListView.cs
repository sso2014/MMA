using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    class NudosListView:System.Windows.Forms.ListView
    {
        public NudosListView()
        {
            InitializeComponent();
        }
        private System.ComponentModel.IContainer components;
    
        public Core.Data.Nudo DataSouce
        {
            set{

                Core.Data.Nudo n = value;

                this.Items.Clear();

                if (n.Estado != null)
                {

                    foreach (Core.Data.State s in n.Estado)
                    {
                        this.Items.Add(new ListViewItem(new string[]
                { 
                    s.Fecha.ToShortDateString(), s.Descripcion
                }, 0));
                    }
                }

             }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
