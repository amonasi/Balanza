namespace Balanza
{
    partial class frmCalidad
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
            this.lblTrama = new System.Windows.Forms.Label();
            this.lblEstadoLectura = new System.Windows.Forms.Label();
            this.lblTamCadena = new System.Windows.Forms.Label();
            this.lblVeces = new System.Windows.Forms.Label();
            this.menuOpciones = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grabarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbNotPes = new System.Windows.Forms.GroupBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.tbPesosRegistrados = new System.Windows.Forms.TextBox();
            this.lblTotPes = new System.Windows.Forms.Label();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.lblTotPesNet = new System.Windows.Forms.Label();
            this.tbTotalNotPesNet = new System.Windows.Forms.TextBox();
            this.tbTotalNotPesBru = new System.Windows.Forms.TextBox();
            this.lblToTPesBru = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDocOpe = new System.Windows.Forms.Label();
            this.tbDocProductor = new System.Windows.Forms.TextBox();
            this.tbDocOperador = new System.Windows.Forms.TextBox();
            this.tbNumTotSac = new System.Windows.Forms.TextBox();
            this.lblCantSacos = new System.Windows.Forms.Label();
            this.lblBal = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.lblTipoGrano = new System.Windows.Forms.Label();
            this.cmbCiudad = new System.Windows.Forms.ComboBox();
            this.cmbTipoGrano = new System.Windows.Forms.ComboBox();
            this.lblFecReg = new System.Windows.Forms.Label();
            this.tbFechaRegistro = new System.Windows.Forms.TextBox();
            this.tbNumTicket = new System.Windows.Forms.TextBox();
            this.lblNumTic = new System.Windows.Forms.Label();
            this.tlPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tbBalanza = new System.Windows.Forms.TextBox();
            this.menuOpciones.SuspendLayout();
            this.gbNotPes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTrama
            // 
            this.lblTrama.AutoSize = true;
            this.lblTrama.Location = new System.Drawing.Point(6, 53);
            this.lblTrama.Name = "lblTrama";
            this.lblTrama.Size = new System.Drawing.Size(0, 13);
            this.lblTrama.TabIndex = 4;
            // 
            // lblEstadoLectura
            // 
            this.lblEstadoLectura.AutoSize = true;
            this.lblEstadoLectura.Location = new System.Drawing.Point(165, 8);
            this.lblEstadoLectura.Name = "lblEstadoLectura";
            this.lblEstadoLectura.Size = new System.Drawing.Size(0, 13);
            this.lblEstadoLectura.TabIndex = 5;
            // 
            // lblTamCadena
            // 
            this.lblTamCadena.AutoSize = true;
            this.lblTamCadena.Location = new System.Drawing.Point(254, 8);
            this.lblTamCadena.Name = "lblTamCadena";
            this.lblTamCadena.Size = new System.Drawing.Size(0, 13);
            this.lblTamCadena.TabIndex = 6;
            // 
            // lblVeces
            // 
            this.lblVeces.AutoSize = true;
            this.lblVeces.Location = new System.Drawing.Point(363, 7);
            this.lblVeces.Name = "lblVeces";
            this.lblVeces.Size = new System.Drawing.Size(0, 13);
            this.lblVeces.TabIndex = 7;
            // 
            // menuOpciones
            // 
            this.menuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuOpciones.Location = new System.Drawing.Point(0, 0);
            this.menuOpciones.Name = "menuOpciones";
            this.menuOpciones.Size = new System.Drawing.Size(493, 24);
            this.menuOpciones.TabIndex = 8;
            this.menuOpciones.Text = "Opciones";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grabarToolStripMenuItem,
            this.toolStripSeparator2,
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(106, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // gbNotPes
            // 
            this.gbNotPes.Controls.Add(this.tbBalanza);
            this.gbNotPes.Controls.Add(this.tbID);
            this.gbNotPes.Controls.Add(this.lblID);
            this.gbNotPes.Controls.Add(this.tbPesosRegistrados);
            this.gbNotPes.Controls.Add(this.lblTotPes);
            this.gbNotPes.Controls.Add(this.cmbEmpresa);
            this.gbNotPes.Controls.Add(this.lblEmpresa);
            this.gbNotPes.Controls.Add(this.lblTotPesNet);
            this.gbNotPes.Controls.Add(this.tbTotalNotPesNet);
            this.gbNotPes.Controls.Add(this.tbTotalNotPesBru);
            this.gbNotPes.Controls.Add(this.lblToTPesBru);
            this.gbNotPes.Controls.Add(this.label3);
            this.gbNotPes.Controls.Add(this.lblDocOpe);
            this.gbNotPes.Controls.Add(this.tbDocProductor);
            this.gbNotPes.Controls.Add(this.tbDocOperador);
            this.gbNotPes.Controls.Add(this.tbNumTotSac);
            this.gbNotPes.Controls.Add(this.lblCantSacos);
            this.gbNotPes.Controls.Add(this.lblBal);
            this.gbNotPes.Controls.Add(this.lblCiudad);
            this.gbNotPes.Controls.Add(this.lblTipoGrano);
            this.gbNotPes.Controls.Add(this.cmbCiudad);
            this.gbNotPes.Controls.Add(this.cmbTipoGrano);
            this.gbNotPes.Controls.Add(this.lblFecReg);
            this.gbNotPes.Controls.Add(this.tbFechaRegistro);
            this.gbNotPes.Controls.Add(this.tbNumTicket);
            this.gbNotPes.Controls.Add(this.lblNumTic);
            this.gbNotPes.Location = new System.Drawing.Point(9, 27);
            this.gbNotPes.Name = "gbNotPes";
            this.gbNotPes.Size = new System.Drawing.Size(477, 185);
            this.gbNotPes.TabIndex = 10;
            this.gbNotPes.TabStop = false;
            this.gbNotPes.Text = "Nota de Peso";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(85, 22);
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(141, 20);
            this.tbID.TabIndex = 25;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(60, 25);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 24;
            this.lblID.Text = "ID:";
            // 
            // tbPesosRegistrados
            // 
            this.tbPesosRegistrados.Location = new System.Drawing.Point(323, 105);
            this.tbPesosRegistrados.Name = "tbPesosRegistrados";
            this.tbPesosRegistrados.ReadOnly = true;
            this.tbPesosRegistrados.Size = new System.Drawing.Size(148, 20);
            this.tbPesosRegistrados.TabIndex = 23;
            // 
            // lblTotPes
            // 
            this.lblTotPes.AutoSize = true;
            this.lblTotPes.Location = new System.Drawing.Point(228, 106);
            this.lblTotPes.Name = "lblTotPes";
            this.lblTotPes.Size = new System.Drawing.Size(93, 13);
            this.lblTotPes.TabIndex = 22;
            this.lblTotPes.Text = "Pesos registrados:";
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.Enabled = false;
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(85, 49);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(141, 21);
            this.cmbEmpresa.TabIndex = 21;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(30, 49);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(51, 13);
            this.lblEmpresa.TabIndex = 20;
            this.lblEmpresa.Text = "Empresa:";
            // 
            // lblTotPesNet
            // 
            this.lblTotPesNet.AutoSize = true;
            this.lblTotPesNet.Location = new System.Drawing.Point(166, 159);
            this.lblTotPesNet.Name = "lblTotPesNet";
            this.lblTotPesNet.Size = new System.Drawing.Size(79, 13);
            this.lblTotPesNet.TabIndex = 19;
            this.lblTotPesNet.Text = "Tot. Pes. Neto:";
            // 
            // tbTotalNotPesNet
            // 
            this.tbTotalNotPesNet.Enabled = false;
            this.tbTotalNotPesNet.Location = new System.Drawing.Point(251, 156);
            this.tbTotalNotPesNet.Name = "tbTotalNotPesNet";
            this.tbTotalNotPesNet.ReadOnly = true;
            this.tbTotalNotPesNet.Size = new System.Drawing.Size(83, 20);
            this.tbTotalNotPesNet.TabIndex = 18;
            // 
            // tbTotalNotPesBru
            // 
            this.tbTotalNotPesBru.Enabled = false;
            this.tbTotalNotPesBru.Location = new System.Drawing.Point(85, 156);
            this.tbTotalNotPesBru.Name = "tbTotalNotPesBru";
            this.tbTotalNotPesBru.ReadOnly = true;
            this.tbTotalNotPesBru.Size = new System.Drawing.Size(71, 20);
            this.tbTotalNotPesBru.TabIndex = 17;
            // 
            // lblToTPesBru
            // 
            this.lblToTPesBru.AutoSize = true;
            this.lblToTPesBru.Location = new System.Drawing.Point(3, 159);
            this.lblToTPesBru.Name = "lblToTPesBru";
            this.lblToTPesBru.Size = new System.Drawing.Size(81, 13);
            this.lblToTPesBru.TabIndex = 16;
            this.lblToTPesBru.Text = "Tot. Pes. Bruto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Doc. Productor:";
            // 
            // lblDocOpe
            // 
            this.lblDocOpe.AutoSize = true;
            this.lblDocOpe.Location = new System.Drawing.Point(3, 133);
            this.lblDocOpe.Name = "lblDocOpe";
            this.lblDocOpe.Size = new System.Drawing.Size(80, 13);
            this.lblDocOpe.TabIndex = 14;
            this.lblDocOpe.Text = "Doc. Operador:";
            // 
            // tbDocProductor
            // 
            this.tbDocProductor.Enabled = false;
            this.tbDocProductor.Location = new System.Drawing.Point(323, 130);
            this.tbDocProductor.MaxLength = 20;
            this.tbDocProductor.Name = "tbDocProductor";
            this.tbDocProductor.ReadOnly = true;
            this.tbDocProductor.Size = new System.Drawing.Size(148, 20);
            this.tbDocProductor.TabIndex = 13;
            // 
            // tbDocOperador
            // 
            this.tbDocOperador.Enabled = false;
            this.tbDocOperador.Location = new System.Drawing.Point(85, 130);
            this.tbDocOperador.MaxLength = 20;
            this.tbDocOperador.Name = "tbDocOperador";
            this.tbDocOperador.ReadOnly = true;
            this.tbDocOperador.Size = new System.Drawing.Size(141, 20);
            this.tbDocOperador.TabIndex = 12;
            // 
            // tbNumTotSac
            // 
            this.tbNumTotSac.Enabled = false;
            this.tbNumTotSac.Location = new System.Drawing.Point(410, 156);
            this.tbNumTotSac.Name = "tbNumTotSac";
            this.tbNumTotSac.ReadOnly = true;
            this.tbNumTotSac.Size = new System.Drawing.Size(61, 20);
            this.tbNumTotSac.TabIndex = 10;
            // 
            // lblCantSacos
            // 
            this.lblCantSacos.AutoSize = true;
            this.lblCantSacos.Location = new System.Drawing.Point(343, 159);
            this.lblCantSacos.Name = "lblCantSacos";
            this.lblCantSacos.Size = new System.Drawing.Size(68, 13);
            this.lblCantSacos.TabIndex = 9;
            this.lblCantSacos.Text = "Cant. Sacos:";
            // 
            // lblBal
            // 
            this.lblBal.AutoSize = true;
            this.lblBal.Location = new System.Drawing.Point(33, 105);
            this.lblBal.Name = "lblBal";
            this.lblBal.Size = new System.Drawing.Size(48, 13);
            this.lblBal.TabIndex = 8;
            this.lblBal.Text = "Balanza:";
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Location = new System.Drawing.Point(277, 78);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(43, 13);
            this.lblCiudad.TabIndex = 7;
            this.lblCiudad.Text = "Ciudad:";
            // 
            // lblTipoGrano
            // 
            this.lblTipoGrano.AutoSize = true;
            this.lblTipoGrano.Location = new System.Drawing.Point(18, 78);
            this.lblTipoGrano.Name = "lblTipoGrano";
            this.lblTipoGrano.Size = new System.Drawing.Size(63, 13);
            this.lblTipoGrano.TabIndex = 6;
            this.lblTipoGrano.Text = "Tipo Grano:";
            // 
            // cmbCiudad
            // 
            this.cmbCiudad.Enabled = false;
            this.cmbCiudad.FormattingEnabled = true;
            this.cmbCiudad.Location = new System.Drawing.Point(323, 76);
            this.cmbCiudad.Name = "cmbCiudad";
            this.cmbCiudad.Size = new System.Drawing.Size(148, 21);
            this.cmbCiudad.TabIndex = 5;
            // 
            // cmbTipoGrano
            // 
            this.cmbTipoGrano.Enabled = false;
            this.cmbTipoGrano.FormattingEnabled = true;
            this.cmbTipoGrano.Location = new System.Drawing.Point(85, 76);
            this.cmbTipoGrano.Name = "cmbTipoGrano";
            this.cmbTipoGrano.Size = new System.Drawing.Size(141, 21);
            this.cmbTipoGrano.TabIndex = 4;
            // 
            // lblFecReg
            // 
            this.lblFecReg.AutoSize = true;
            this.lblFecReg.Location = new System.Drawing.Point(247, 52);
            this.lblFecReg.Name = "lblFecReg";
            this.lblFecReg.Size = new System.Drawing.Size(73, 13);
            this.lblFecReg.TabIndex = 3;
            this.lblFecReg.Text = "Fec. Registro:";
            // 
            // tbFechaRegistro
            // 
            this.tbFechaRegistro.Enabled = false;
            this.tbFechaRegistro.Location = new System.Drawing.Point(323, 49);
            this.tbFechaRegistro.Name = "tbFechaRegistro";
            this.tbFechaRegistro.ReadOnly = true;
            this.tbFechaRegistro.Size = new System.Drawing.Size(148, 20);
            this.tbFechaRegistro.TabIndex = 2;
            // 
            // tbNumTicket
            // 
            this.tbNumTicket.Enabled = false;
            this.tbNumTicket.Location = new System.Drawing.Point(323, 23);
            this.tbNumTicket.Name = "tbNumTicket";
            this.tbNumTicket.ReadOnly = true;
            this.tbNumTicket.Size = new System.Drawing.Size(148, 20);
            this.tbNumTicket.TabIndex = 1;
            // 
            // lblNumTic
            // 
            this.lblNumTic.AutoSize = true;
            this.lblNumTic.Location = new System.Drawing.Point(252, 26);
            this.lblNumTic.Name = "lblNumTic";
            this.lblNumTic.Size = new System.Drawing.Size(68, 13);
            this.lblNumTic.TabIndex = 0;
            this.lblNumTic.Text = "Num. Ticket:";
            // 
            // tlPanel
            // 
            this.tlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlPanel.AutoSize = true;
            this.tlPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlPanel.ColumnCount = 2;
            this.tlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlPanel.Location = new System.Drawing.Point(9, 218);
            this.tlPanel.Name = "tlPanel";
            this.tlPanel.RowCount = 1;
            this.tlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlPanel.Size = new System.Drawing.Size(477, 2);
            this.tlPanel.TabIndex = 11;
            // 
            // tbBalanza
            // 
            this.tbBalanza.Enabled = false;
            this.tbBalanza.Location = new System.Drawing.Point(85, 102);
            this.tbBalanza.Name = "tbBalanza";
            this.tbBalanza.Size = new System.Drawing.Size(141, 20);
            this.tbBalanza.TabIndex = 26;
            // 
            // frmCalidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 393);
            this.Controls.Add(this.tlPanel);
            this.Controls.Add(this.gbNotPes);
            this.Controls.Add(this.lblVeces);
            this.Controls.Add(this.lblTamCadena);
            this.Controls.Add(this.lblEstadoLectura);
            this.Controls.Add(this.lblTrama);
            this.Controls.Add(this.menuOpciones);
            this.MainMenuStrip = this.menuOpciones;
            this.MaximizeBox = false;
            this.Name = "frmCalidad";
            this.Text = "Nota de calidad";
            this.Load += new System.EventHandler(this.FormCalidad_Load);
            this.menuOpciones.ResumeLayout(false);
            this.menuOpciones.PerformLayout();
            this.gbNotPes.ResumeLayout(false);
            this.gbNotPes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTrama;
        private System.Windows.Forms.Label lblEstadoLectura;
        private System.Windows.Forms.Label lblTamCadena;
        private System.Windows.Forms.Label lblVeces;
        private System.Windows.Forms.MenuStrip menuOpciones;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox gbNotPes;
        private System.Windows.Forms.TextBox tbNumTicket;
        private System.Windows.Forms.Label lblNumTic;
        private System.Windows.Forms.Label lblFecReg;
        private System.Windows.Forms.TextBox tbFechaRegistro;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.Label lblTipoGrano;
        private System.Windows.Forms.ComboBox cmbCiudad;
        private System.Windows.Forms.ComboBox cmbTipoGrano;
        private System.Windows.Forms.TextBox tbNumTotSac;
        private System.Windows.Forms.Label lblCantSacos;
        private System.Windows.Forms.Label lblBal;
        private System.Windows.Forms.TextBox tbDocProductor;
        private System.Windows.Forms.TextBox tbDocOperador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDocOpe;
        private System.Windows.Forms.Label lblTotPesNet;
        private System.Windows.Forms.TextBox tbTotalNotPesNet;
        private System.Windows.Forms.TextBox tbTotalNotPesBru;
        private System.Windows.Forms.Label lblToTPesBru;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.ToolStripMenuItem grabarToolStripMenuItem;
        private System.Windows.Forms.TextBox tbPesosRegistrados;
        private System.Windows.Forms.Label lblTotPes;
        private System.Windows.Forms.TableLayoutPanel tlPanel;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox tbBalanza;
    }
}

