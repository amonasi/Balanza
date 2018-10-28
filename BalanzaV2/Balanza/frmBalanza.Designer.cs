namespace Balanza
{
    partial class frmBalanza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBalanza));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnLeer = new System.Windows.Forms.Button();
            this.lblTrama = new System.Windows.Forms.Label();
            this.lblEstadoLectura = new System.Windows.Forms.Label();
            this.lblTamCadena = new System.Windows.Forms.Label();
            this.lblVeces = new System.Windows.Forms.Label();
            this.menuOpciones = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.confBalanzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoSacosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parámetrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.confCalidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.seguridadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gbBalanza = new System.Windows.Forms.GroupBox();
            this.tbDecimal = new System.Windows.Forms.TextBox();
            this.lblDecimal = new System.Windows.Forms.Label();
            this.btnDetener = new System.Windows.Forms.Button();
            this.lblPuerto = new System.Windows.Forms.Label();
            this.cmbPuerto = new System.Windows.Forms.ComboBox();
            this.tbCaracteres = new System.Windows.Forms.TextBox();
            this.lblCaracteres = new System.Windows.Forms.Label();
            this.lblEstable = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPN = new System.Windows.Forms.Label();
            this.tbPesoNeto = new System.Windows.Forms.TextBox();
            this.tbPesoBruto = new System.Windows.Forms.TextBox();
            this.tbTrama = new System.Windows.Forms.TextBox();
            this.tbEstable = new System.Windows.Forms.TextBox();
            this.gbNotPes = new System.Windows.Forms.GroupBox();
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
            this.cmbBalanza = new System.Windows.Forms.ComboBox();
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
            this.gbDetalle = new System.Windows.Forms.GroupBox();
            this.btnRecuperar = new System.Windows.Forms.Button();
            this.btnEliminarPeso = new System.Windows.Forms.Button();
            this.btnCapturaPeso = new System.Windows.Forms.Button();
            this.dgvDetalleNota = new System.Windows.Forms.DataGridView();
            this.SECUENCIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO_SACO = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PESO_BRUTO_SACO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PESO_NETO_SACO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTABLE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CAPTURA = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnNuevaCaptura = new System.Windows.Forms.Button();
            this.btnGrabarNota = new System.Windows.Forms.Button();
            this.menuOpciones.SuspendLayout();
            this.gbBalanza.SuspendLayout();
            this.gbNotPes.SuspendLayout();
            this.gbDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleNota)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLeer
            // 
            this.btnLeer.Location = new System.Drawing.Point(427, 23);
            this.btnLeer.Name = "btnLeer";
            this.btnLeer.Size = new System.Drawing.Size(44, 23);
            this.btnLeer.TabIndex = 2;
            this.btnLeer.Text = "Leer";
            this.btnLeer.UseVisualStyleBackColor = true;
            this.btnLeer.Click += new System.EventHandler(this.btnLeer_Click);
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
            this.menuToolStripMenuItem,
            this.configuracionesToolStripMenuItem});
            this.menuOpciones.Location = new System.Drawing.Point(0, 0);
            this.menuOpciones.Name = "menuOpciones";
            this.menuOpciones.Size = new System.Drawing.Size(493, 24);
            this.menuOpciones.TabIndex = 8;
            this.menuOpciones.Text = "Opciones";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historialToolStripMenuItem,
            this.toolStripSeparator2,
            this.salirToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // historialToolStripMenuItem
            // 
            this.historialToolStripMenuItem.Name = "historialToolStripMenuItem";
            this.historialToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.historialToolStripMenuItem.Text = "Historial";
            this.historialToolStripMenuItem.Click += new System.EventHandler(this.historialToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(115, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // configuracionesToolStripMenuItem
            // 
            this.configuracionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confBalanzaToolStripMenuItem,
            this.gruposToolStripMenuItem,
            this.tipoSacosToolStripMenuItem,
            this.parámetrosToolStripMenuItem,
            this.confCalidadToolStripMenuItem,
            this.toolStripSeparator1,
            this.seguridadToolStripMenuItem1});
            this.configuracionesToolStripMenuItem.Name = "configuracionesToolStripMenuItem";
            this.configuracionesToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.configuracionesToolStripMenuItem.Text = "Configuraciones";
            // 
            // confBalanzaToolStripMenuItem
            // 
            this.confBalanzaToolStripMenuItem.Name = "confBalanzaToolStripMenuItem";
            this.confBalanzaToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.confBalanzaToolStripMenuItem.Text = "Conf. Balanza";
            this.confBalanzaToolStripMenuItem.Click += new System.EventHandler(this.confBalanzaToolStripMenuItem_Click);
            // 
            // gruposToolStripMenuItem
            // 
            this.gruposToolStripMenuItem.Name = "gruposToolStripMenuItem";
            this.gruposToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.gruposToolStripMenuItem.Text = "Grupos";
            this.gruposToolStripMenuItem.Click += new System.EventHandler(this.gruposToolStripMenuItem_Click);
            // 
            // tipoSacosToolStripMenuItem
            // 
            this.tipoSacosToolStripMenuItem.Name = "tipoSacosToolStripMenuItem";
            this.tipoSacosToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.tipoSacosToolStripMenuItem.Text = "Tipo Sacos";
            this.tipoSacosToolStripMenuItem.Click += new System.EventHandler(this.tipoSacosToolStripMenuItem_Click);
            // 
            // parámetrosToolStripMenuItem
            // 
            this.parámetrosToolStripMenuItem.Name = "parámetrosToolStripMenuItem";
            this.parámetrosToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.parámetrosToolStripMenuItem.Text = "Parámetros";
            this.parámetrosToolStripMenuItem.Click += new System.EventHandler(this.parámetrosToolStripMenuItem_Click);
            // 
            // confCalidadToolStripMenuItem
            // 
            this.confCalidadToolStripMenuItem.Name = "confCalidadToolStripMenuItem";
            this.confCalidadToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.confCalidadToolStripMenuItem.Text = "Conf. Calidad";
            this.confCalidadToolStripMenuItem.Click += new System.EventHandler(this.confCalidadToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // seguridadToolStripMenuItem1
            // 
            this.seguridadToolStripMenuItem1.Name = "seguridadToolStripMenuItem1";
            this.seguridadToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.seguridadToolStripMenuItem1.Text = "Seguridad";
            this.seguridadToolStripMenuItem1.Click += new System.EventHandler(this.seguridadToolStripMenuItem_Click);
            // 
            // gbBalanza
            // 
            this.gbBalanza.Controls.Add(this.tbDecimal);
            this.gbBalanza.Controls.Add(this.lblDecimal);
            this.gbBalanza.Controls.Add(this.btnDetener);
            this.gbBalanza.Controls.Add(this.lblPuerto);
            this.gbBalanza.Controls.Add(this.cmbPuerto);
            this.gbBalanza.Controls.Add(this.tbCaracteres);
            this.gbBalanza.Controls.Add(this.lblCaracteres);
            this.gbBalanza.Controls.Add(this.lblEstable);
            this.gbBalanza.Controls.Add(this.label2);
            this.gbBalanza.Controls.Add(this.label1);
            this.gbBalanza.Controls.Add(this.lbPN);
            this.gbBalanza.Controls.Add(this.tbPesoNeto);
            this.gbBalanza.Controls.Add(this.tbPesoBruto);
            this.gbBalanza.Controls.Add(this.tbTrama);
            this.gbBalanza.Controls.Add(this.tbEstable);
            this.gbBalanza.Controls.Add(this.btnLeer);
            this.gbBalanza.Location = new System.Drawing.Point(9, 58);
            this.gbBalanza.Name = "gbBalanza";
            this.gbBalanza.Size = new System.Drawing.Size(477, 79);
            this.gbBalanza.TabIndex = 9;
            this.gbBalanza.TabStop = false;
            this.gbBalanza.Text = "Balanza";
            // 
            // tbDecimal
            // 
            this.tbDecimal.Enabled = false;
            this.tbDecimal.Location = new System.Drawing.Point(397, 51);
            this.tbDecimal.Name = "tbDecimal";
            this.tbDecimal.ReadOnly = true;
            this.tbDecimal.Size = new System.Drawing.Size(17, 20);
            this.tbDecimal.TabIndex = 16;
            // 
            // lblDecimal
            // 
            this.lblDecimal.AutoSize = true;
            this.lblDecimal.Location = new System.Drawing.Point(361, 54);
            this.lblDecimal.Name = "lblDecimal";
            this.lblDecimal.Size = new System.Drawing.Size(30, 13);
            this.lblDecimal.TabIndex = 15;
            this.lblDecimal.Text = "Dec:";
            // 
            // btnDetener
            // 
            this.btnDetener.Location = new System.Drawing.Point(427, 50);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(44, 23);
            this.btnDetener.TabIndex = 14;
            this.btnDetener.Text = "Parar";
            this.btnDetener.UseVisualStyleBackColor = true;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // lblPuerto
            // 
            this.lblPuerto.AutoSize = true;
            this.lblPuerto.Location = new System.Drawing.Point(287, 29);
            this.lblPuerto.Name = "lblPuerto";
            this.lblPuerto.Size = new System.Drawing.Size(41, 13);
            this.lblPuerto.TabIndex = 10;
            this.lblPuerto.Text = "Puerto:";
            // 
            // cmbPuerto
            // 
            this.cmbPuerto.FormattingEnabled = true;
            this.cmbPuerto.Location = new System.Drawing.Point(334, 26);
            this.cmbPuerto.Name = "cmbPuerto";
            this.cmbPuerto.Size = new System.Drawing.Size(87, 21);
            this.cmbPuerto.TabIndex = 13;
            // 
            // tbCaracteres
            // 
            this.tbCaracteres.Enabled = false;
            this.tbCaracteres.Location = new System.Drawing.Point(246, 26);
            this.tbCaracteres.Name = "tbCaracteres";
            this.tbCaracteres.Size = new System.Drawing.Size(29, 20);
            this.tbCaracteres.TabIndex = 12;
            // 
            // lblCaracteres
            // 
            this.lblCaracteres.AutoSize = true;
            this.lblCaracteres.Location = new System.Drawing.Point(183, 29);
            this.lblCaracteres.Name = "lblCaracteres";
            this.lblCaracteres.Size = new System.Drawing.Size(61, 13);
            this.lblCaracteres.TabIndex = 11;
            this.lblCaracteres.Text = "Caracteres:";
            // 
            // lblEstable
            // 
            this.lblEstable.AutoSize = true;
            this.lblEstable.Location = new System.Drawing.Point(10, 55);
            this.lblEstable.Name = "lblEstable";
            this.lblEstable.Size = new System.Drawing.Size(45, 13);
            this.lblEstable.TabIndex = 10;
            this.lblEstable.Text = "Estable:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Trama:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Peso Bruto:";
            // 
            // lbPN
            // 
            this.lbPN.AutoSize = true;
            this.lbPN.Location = new System.Drawing.Point(232, 55);
            this.lbPN.Name = "lbPN";
            this.lbPN.Size = new System.Drawing.Size(60, 13);
            this.lbPN.TabIndex = 7;
            this.lbPN.Text = "Peso Neto:";
            // 
            // tbPesoNeto
            // 
            this.tbPesoNeto.Enabled = false;
            this.tbPesoNeto.Location = new System.Drawing.Point(292, 52);
            this.tbPesoNeto.Name = "tbPesoNeto";
            this.tbPesoNeto.Size = new System.Drawing.Size(62, 20);
            this.tbPesoNeto.TabIndex = 6;
            // 
            // tbPesoBruto
            // 
            this.tbPesoBruto.Enabled = false;
            this.tbPesoBruto.Location = new System.Drawing.Point(164, 52);
            this.tbPesoBruto.Name = "tbPesoBruto";
            this.tbPesoBruto.Size = new System.Drawing.Size(62, 20);
            this.tbPesoBruto.TabIndex = 5;
            // 
            // tbTrama
            // 
            this.tbTrama.Enabled = false;
            this.tbTrama.Location = new System.Drawing.Point(61, 26);
            this.tbTrama.Name = "tbTrama";
            this.tbTrama.Size = new System.Drawing.Size(116, 20);
            this.tbTrama.TabIndex = 4;
            // 
            // tbEstable
            // 
            this.tbEstable.Enabled = false;
            this.tbEstable.Location = new System.Drawing.Point(61, 52);
            this.tbEstable.Name = "tbEstable";
            this.tbEstable.Size = new System.Drawing.Size(29, 20);
            this.tbEstable.TabIndex = 3;
            // 
            // gbNotPes
            // 
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
            this.gbNotPes.Controls.Add(this.cmbBalanza);
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
            this.gbNotPes.Location = new System.Drawing.Point(9, 143);
            this.gbNotPes.Name = "gbNotPes";
            this.gbNotPes.Size = new System.Drawing.Size(477, 185);
            this.gbNotPes.TabIndex = 10;
            this.gbNotPes.TabStop = false;
            this.gbNotPes.Text = "Nota de Peso";
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(85, 22);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(386, 21);
            this.cmbEmpresa.TabIndex = 21;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(30, 27);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(51, 13);
            this.lblEmpresa.TabIndex = 20;
            this.lblEmpresa.Text = "Empresa:";
            // 
            // lblTotPesNet
            // 
            this.lblTotPesNet.AutoSize = true;
            this.lblTotPesNet.Location = new System.Drawing.Point(236, 159);
            this.lblTotPesNet.Name = "lblTotPesNet";
            this.lblTotPesNet.Size = new System.Drawing.Size(79, 13);
            this.lblTotPesNet.TabIndex = 19;
            this.lblTotPesNet.Text = "Tot. Pes. Neto:";
            // 
            // tbTotalNotPesNet
            // 
            this.tbTotalNotPesNet.Enabled = false;
            this.tbTotalNotPesNet.Location = new System.Drawing.Point(323, 156);
            this.tbTotalNotPesNet.Name = "tbTotalNotPesNet";
            this.tbTotalNotPesNet.Size = new System.Drawing.Size(148, 20);
            this.tbTotalNotPesNet.TabIndex = 18;
            // 
            // tbTotalNotPesBru
            // 
            this.tbTotalNotPesBru.Enabled = false;
            this.tbTotalNotPesBru.Location = new System.Drawing.Point(85, 156);
            this.tbTotalNotPesBru.Name = "tbTotalNotPesBru";
            this.tbTotalNotPesBru.Size = new System.Drawing.Size(141, 20);
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
            this.label3.Location = new System.Drawing.Point(236, 133);
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
            this.tbDocProductor.Location = new System.Drawing.Point(323, 130);
            this.tbDocProductor.MaxLength = 20;
            this.tbDocProductor.Name = "tbDocProductor";
            this.tbDocProductor.Size = new System.Drawing.Size(148, 20);
            this.tbDocProductor.TabIndex = 13;
            this.tbDocProductor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDocProductor_KeyPress);
            this.tbDocProductor.Leave += new System.EventHandler(this.tbDocProductor_Leave);
            // 
            // tbDocOperador
            // 
            this.tbDocOperador.Location = new System.Drawing.Point(85, 130);
            this.tbDocOperador.MaxLength = 20;
            this.tbDocOperador.Name = "tbDocOperador";
            this.tbDocOperador.Size = new System.Drawing.Size(141, 20);
            this.tbDocOperador.TabIndex = 12;
            this.tbDocOperador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDocOperador_KeyPress);
            this.tbDocOperador.Leave += new System.EventHandler(this.tbDocOperador_Leave);
            // 
            // cmbBalanza
            // 
            this.cmbBalanza.FormattingEnabled = true;
            this.cmbBalanza.Location = new System.Drawing.Point(85, 103);
            this.cmbBalanza.Name = "cmbBalanza";
            this.cmbBalanza.Size = new System.Drawing.Size(141, 21);
            this.cmbBalanza.TabIndex = 11;
            // 
            // tbNumTotSac
            // 
            this.tbNumTotSac.Enabled = false;
            this.tbNumTotSac.Location = new System.Drawing.Point(323, 105);
            this.tbNumTotSac.Name = "tbNumTotSac";
            this.tbNumTotSac.Size = new System.Drawing.Size(148, 20);
            this.tbNumTotSac.TabIndex = 10;
            // 
            // lblCantSacos
            // 
            this.lblCantSacos.AutoSize = true;
            this.lblCantSacos.Location = new System.Drawing.Point(250, 106);
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
            this.lblCiudad.Location = new System.Drawing.Point(274, 78);
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
            this.cmbCiudad.FormattingEnabled = true;
            this.cmbCiudad.Location = new System.Drawing.Point(323, 76);
            this.cmbCiudad.Name = "cmbCiudad";
            this.cmbCiudad.Size = new System.Drawing.Size(148, 21);
            this.cmbCiudad.TabIndex = 5;
            // 
            // cmbTipoGrano
            // 
            this.cmbTipoGrano.FormattingEnabled = true;
            this.cmbTipoGrano.Location = new System.Drawing.Point(85, 76);
            this.cmbTipoGrano.Name = "cmbTipoGrano";
            this.cmbTipoGrano.Size = new System.Drawing.Size(141, 21);
            this.cmbTipoGrano.TabIndex = 4;
            // 
            // lblFecReg
            // 
            this.lblFecReg.AutoSize = true;
            this.lblFecReg.Location = new System.Drawing.Point(244, 52);
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
            this.tbFechaRegistro.Size = new System.Drawing.Size(148, 20);
            this.tbFechaRegistro.TabIndex = 2;
            // 
            // tbNumTicket
            // 
            this.tbNumTicket.Enabled = false;
            this.tbNumTicket.Location = new System.Drawing.Point(85, 49);
            this.tbNumTicket.Name = "tbNumTicket";
            this.tbNumTicket.Size = new System.Drawing.Size(141, 20);
            this.tbNumTicket.TabIndex = 1;
            // 
            // lblNumTic
            // 
            this.lblNumTic.AutoSize = true;
            this.lblNumTic.Location = new System.Drawing.Point(13, 52);
            this.lblNumTic.Name = "lblNumTic";
            this.lblNumTic.Size = new System.Drawing.Size(68, 13);
            this.lblNumTic.TabIndex = 0;
            this.lblNumTic.Text = "Num. Ticket:";
            // 
            // gbDetalle
            // 
            this.gbDetalle.Controls.Add(this.btnRecuperar);
            this.gbDetalle.Controls.Add(this.btnEliminarPeso);
            this.gbDetalle.Controls.Add(this.btnCapturaPeso);
            this.gbDetalle.Controls.Add(this.dgvDetalleNota);
            this.gbDetalle.Location = new System.Drawing.Point(9, 334);
            this.gbDetalle.Name = "gbDetalle";
            this.gbDetalle.Size = new System.Drawing.Size(477, 159);
            this.gbDetalle.TabIndex = 11;
            this.gbDetalle.TabStop = false;
            this.gbDetalle.Text = "Detalle";
            // 
            // btnRecuperar
            // 
            this.btnRecuperar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRecuperar.BackgroundImage")));
            this.btnRecuperar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRecuperar.Location = new System.Drawing.Point(444, 110);
            this.btnRecuperar.Name = "btnRecuperar";
            this.btnRecuperar.Size = new System.Drawing.Size(27, 23);
            this.btnRecuperar.TabIndex = 3;
            this.btnRecuperar.UseVisualStyleBackColor = true;
            this.btnRecuperar.Click += new System.EventHandler(this.btnRecuperar_Click);
            // 
            // btnEliminarPeso
            // 
            this.btnEliminarPeso.Location = new System.Drawing.Point(444, 84);
            this.btnEliminarPeso.Name = "btnEliminarPeso";
            this.btnEliminarPeso.Size = new System.Drawing.Size(27, 23);
            this.btnEliminarPeso.TabIndex = 2;
            this.btnEliminarPeso.Text = "-";
            this.btnEliminarPeso.UseVisualStyleBackColor = true;
            this.btnEliminarPeso.Click += new System.EventHandler(this.btnEliminarPeso_Click);
            // 
            // btnCapturaPeso
            // 
            this.btnCapturaPeso.Location = new System.Drawing.Point(444, 58);
            this.btnCapturaPeso.Name = "btnCapturaPeso";
            this.btnCapturaPeso.Size = new System.Drawing.Size(27, 23);
            this.btnCapturaPeso.TabIndex = 1;
            this.btnCapturaPeso.Text = "+";
            this.btnCapturaPeso.UseVisualStyleBackColor = true;
            this.btnCapturaPeso.Click += new System.EventHandler(this.btnCapturaPeso_Click);
            // 
            // dgvDetalleNota
            // 
            this.dgvDetalleNota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleNota.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SECUENCIA,
            this.CANTIDAD,
            this.TIPO_SACO,
            this.PESO_BRUTO_SACO,
            this.PESO_NETO_SACO,
            this.ESTABLE,
            this.CAPTURA});
            this.dgvDetalleNota.Location = new System.Drawing.Point(6, 20);
            this.dgvDetalleNota.Name = "dgvDetalleNota";
            this.dgvDetalleNota.Size = new System.Drawing.Size(434, 133);
            this.dgvDetalleNota.TabIndex = 0;
            this.dgvDetalleNota.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleNota_CellContentClick);
            this.dgvDetalleNota.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleNota_CellEndEdit);
            this.dgvDetalleNota.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleNota_CellLeave);
            this.dgvDetalleNota.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleNota_CellMouseLeave);
            this.dgvDetalleNota.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleNota_CellValueChanged);
            this.dgvDetalleNota.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetalleNota_EditingControlShowing);
            this.dgvDetalleNota.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvDetalleNota_RowsAdded);
            // 
            // SECUENCIA
            // 
            this.SECUENCIA.FillWeight = 30F;
            this.SECUENCIA.HeaderText = "ID";
            this.SECUENCIA.Name = "SECUENCIA";
            this.SECUENCIA.ReadOnly = true;
            this.SECUENCIA.Width = 30;
            // 
            // CANTIDAD
            // 
            this.CANTIDAD.FillWeight = 40F;
            this.CANTIDAD.HeaderText = "Cant.";
            this.CANTIDAD.MaxInputLength = 3;
            this.CANTIDAD.Name = "CANTIDAD";
            this.CANTIDAD.Width = 40;
            // 
            // TIPO_SACO
            // 
            this.TIPO_SACO.HeaderText = "Tipo Saco";
            this.TIPO_SACO.Name = "TIPO_SACO";
            this.TIPO_SACO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TIPO_SACO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // PESO_BRUTO_SACO
            // 
            this.PESO_BRUTO_SACO.FillWeight = 60F;
            this.PESO_BRUTO_SACO.HeaderText = "Peso Bruto";
            this.PESO_BRUTO_SACO.Name = "PESO_BRUTO_SACO";
            this.PESO_BRUTO_SACO.ReadOnly = true;
            this.PESO_BRUTO_SACO.Width = 60;
            // 
            // PESO_NETO_SACO
            // 
            this.PESO_NETO_SACO.FillWeight = 60F;
            this.PESO_NETO_SACO.HeaderText = "Peso Neto";
            this.PESO_NETO_SACO.Name = "PESO_NETO_SACO";
            this.PESO_NETO_SACO.ReadOnly = true;
            this.PESO_NETO_SACO.Width = 60;
            // 
            // ESTABLE
            // 
            this.ESTABLE.FillWeight = 60F;
            this.ESTABLE.HeaderText = "Peso Estable?";
            this.ESTABLE.Name = "ESTABLE";
            this.ESTABLE.ReadOnly = true;
            this.ESTABLE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ESTABLE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ESTABLE.Width = 60;
            // 
            // CAPTURA
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.CAPTURA.DefaultCellStyle = dataGridViewCellStyle1;
            this.CAPTURA.FillWeight = 40F;
            this.CAPTURA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CAPTURA.HeaderText = "Act. Peso?";
            this.CAPTURA.Name = "CAPTURA";
            this.CAPTURA.Text = "Bal.";
            this.CAPTURA.ToolTipText = "Actualizar Peso";
            this.CAPTURA.UseColumnTextForButtonValue = true;
            this.CAPTURA.Width = 40;
            // 
            // btnNuevaCaptura
            // 
            this.btnNuevaCaptura.Location = new System.Drawing.Point(15, 28);
            this.btnNuevaCaptura.Name = "btnNuevaCaptura";
            this.btnNuevaCaptura.Size = new System.Drawing.Size(110, 23);
            this.btnNuevaCaptura.TabIndex = 12;
            this.btnNuevaCaptura.Text = "Nueva Captura";
            this.btnNuevaCaptura.UseVisualStyleBackColor = true;
            this.btnNuevaCaptura.Click += new System.EventHandler(this.btnNuevaCaptura_Click);
            // 
            // btnGrabarNota
            // 
            this.btnGrabarNota.Location = new System.Drawing.Point(132, 27);
            this.btnGrabarNota.Name = "btnGrabarNota";
            this.btnGrabarNota.Size = new System.Drawing.Size(96, 23);
            this.btnGrabarNota.TabIndex = 13;
            this.btnGrabarNota.Text = "Grabar Nota";
            this.btnGrabarNota.UseVisualStyleBackColor = true;
            this.btnGrabarNota.Click += new System.EventHandler(this.btnGrabarNota_Click);
            // 
            // frmBalanza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 505);
            this.Controls.Add(this.btnGrabarNota);
            this.Controls.Add(this.btnNuevaCaptura);
            this.Controls.Add(this.gbDetalle);
            this.Controls.Add(this.gbNotPes);
            this.Controls.Add(this.gbBalanza);
            this.Controls.Add(this.lblVeces);
            this.Controls.Add(this.lblTamCadena);
            this.Controls.Add(this.lblEstadoLectura);
            this.Controls.Add(this.lblTrama);
            this.Controls.Add(this.menuOpciones);
            this.MainMenuStrip = this.menuOpciones;
            this.MaximizeBox = false;
            this.Name = "frmBalanza";
            this.Text = "Balanza";
            this.Load += new System.EventHandler(this.FormBalanza_Load);
            this.menuOpciones.ResumeLayout(false);
            this.menuOpciones.PerformLayout();
            this.gbBalanza.ResumeLayout(false);
            this.gbBalanza.PerformLayout();
            this.gbNotPes.ResumeLayout(false);
            this.gbNotPes.PerformLayout();
            this.gbDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleNota)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLeer;
        private System.Windows.Forms.Label lblTrama;
        private System.Windows.Forms.Label lblEstadoLectura;
        private System.Windows.Forms.Label lblTamCadena;
        private System.Windows.Forms.Label lblVeces;
        private System.Windows.Forms.MenuStrip menuOpciones;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parámetrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seguridadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem gruposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem confBalanzaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbBalanza;
        private System.Windows.Forms.TextBox tbCaracteres;
        private System.Windows.Forms.Label lblCaracteres;
        private System.Windows.Forms.Label lblEstable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPN;
        private System.Windows.Forms.TextBox tbPesoNeto;
        private System.Windows.Forms.TextBox tbPesoBruto;
        private System.Windows.Forms.TextBox tbTrama;
        private System.Windows.Forms.TextBox tbEstable;
        private System.Windows.Forms.Label lblPuerto;
        private System.Windows.Forms.ComboBox cmbPuerto;
        private System.Windows.Forms.GroupBox gbNotPes;
        private System.Windows.Forms.TextBox tbNumTicket;
        private System.Windows.Forms.Label lblNumTic;
        private System.Windows.Forms.Label lblFecReg;
        private System.Windows.Forms.TextBox tbFechaRegistro;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.Label lblTipoGrano;
        private System.Windows.Forms.ComboBox cmbCiudad;
        private System.Windows.Forms.ComboBox cmbTipoGrano;
        private System.Windows.Forms.ComboBox cmbBalanza;
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
        private System.Windows.Forms.GroupBox gbDetalle;
        private System.Windows.Forms.DataGridView dgvDetalleNota;
        private System.Windows.Forms.Button btnEliminarPeso;
        private System.Windows.Forms.Button btnCapturaPeso;
        private System.Windows.Forms.Button btnNuevaCaptura;
        private System.Windows.Forms.Button btnGrabarNota;
        private System.Windows.Forms.ToolStripMenuItem tipoSacosToolStripMenuItem;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn SECUENCIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDAD;
        private System.Windows.Forms.DataGridViewComboBoxColumn TIPO_SACO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PESO_BRUTO_SACO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PESO_NETO_SACO;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ESTABLE;
        private System.Windows.Forms.DataGridViewButtonColumn CAPTURA;
        private System.Windows.Forms.TextBox tbDecimal;
        private System.Windows.Forms.Label lblDecimal;
        private System.Windows.Forms.ToolStripMenuItem confCalidadToolStripMenuItem;
        private System.Windows.Forms.Button btnRecuperar;
    }
}

