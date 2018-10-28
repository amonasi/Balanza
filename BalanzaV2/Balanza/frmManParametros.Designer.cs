namespace Balanza
{
    partial class frmManParametros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManParametros));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSecuencia = new System.Windows.Forms.Label();
            this.gbParametros = new System.Windows.Forms.GroupBox();
            this.tbPassUsuario = new System.Windows.Forms.TextBox();
            this.tbPassAdmin = new System.Windows.Forms.TextBox();
            this.tbLocalidad = new System.Windows.Forms.TextBox();
            this.tbTamCar = new System.Windows.Forms.TextBox();
            this.tbSecuencia = new System.Windows.Forms.TextBox();
            this.lblUsu = new System.Windows.Forms.Label();
            this.lblAdm = new System.Windows.Forms.Label();
            this.lblLoc = new System.Windows.Forms.Label();
            this.lblTamCar = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.gbParametros.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            resources.ApplyResources(this.opcionesToolStripMenuItem, "opcionesToolStripMenuItem");
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            resources.ApplyResources(this.guardarToolStripMenuItem, "guardarToolStripMenuItem");
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            resources.ApplyResources(this.salirToolStripMenuItem, "salirToolStripMenuItem");
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // lblSecuencia
            // 
            resources.ApplyResources(this.lblSecuencia, "lblSecuencia");
            this.lblSecuencia.Name = "lblSecuencia";
            // 
            // gbParametros
            // 
            this.gbParametros.Controls.Add(this.tbPassUsuario);
            this.gbParametros.Controls.Add(this.tbPassAdmin);
            this.gbParametros.Controls.Add(this.tbLocalidad);
            this.gbParametros.Controls.Add(this.tbTamCar);
            this.gbParametros.Controls.Add(this.tbSecuencia);
            this.gbParametros.Controls.Add(this.lblUsu);
            this.gbParametros.Controls.Add(this.lblAdm);
            this.gbParametros.Controls.Add(this.lblLoc);
            this.gbParametros.Controls.Add(this.lblTamCar);
            this.gbParametros.Controls.Add(this.lblSecuencia);
            resources.ApplyResources(this.gbParametros, "gbParametros");
            this.gbParametros.Name = "gbParametros";
            this.gbParametros.TabStop = false;
            // 
            // tbPassUsuario
            // 
            resources.ApplyResources(this.tbPassUsuario, "tbPassUsuario");
            this.tbPassUsuario.Name = "tbPassUsuario";
            // 
            // tbPassAdmin
            // 
            resources.ApplyResources(this.tbPassAdmin, "tbPassAdmin");
            this.tbPassAdmin.Name = "tbPassAdmin";
            // 
            // tbLocalidad
            // 
            this.tbLocalidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tbLocalidad, "tbLocalidad");
            this.tbLocalidad.Name = "tbLocalidad";
            // 
            // tbTamCar
            // 
            resources.ApplyResources(this.tbTamCar, "tbTamCar");
            this.tbTamCar.Name = "tbTamCar";
            this.tbTamCar.TextChanged += new System.EventHandler(this.tbTamCar_TextChanged);
            this.tbTamCar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTamCar_KeyPress);
            // 
            // tbSecuencia
            // 
            resources.ApplyResources(this.tbSecuencia, "tbSecuencia");
            this.tbSecuencia.Name = "tbSecuencia";
            this.tbSecuencia.TextChanged += new System.EventHandler(this.tbSecuencia_TextChanged);
            this.tbSecuencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSecuencia_KeyPress);
            // 
            // lblUsu
            // 
            resources.ApplyResources(this.lblUsu, "lblUsu");
            this.lblUsu.Name = "lblUsu";
            // 
            // lblAdm
            // 
            resources.ApplyResources(this.lblAdm, "lblAdm");
            this.lblAdm.Name = "lblAdm";
            // 
            // lblLoc
            // 
            resources.ApplyResources(this.lblLoc, "lblLoc");
            this.lblLoc.Name = "lblLoc";
            // 
            // lblTamCar
            // 
            resources.ApplyResources(this.lblTamCar, "lblTamCar");
            this.lblTamCar.Name = "lblTamCar";
            // 
            // frmManParametros
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbParametros);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.Name = "frmManParametros";
            this.Load += new System.EventHandler(this.frmManParametros_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbParametros.ResumeLayout(false);
            this.gbParametros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Label lblSecuencia;
        private System.Windows.Forms.GroupBox gbParametros;
        private System.Windows.Forms.Label lblLoc;
        private System.Windows.Forms.Label lblTamCar;
        private System.Windows.Forms.Label lblUsu;
        private System.Windows.Forms.Label lblAdm;
        private System.Windows.Forms.TextBox tbPassUsuario;
        private System.Windows.Forms.TextBox tbPassAdmin;
        private System.Windows.Forms.TextBox tbLocalidad;
        private System.Windows.Forms.TextBox tbTamCar;
        private System.Windows.Forms.TextBox tbSecuencia;
    }
}