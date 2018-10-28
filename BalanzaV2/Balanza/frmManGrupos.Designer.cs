namespace Balanza
{
    partial class frmManGrupos
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
            this.lblGrupo = new System.Windows.Forms.Label();
            this.cmbGrupo = new System.Windows.Forms.ComboBox();
            this.cbSelGrupo = new System.Windows.Forms.CheckBox();
            this.cbActivo = new System.Windows.Forms.CheckBox();
            this.dgvDetalleGrupo = new System.Windows.Forms.DataGridView();
            this.CODGRUPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALOR_DEFECTO = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ESTADO = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grabarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleGrupo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(13, 34);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(39, 13);
            this.lblGrupo.TabIndex = 0;
            this.lblGrupo.Text = "Grupo:";
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.FormattingEnabled = true;
            this.cmbGrupo.Location = new System.Drawing.Point(58, 31);
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.Size = new System.Drawing.Size(200, 21);
            this.cmbGrupo.TabIndex = 1;
            this.cmbGrupo.SelectedIndexChanged += new System.EventHandler(this.cmbGrupo_SelectedIndexChanged);
            // 
            // cbSelGrupo
            // 
            this.cbSelGrupo.AutoSize = true;
            this.cbSelGrupo.Location = new System.Drawing.Point(264, 33);
            this.cbSelGrupo.Name = "cbSelGrupo";
            this.cbSelGrupo.Size = new System.Drawing.Size(114, 17);
            this.cbSelGrupo.TabIndex = 2;
            this.cbSelGrupo.Text = "Es Seleccionable?";
            this.cbSelGrupo.UseVisualStyleBackColor = true;
            // 
            // cbActivo
            // 
            this.cbActivo.AutoSize = true;
            this.cbActivo.Location = new System.Drawing.Point(384, 34);
            this.cbActivo.Name = "cbActivo";
            this.cbActivo.Size = new System.Drawing.Size(62, 17);
            this.cbActivo.TabIndex = 3;
            this.cbActivo.Text = "Activo?";
            this.cbActivo.UseVisualStyleBackColor = true;
            // 
            // dgvDetalleGrupo
            // 
            this.dgvDetalleGrupo.AllowUserToAddRows = false;
            this.dgvDetalleGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleGrupo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODGRUPO,
            this.VALOR,
            this.VALOR_DEFECTO,
            this.ESTADO});
            this.dgvDetalleGrupo.Location = new System.Drawing.Point(13, 58);
            this.dgvDetalleGrupo.Name = "dgvDetalleGrupo";
            this.dgvDetalleGrupo.Size = new System.Drawing.Size(392, 106);
            this.dgvDetalleGrupo.TabIndex = 4;
            this.dgvDetalleGrupo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleGrupo_CellContentClick);
            // 
            // CODGRUPO
            // 
            this.CODGRUPO.HeaderText = "Grupo";
            this.CODGRUPO.Name = "CODGRUPO";
            this.CODGRUPO.Visible = false;
            // 
            // VALOR
            // 
            this.VALOR.FillWeight = 130F;
            this.VALOR.HeaderText = "Valor";
            this.VALOR.Name = "VALOR";
            this.VALOR.Width = 130;
            // 
            // VALOR_DEFECTO
            // 
            this.VALOR_DEFECTO.HeaderText = "Val. por defecto?";
            this.VALOR_DEFECTO.Name = "VALOR_DEFECTO";
            this.VALOR_DEFECTO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VALOR_DEFECTO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ESTADO
            // 
            this.ESTADO.HeaderText = "Activo?";
            this.ESTADO.Name = "ESTADO";
            this.ESTADO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ESTADO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(449, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grabarToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // grabarToolStripMenuItem
            // 
            this.grabarToolStripMenuItem.Name = "grabarToolStripMenuItem";
            this.grabarToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.grabarToolStripMenuItem.Text = "Grabar";
            this.grabarToolStripMenuItem.Click += new System.EventHandler(this.grabarToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(106, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(411, 58);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(25, 23);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = " + ";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(411, 87);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(25, 23);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = " - ";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmManGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 170);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvDetalleGrupo);
            this.Controls.Add(this.cbActivo);
            this.Controls.Add(this.cbSelGrupo);
            this.Controls.Add(this.cmbGrupo);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.Name = "frmManGrupos";
            this.Text = "frmManGrupos";
            this.Load += new System.EventHandler(this.frmManGrupos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleGrupo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.ComboBox cmbGrupo;
        private System.Windows.Forms.CheckBox cbSelGrupo;
        private System.Windows.Forms.CheckBox cbActivo;
        private System.Windows.Forms.DataGridView dgvDetalleGrupo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grabarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODGRUPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALOR;
        private System.Windows.Forms.DataGridViewCheckBoxColumn VALOR_DEFECTO;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ESTADO;
    }
}