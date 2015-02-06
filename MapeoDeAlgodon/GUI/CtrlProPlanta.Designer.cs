namespace GUI
{
    partial class CtrlProPlanta
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PlantaDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.NudosVegetativosLabel = new System.Windows.Forms.Label();
            this.NudoReproductivosLabel = new System.Windows.Forms.Label();
            this.PlantaLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LoteLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.PlantaDateTimePicker1);
            this.groupBox1.Controls.Add(this.NudosVegetativosLabel);
            this.groupBox1.Controls.Add(this.NudoReproductivosLabel);
            this.groupBox1.Controls.Add(this.PlantaLabel);
            this.groupBox1.Location = new System.Drawing.Point(14, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 173);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Fecha:";
            // 
            // PlantaDateTimePicker1
            // 
            this.PlantaDateTimePicker1.Location = new System.Drawing.Point(64, 26);
            this.PlantaDateTimePicker1.Name = "PlantaDateTimePicker1";
            this.PlantaDateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.PlantaDateTimePicker1.TabIndex = 6;
            // 
            // NudosVegetativosLabel
            // 
            this.NudosVegetativosLabel.AutoSize = true;
            this.NudosVegetativosLabel.Location = new System.Drawing.Point(9, 132);
            this.NudosVegetativosLabel.Name = "NudosVegetativosLabel";
            this.NudosVegetativosLabel.Size = new System.Drawing.Size(99, 13);
            this.NudosVegetativosLabel.TabIndex = 5;
            this.NudosVegetativosLabel.Text = "Nudos vegetativos:";
            // 
            // NudoReproductivosLabel
            // 
            this.NudoReproductivosLabel.AutoSize = true;
            this.NudoReproductivosLabel.Location = new System.Drawing.Point(9, 102);
            this.NudoReproductivosLabel.Name = "NudoReproductivosLabel";
            this.NudoReproductivosLabel.Size = new System.Drawing.Size(108, 13);
            this.NudoReproductivosLabel.TabIndex = 4;
            this.NudoReproductivosLabel.Text = "Nudos reproductivos:";
            // 
            // PlantaLabel
            // 
            this.PlantaLabel.AutoSize = true;
            this.PlantaLabel.Location = new System.Drawing.Point(9, 63);
            this.PlantaLabel.Name = "PlantaLabel";
            this.PlantaLabel.Size = new System.Drawing.Size(40, 13);
            this.PlantaLabel.TabIndex = 3;
            this.PlantaLabel.Text = "Planta:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LoteLabel);
            this.groupBox2.Location = new System.Drawing.Point(14, 194);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 101);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // LoteLabel
            // 
            this.LoteLabel.AutoSize = true;
            this.LoteLabel.Location = new System.Drawing.Point(9, 20);
            this.LoteLabel.Name = "LoteLabel";
            this.LoteLabel.Size = new System.Drawing.Size(31, 13);
            this.LoteLabel.TabIndex = 0;
            this.LoteLabel.Text = "Lote:";
            // 
            // CtrlProPlanta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CtrlProPlanta";
            this.Size = new System.Drawing.Size(310, 313);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label NudosVegetativosLabel;
        private System.Windows.Forms.Label NudoReproductivosLabel;
        private System.Windows.Forms.Label PlantaLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LoteLabel;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker PlantaDateTimePicker1;
    }
}
