namespace Balanza
{
    partial class frmConfigBalanza
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvTablaBalanza = new System.Windows.Forms.DataGridView();
            this.COD_BALANZA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TAM_TRAMA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAR_INI_TRA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAR_EST_BAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POS_INI_CEB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POS_FIN_CEB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POS_INI_PESO_ST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POS_FIN_PESO_ST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POS_INI_PESO_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POS_FIN_PESO_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTADO = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BAL_DEFAULT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.POS_DEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaBalanza)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(772, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // dgvTablaBalanza
            // 
            this.dgvTablaBalanza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablaBalanza.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COD_BALANZA,
            this.TAM_TRAMA,
            this.CAR_INI_TRA,
            this.CAR_EST_BAL,
            this.POS_INI_CEB,
            this.POS_FIN_CEB,
            this.POS_INI_PESO_ST,
            this.POS_FIN_PESO_ST,
            this.POS_INI_PESO_CT,
            this.POS_FIN_PESO_CT,
            this.ESTADO,
            this.BAL_DEFAULT,
            this.POS_DEC});
            this.dgvTablaBalanza.Location = new System.Drawing.Point(12, 26);
            this.dgvTablaBalanza.Name = "dgvTablaBalanza";
            this.dgvTablaBalanza.Size = new System.Drawing.Size(749, 150);
            this.dgvTablaBalanza.TabIndex = 1;
            this.dgvTablaBalanza.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTablaBalanza_CellContentClick);
            this.dgvTablaBalanza.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvTablaBalanza_EditingControlShowing);
            // 
            // COD_BALANZA
            // 
            this.COD_BALANZA.HeaderText = "Balanza";
            this.COD_BALANZA.Name = "COD_BALANZA";
            this.COD_BALANZA.ReadOnly = true;
            // 
            // TAM_TRAMA
            // 
            this.TAM_TRAMA.HeaderText = "Tam. Trama";
            this.TAM_TRAMA.Name = "TAM_TRAMA";
            // 
            // CAR_INI_TRA
            // 
            this.CAR_INI_TRA.HeaderText = "Pos. Ini. Trama";
            this.CAR_INI_TRA.Name = "CAR_INI_TRA";
            // 
            // CAR_EST_BAL
            // 
            this.CAR_EST_BAL.HeaderText = "Car. Estable";
            this.CAR_EST_BAL.Name = "CAR_EST_BAL";
            // 
            // POS_INI_CEB
            // 
            this.POS_INI_CEB.HeaderText = "Inicio de Car. Est.";
            this.POS_INI_CEB.Name = "POS_INI_CEB";
            // 
            // POS_FIN_CEB
            // 
            this.POS_FIN_CEB.HeaderText = "Fin de Car. Est.";
            this.POS_FIN_CEB.Name = "POS_FIN_CEB";
            // 
            // POS_INI_PESO_ST
            // 
            this.POS_INI_PESO_ST.HeaderText = "Inicio Peso Bruto";
            this.POS_INI_PESO_ST.Name = "POS_INI_PESO_ST";
            // 
            // POS_FIN_PESO_ST
            // 
            this.POS_FIN_PESO_ST.HeaderText = "Fin Peso Bruto";
            this.POS_FIN_PESO_ST.Name = "POS_FIN_PESO_ST";
            // 
            // POS_INI_PESO_CT
            // 
            this.POS_INI_PESO_CT.HeaderText = "Inicio Peso Neto";
            this.POS_INI_PESO_CT.Name = "POS_INI_PESO_CT";
            // 
            // POS_FIN_PESO_CT
            // 
            this.POS_FIN_PESO_CT.HeaderText = "Fin Peso Neto";
            this.POS_FIN_PESO_CT.Name = "POS_FIN_PESO_CT";
            // 
            // ESTADO
            // 
            this.ESTADO.HeaderText = "Activo";
            this.ESTADO.Name = "ESTADO";
            this.ESTADO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // BAL_DEFAULT
            // 
            this.BAL_DEFAULT.HeaderText = "Bal. por defecto?";
            this.BAL_DEFAULT.Name = "BAL_DEFAULT";
            // 
            // POS_DEC
            // 
            this.POS_DEC.HeaderText = "Pos. Decimal";
            this.POS_DEC.MaxInputLength = 1;
            this.POS_DEC.Name = "POS_DEC";
            // 
            // frmConfigBalanza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 188);
            this.Controls.Add(this.dgvTablaBalanza);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmConfigBalanza";
            this.Text = "frmConfigBalanza";
            this.Load += new System.EventHandler(this.frmConfigBalanza_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaBalanza)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvTablaBalanza;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_BALANZA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TAM_TRAMA;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAR_INI_TRA;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAR_EST_BAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn POS_INI_CEB;
        private System.Windows.Forms.DataGridViewTextBoxColumn POS_FIN_CEB;
        private System.Windows.Forms.DataGridViewTextBoxColumn POS_INI_PESO_ST;
        private System.Windows.Forms.DataGridViewTextBoxColumn POS_FIN_PESO_ST;
        private System.Windows.Forms.DataGridViewTextBoxColumn POS_INI_PESO_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn POS_FIN_PESO_CT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ESTADO;
        private System.Windows.Forms.DataGridViewCheckBoxColumn BAL_DEFAULT;
        private System.Windows.Forms.DataGridViewTextBoxColumn POS_DEC;
    }
}