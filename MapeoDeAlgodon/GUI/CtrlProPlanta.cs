using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class CtrlProPlanta : UserControl
    {
        public CtrlProPlanta()
        {
            InitializeComponent();
        }
        public string PlantaName {
            set
            {
                this.PlantaLabel.Text = value;
            }
        }
        public DateTime Fecha {
            get {
                return this.PlantaDateTimePicker1.Value;
            }
        }
    }
}
