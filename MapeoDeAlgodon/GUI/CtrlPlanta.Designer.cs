namespace GUI
{
    partial class CtrlPlanta
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aAbortoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pPrimordioFlorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fFlorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vBochaVerdeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bBochaMaduraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cCapulloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pdPodridasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dpDañoPicudoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aAbortoToolStripMenuItem,
            this.pPrimordioFlorToolStripMenuItem,
            this.fFlorToolStripMenuItem,
            this.vBochaVerdeToolStripMenuItem,
            this.bBochaMaduraToolStripMenuItem,
            this.cCapulloToolStripMenuItem,
            this.pdPodridasToolStripMenuItem,
            this.dpDañoPicudoToolStripMenuItem,
            this.toolStripSeparator1,
            this.eliminarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 208);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // aAbortoToolStripMenuItem
            // 
            this.aAbortoToolStripMenuItem.Name = "aAbortoToolStripMenuItem";
            this.aAbortoToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.aAbortoToolStripMenuItem.Text = "A = Aborto";
            // 
            // pPrimordioFlorToolStripMenuItem
            // 
            this.pPrimordioFlorToolStripMenuItem.Name = "pPrimordioFlorToolStripMenuItem";
            this.pPrimordioFlorToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.pPrimordioFlorToolStripMenuItem.Text = "P = Primordio Flor";
            // 
            // fFlorToolStripMenuItem
            // 
            this.fFlorToolStripMenuItem.Name = "fFlorToolStripMenuItem";
            this.fFlorToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.fFlorToolStripMenuItem.Text = "F = Flor";
            // 
            // vBochaVerdeToolStripMenuItem
            // 
            this.vBochaVerdeToolStripMenuItem.Name = "vBochaVerdeToolStripMenuItem";
            this.vBochaVerdeToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.vBochaVerdeToolStripMenuItem.Text = "V = Bocha Verde";
            // 
            // bBochaMaduraToolStripMenuItem
            // 
            this.bBochaMaduraToolStripMenuItem.Name = "bBochaMaduraToolStripMenuItem";
            this.bBochaMaduraToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.bBochaMaduraToolStripMenuItem.Text = "B = Bocha Madura";
            // 
            // cCapulloToolStripMenuItem
            // 
            this.cCapulloToolStripMenuItem.Name = "cCapulloToolStripMenuItem";
            this.cCapulloToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.cCapulloToolStripMenuItem.Text = "C = Capullo";
            // 
            // pdPodridasToolStripMenuItem
            // 
            this.pdPodridasToolStripMenuItem.Name = "pdPodridasToolStripMenuItem";
            this.pdPodridasToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.pdPodridasToolStripMenuItem.Text = "Pd= Podridas";
            // 
            // dpDañoPicudoToolStripMenuItem
            // 
            this.dpDañoPicudoToolStripMenuItem.Name = "dpDañoPicudoToolStripMenuItem";
            this.dpDañoPicudoToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.dpDañoPicudoToolStripMenuItem.Text = "Dp=Daño Picudo";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.eliminarToolStripMenuItem.Text = "Dp=Daño Picudo";
            // 
            // CtrlPlanta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GUI.Properties.Resources.Grid4;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Name = "CtrlPlanta";
            this.Size = new System.Drawing.Size(582, 474);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CtrlPlanta_MouseMove);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem aAbortoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pPrimordioFlorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fFlorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vBochaVerdeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bBochaMaduraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cCapulloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pdPodridasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dpDañoPicudoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
