using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmCreateLote : Form
    {
        public FrmCreateLote()
        {
            InitializeComponent();
        }

        private Core.Data.Lote _lote = null;

        public Core.Data.Lote Lote {
            get { return _lote; }
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
         

            if (comboBox1.Text == "DON PANOS")
            {
                this._lote = new Core.Data.Lote();
                this._lote.CampoId = "2";
                this._lote.LoteID = "0";
                this._lote.Nombre = textBox1.Text;
                this._lote.Plantas = null;

            }
            else if (comboBox1.Text == "LA SURPINA")
            {
                this._lote = new Core.Data.Lote();
                this._lote.CampoId = "1";
                this._lote.LoteID = "0";
                this._lote.Nombre = textBox1.Text;
                this._lote.Plantas = null;
                
            }
            else {
                MessageBox.Show("El nombre del campo seleccionado no existe");
            }
        }
        private void FrmCreateLote_Load(object sender, EventArgs e)
        {

        }

   
    }
}
