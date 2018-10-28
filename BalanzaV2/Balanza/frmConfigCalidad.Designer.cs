namespace Balanza
{
    partial class frmConfigCalidad
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
            this.lblTipGra = new System.Windows.Forms.Label();
            this.cmbTipGra = new System.Windows.Forms.ComboBox();
            this.gbParametros = new System.Windows.Forms.GroupBox();
            this.dgvConfigCalidad = new System.Windows.Forms.DataGridView();
            this.ID_CAMPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LABEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.COD_GRUPO = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.OBLIGATORIO = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ESTADO = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IMPRESION = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LABEL_ETIQUETA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grabarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gbParametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigCalidad)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTipGra
            // 
            this.lblTipGra.AutoSize = true;
            this.lblTipGra.Location = new System.Drawing.Point(7, 29);
            this.lblTipGra.Name = "lblTipGra";
            this.lblTipGra.Size = new System.Drawing.Size(78, 13);
            this.lblTipGra.TabIndex = 0;
            this.lblTipGra.Text = "Tipo de Grano:";
            // 
            // cmbTipGra
            // 
            this.cmbTipGra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipGra.FormattingEnabled = true;
            this.cmbTipGra.Location = new System.Drawing.Point(91, 26);
            this.cmbTipGra.Name = "cmbTipGra";
            this.cmbTipGra.Size = new System.Drawing.Size(192, 21);
            this.cmbTipGra.TabIndex = 1;
            this.cmbTipGra.SelectedIndexChanged += new System.EventHandler(this.cmbTipGra_SelectedIndexChanged);
            // 
            // gbParametros
            // 
            this.gbParametros.Controls.Add(this.dgvConfigCalidad);
            this.gbParametros.Location = new System.Drawing.Point(10, 53);
            this.gbParametros.Name = "gbParametros";
            this.gbParametros.Size = new System.Drawing.Size(757, 286);
            this.gbParametros.TabIndex = 2;
            this.gbParametros.TabStop = false;
            this.gbParametros.Text = "Configuraciones";
            // 
            // dgvConfigCalidad
            // 
            this.dgvConfigCalidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConfigCalidad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_CAMPO,
            this.LABEL,
            this.TIPO,
            this.COD_GRUPO,
            this.OBLIGATORIO,
            this.ESTADO,
            this.IMPRESION,
            this.LABEL_ETIQUETA});
            this.dgvConfigCalidad.Location = new System.Drawing.Point(7, 20);
            this.dgvConfigCalidad.Name = "dgvConfigCalidad";
            this.dgvConfigCalidad.Size = new System.Drawing.Size(744, 258);
            this.dgvConfigCalidad.TabIndex = 0;
            this.dgvConfigCalidad.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvConfigCalidad_CellBeginEdit);
            this.dgvConfigCalidad.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConfigCalidad_CellContentClick);
            this.dgvConfigCalidad.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConfigCalidad_CellEndEdit);
            this.dgvConfigCalidad.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvConfigCalidad_RowsAdded);
            // 
            // ID_CAMPO
            // 
            this.ID_CAMPO.HeaderText = "ID";
            this.ID_CAMPO.Name = "ID_CAMPO";
            this.ID_CAMPO.ReadOnly = true;
            this.ID_CAMPO.Width = 30;
            // 
            // LABEL
            // 
            this.LABEL.HeaderText = "Etiqueta";
            this.LABEL.Name = "LABEL";
            this.LABEL.Width = 120;
            // 
            // TIPO
            // 
            this.TIPO.HeaderText = "Tipo";
            this.TIPO.Name = "TIPO";
            this.TIPO.Width = 130;
            // 
            // COD_GRUPO
            // 
            this.COD_GRUPO.HeaderText = "Opciones";
            this.COD_GRUPO.Name = "COD_GRUPO";
            this.COD_GRUPO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COD_GRUPO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.COD_GRUPO.Width = 130;
            // 
            // OBLIGATORIO
            // 
            this.OBLIGATORIO.HeaderText = "Oblig.?";
            this.OBLIGATORIO.Name = "OBLIGATORIO";
            this.OBLIGATORIO.Width = 50;
            // 
            // ESTADO
            // 
            this.ESTADO.HeaderText = "Activo?";
            this.ESTADO.Name = "ESTADO";
            this.ESTADO.Width = 50;
            // 
            // IMPRESION
            // 
            this.IMPRESION.HeaderText = "Impresion?";
            this.IMPRESION.Name = "IMPRESION";
            this.IMPRESION.Width = 65;
            // 
            // LABEL_ETIQUETA
            // 
            this.LABEL_ETIQUETA.HeaderText = "Etiqueta Impresion";
            this.LABEL_ETIQUETA.MaxInputLength = 5;
            this.LABEL_ETIQUETA.Name = "LABEL_ETIQUETA";
            this.LABEL_ETIQUETA.Width = 120;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(821, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grabarToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // grabarToolStripMenuItem
            // 
            this.grabarToolStripMenuItem.Name = "grabarToolStripMenuItem";
            this.grabarToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.grabarToolStripMenuItem.Text = "Grabar";
            this.grabarToolStripMenuItem.Click += new System.EventHandler(this.grabarToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(773, 102);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(25, 23);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = " - ";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(773, 73);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(25, 23);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = " + ";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // frmConfigCalidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 343);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.gbParametros);
            this.Controls.Add(this.cmbTipGra);
            this.Controls.Add(this.lblTipGra);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmConfigCalidad";
            this.Text = "Mant. de Config. Calidad";
            this.Load += new System.EventHandler(this.frmConfigCalidad_Load);
            this.gbParametros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigCalidad)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTipGra;
        private System.Windows.Forms.ComboBox cmbTipGra;
        private System.Windows.Forms.GroupBox gbParametros;
        private System.Windows.Forms.DataGridView dgvConfigCalidad;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grabarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_CAMPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn LABEL;
        private System.Windows.Forms.DataGridViewComboBoxColumn TIPO;
        private System.Windows.Forms.DataGridViewComboBoxColumn COD_GRUPO;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OBLIGATORIO;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ESTADO;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IMPRESION;
        private System.Windows.Forms.DataGridViewTextBoxColumn LABEL_ETIQUETA;
    }
}