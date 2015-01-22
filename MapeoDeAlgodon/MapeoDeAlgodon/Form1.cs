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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Nudo ng;

        private void Form1_Load(object sender, EventArgs e)        {

        }
        private void label2_Click(object sender, EventArgs e)      {

        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text.Substring(0,2)) { 
                case "A ":
                    ng.BackColor = panel2.BackColor;
                    break;
                case "P ":
                    ng.BackColor = panel3.BackColor;
                    break;
                case "F ":
                    ng.BackColor = panel4.BackColor;
                    break;
                case "V ":
                    ng.BackColor = panel5.BackColor;
                    break;
                case "B ":
                    ng.BackColor = panel6.BackColor;
                    break;
                case "C ":
                    ng.BackColor = panel7.BackColor;
                    break;
                case "Pd":
                    ng.BackColor = panel8.BackColor;
                    break;
                case "Dp":
                    ng.BackColor = panel9.BackColor;
                    break;
                case "Bv":
                    ng.BackColor = panel10.BackColor;
                    break;
                case "Bm":
                    ng.BackColor = panel11.BackColor;
                    break;

            }
        }
        private void nudoReproductivo10_Enter(object sender, EventArgs e)
        {
           ng = (Nudo)sender;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
