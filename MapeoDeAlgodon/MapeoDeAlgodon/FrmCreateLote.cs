using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapeoDeAlgodon
{
    public partial class FrmCreateLote : Form
    {
        public FrmCreateLote()
        {
            InitializeComponent();
        }
        private Core.Data.Lote lote = new Core.Data.Lote();

        public Core.Data.Lote Lote
        {
            get;
            set;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            lote = new Core.Data.Lote()
            {
                Nombre = this.textBox1.Text,
                CampoId = "2"
            };
            this.Lote = lote;
        }
    }
}
