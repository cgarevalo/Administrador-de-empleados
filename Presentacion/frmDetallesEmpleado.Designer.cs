namespace Presentacion
{
    partial class frmDetallesEmpleado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDetallesEmpleado = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pboImagenEmpleado = new System.Windows.Forms.PictureBox();
            this.Propiedades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesEmpleado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboImagenEmpleado)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetallesEmpleado
            // 
            this.dgvDetallesEmpleado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDetallesEmpleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallesEmpleado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Propiedades,
            this.Valor});
            this.dgvDetallesEmpleado.Location = new System.Drawing.Point(12, 12);
            this.dgvDetallesEmpleado.MultiSelect = false;
            this.dgvDetallesEmpleado.Name = "dgvDetallesEmpleado";
            this.dgvDetallesEmpleado.Size = new System.Drawing.Size(318, 181);
            this.dgvDetallesEmpleado.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(12, 251);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pboImagenEmpleado
            // 
            this.pboImagenEmpleado.Location = new System.Drawing.Point(336, 12);
            this.pboImagenEmpleado.Name = "pboImagenEmpleado";
            this.pboImagenEmpleado.Size = new System.Drawing.Size(149, 181);
            this.pboImagenEmpleado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboImagenEmpleado.TabIndex = 2;
            this.pboImagenEmpleado.TabStop = false;
            // 
            // Propiedades
            // 
            this.Propiedades.HeaderText = "Propiedades";
            this.Propiedades.Name = "Propiedades";
            this.Propiedades.Width = 91;
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.Width = 56;
            // 
            // frmDetallesEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 286);
            this.Controls.Add(this.pboImagenEmpleado);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvDetallesEmpleado);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(513, 325);
            this.MinimumSize = new System.Drawing.Size(513, 325);
            this.Name = "frmDetallesEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Información del empleado";
            this.Load += new System.EventHandler(this.frmDetallesEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesEmpleado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboImagenEmpleado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetallesEmpleado;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox pboImagenEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Propiedades;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
    }
}