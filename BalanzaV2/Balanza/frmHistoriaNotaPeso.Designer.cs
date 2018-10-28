namespace Balanza
{
    partial class frmHistoriaNotaPeso
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
            this.menuStripOpc = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvHistoriaNotaPeso = new System.Windows.Forms.DataGridView();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.lbFecIni = new System.Windows.Forms.Label();
            this.lbFecFin = new System.Windows.Forms.Label();
            this.dtFin = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblIDNota = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.menuStripOpc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoriaNotaPeso)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripOpc
            // 
            this.menuStripOpc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStripOpc.Location = new System.Drawing.Point(0, 0);
            this.menuStripOpc.Name = "menuStripOpc";
            this.menuStripOpc.Size = new System.Drawing.Size(667, 24);
            this.menuStripOpc.TabIndex = 0;
            this.menuStripOpc.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.buscarTodoToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.imprimirToolStripMenuItem.Text = "Imprimir";
            this.imprimirToolStripMenuItem.Click += new System.EventHandler(this.imprimirToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // buscarTodoToolStripMenuItem
            // 
            this.buscarTodoToolStripMenuItem.Name = "buscarTodoToolStripMenuItem";
            this.buscarTodoToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.buscarTodoToolStripMenuItem.Text = "Buscar todo";
            this.buscarTodoToolStripMenuItem.Click += new System.EventHandler(this.buscarTodoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(134, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // dgvHistoriaNotaPeso
            // 
            this.dgvHistoriaNotaPeso.AllowUserToAddRows = false;
            this.dgvHistoriaNotaPeso.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHistoriaNotaPeso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoriaNotaPeso.Location = new System.Drawing.Point(12, 57);
            this.dgvHistoriaNotaPeso.Name = "dgvHistoriaNotaPeso";
            this.dgvHistoriaNotaPeso.RowHeadersWidth = 20;
            this.dgvHistoriaNotaPeso.Size = new System.Drawing.Size(642, 259);
            this.dgvHistoriaNotaPeso.TabIndex = 1;
            this.dgvHistoriaNotaPeso.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistoriaNotaPeso_CellContentClick);
            this.dgvHistoriaNotaPeso.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistoriaNotaPeso_CellContentDoubleClick);
            // 
            // dtInicio
            // 
            this.dtInicio.CustomFormat = "";
            this.dtInicio.Location = new System.Drawing.Point(104, 31);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(99, 20);
            this.dtInicio.TabIndex = 2;
            // 
            // lbFecIni
            // 
            this.lbFecIni.AutoSize = true;
            this.lbFecIni.Location = new System.Drawing.Point(31, 34);
            this.lbFecIni.Name = "lbFecIni";
            this.lbFecIni.Size = new System.Drawing.Size(67, 13);
            this.lbFecIni.TabIndex = 3;
            this.lbFecIni.Text = "Fecha inicio:";
            // 
            // lbFecFin
            // 
            this.lbFecFin.AutoSize = true;
            this.lbFecFin.Location = new System.Drawing.Point(218, 34);
            this.lbFecFin.Name = "lbFecFin";
            this.lbFecFin.Size = new System.Drawing.Size(57, 13);
            this.lbFecFin.TabIndex = 4;
            this.lbFecFin.Text = "Fecha Fin:";
            // 
            // dtFin
            // 
            this.dtFin.CustomFormat = "";
            this.dtFin.Location = new System.Drawing.Point(281, 31);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(99, 20);
            this.dtFin.TabIndex = 5;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(566, 29);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(67, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblIDNota
            // 
            this.lblIDNota.AutoSize = true;
            this.lblIDNota.Location = new System.Drawing.Point(406, 33);
            this.lblIDNota.Name = "lblIDNota";
            this.lblIDNota.Size = new System.Drawing.Size(47, 13);
            this.lblIDNota.TabIndex = 7;
            this.lblIDNota.Text = "ID Nota:";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(460, 30);
            this.tbID.MaxLength = 6;
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(83, 20);
            this.tbID.TabIndex = 8;
            this.tbID.TextChanged += new System.EventHandler(this.tbID_TextChanged);
            this.tbID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbID_KeyPress);
            // 
            // frmHistoriaNotaPeso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 328);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.lblIDNota);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtFin);
            this.Controls.Add(this.lbFecFin);
            this.Controls.Add(this.lbFecIni);
            this.Controls.Add(this.dtInicio);
            this.Controls.Add(this.dgvHistoriaNotaPeso);
            this.Controls.Add(this.menuStripOpc);
            this.MainMenuStrip = this.menuStripOpc;
            this.Name = "frmHistoriaNotaPeso";
            this.Text = "frmHistoriaNotaPeso";
            this.Load += new System.EventHandler(this.frmHistoriaNotaPeso_Load);
            this.menuStripOpc.ResumeLayout(false);
            this.menuStripOpc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoriaNotaPeso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripOpc;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvHistoriaNotaPeso;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarTodoToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.Label lbFecIni;
        private System.Windows.Forms.Label lbFecFin;
        private System.Windows.Forms.DateTimePicker dtFin;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblIDNota;
        private System.Windows.Forms.TextBox tbID;
    }
}