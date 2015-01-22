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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private Usuario usuario=null;
        public Usuario Usuario {
            get {
                
                return usuario;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            usuario = new Usuario();
            usuario.Nombre = textBox1.Text;
            usuario.Pasword = textBox2.Text;
        }
    }
}
