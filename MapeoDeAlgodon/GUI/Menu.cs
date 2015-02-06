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
    public partial class Menu : Form,IView
    {
        public Menu()
        {
            InitializeComponent();
            this.BindControls();
        }       
        private void BindControls() {
            this.CampoComboBox.SelectedIndexChanged += OnSelectedCampo;
            this.loteTreeView1.NodeMouseClick += OnSelectedPlanta;
            this.ctrlPlanta1.SelectedNudoEvent += OnSelectedNudo;
            this.ctrlPlanta1.ContextMenuStrip.ItemClicked += OnCreatedNudo;
            this._frmCreateLote.AceptarButton.Click += OnCreateLote;
        }
        private FrmCreateLote _frmCreateLote = new FrmCreateLote();
        #region Interface view
        public void LoadCampos(List<Core.Data.Campo> campos)
        {
            CampoComboBox.DataSource = campos;
        }
        public void LoadCampo(Core.Data.Campo campo)
        {
            throw new NotImplementedException();
        }
        public void LoadLotes(List<Core.Data.Lote> lotes)
        {          
                loteTreeView1.Nodes.Clear();
                loteTreeView1.DataSouce = lotes;         
        }
        public void LoadLote(Core.Data.Lote lote)
        {
            throw new NotImplementedException();
        }
        public void LoadPlantas(List<Core.Data.Planta> plantas)
        {
            throw new NotImplementedException();
        }
        public void LoadPlanta(Core.Data.Planta planta)
        {
            if (planta != null)
            {
                ctrlPlanta1.DataSouce = planta;
                ctrlProPlanta1.PlantaName = "Planta: " + planta.Codigo;
            }
        }
        public void LoadNudos(List<Core.Data.Nudo> nudos)
        {
            throw new NotImplementedException();
        }
        public void LoadNudo(Core.Data.Nudo nudo)
        {
            this.nudosListView1.DataSouce = nudo;
        }
        public void LoadStates(List<Core.Data.State> states)
        {
        }
        public void LoadSatate(Core.Data.Nudo state)
        {
            throw new NotImplementedException();
        }
        public Core.Data.Campo SelectedCampo
        {
            get { return CampoComboBox.SelectedItem as Core.Data.Campo; }
        }

        public Core.Data.Lote SelectedLote
        {
            get { return _frmCreateLote.Lote; }
        }

        public Core.Data.Planta SelectedPlanta
        {
            get { return this.loteTreeView1.Planta; }
        }

        public Core.Data.Nudo SelectedNudo
        {
            get { return this.ctrlPlanta1.SelectedNudo; }
        }

        public Core.Data.State SelectedState
        {
            get { throw new NotImplementedException(); }
        }

        #region Action
        public event Action CampoSelected;
        public event Action LoteSelected;
        public event Action PlantaSelected;
        public event Action NudoSelected;
        public event Action StateSelected;
        public event Action NudoCreated;
        public event Action Actualizar;
        public event Action LoteCreated;
        #endregion
        #endregion
        private void OnSelectedPlanta(object sender, EventArgs e)
        {
            if (this.PlantaSelected != null)
            {
                this.PlantaSelected();
            }
        }
        private void OnCreateLote(object sender, EventArgs  e)
        {
            if (this.LoteCreated != null)
            {
                this.LoteCreated();
            }
        }

        private void OnCreatedNudo(object sender, EventArgs e)
        {
            if (this.NudoCreated != null)
            {
                this.NudoCreated();   
            }
        }
        private void OnSelectedCampo(object sender, EventArgs e)
        {
            if (this.CampoSelected != null)
            {
                this.CampoSelected();
            }
        }
        private void OnSelectedNudo(object sender, EventArgs e)
        {
            if (this.NudoSelected != null)
            {
                this.NudoSelected();
            }
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.ctrlProPlanta1.PlantaDateTimePicker1.ValueChanged += PlantaDateTimePicker1_ValueChanged;
            this.ctrlPlanta1.fecha = this.ctrlProPlanta1.Fecha;
        }

        void PlantaDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.ctrlPlanta1.fecha = this.ctrlProPlanta1.Fecha;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (this.Actualizar != null)
            {
                this.Actualizar();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _frmCreateLote.ShowDialog();
        }
    }
}
