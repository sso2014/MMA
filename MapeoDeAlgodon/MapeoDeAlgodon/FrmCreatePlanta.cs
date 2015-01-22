using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core.Data;

namespace MapeoDeAlgodon
{
    public partial class FrmCreatePlanta : Form
    {
        public FrmCreatePlanta()
        {
            InitializeComponent();
        }
        public Planta Planta
        {
            get;
            set;
        }
        public object DataSouce {

            set {
                comboBox2.DataSource = value as List<Core.Data.Lote>;
            }
        }
        private void FrmCreatePlanta_Load(object sender, EventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Lote l = this.comboBox2.SelectedItem as Lote;
            Planta planta = new Planta()
            {
                Codigo = this.textBox1.Text,
                LoteID = l.LoteID
            };

            this.Planta = planta;
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}