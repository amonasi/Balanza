namespace Balanza
{
    partial class frmSecurity
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnDo = new System.Windows.Forms.Button();
            this.gbSeguridad = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.tbResultado = new System.Windows.Forms.TextBox();
            this.tbValor = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.lblAlgoritmo = new System.Windows.Forms.Label();
            this.lbltipoPro = new System.Windows.Forms.Label();
            this.cmbAlgoritmo = new System.Windows.Forms.ComboBox();
            this.cmbTipoPro = new System.Windows.Forms.ComboBox();
            this.gbSeguridad.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(259, 152);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(116, 23);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnDo
            // 
            this.btnDo.Location = new System.Drawing.Point(114, 152);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(121, 23);
            this.btnDo.TabIndex = 3;
            this.btnDo.Text = "Ejecutar";
            this.btnDo.UseVisualStyleBackColor = true;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // gbSeguridad
            // 
            this.gbSeguridad.Controls.Add(this.label1);
            this.gbSeguridad.Controls.Add(this.lblValor);
            this.gbSeguridad.Controls.Add(this.tbResultado);
            this.gbSeguridad.Controls.Add(this.tbValor);
            this.gbSeguridad.Controls.Add(this.lblKey);
            this.gbSeguridad.Controls.Add(this.tbKey);
            this.gbSeguridad.Controls.Add(this.lblAlgoritmo);
            this.gbSeguridad.Controls.Add(this.lbltipoPro);
            this.gbSeguridad.Controls.Add(this.cmbAlgoritmo);
            this.gbSeguridad.Controls.Add(this.cmbTipoPro);
            this.gbSeguridad.Location = new System.Drawing.Point(7, 9);
            this.gbSeguridad.Name = "gbSeguridad";
            this.gbSeguridad.Size = new System.Drawing.Size(487, 132);
            this.gbSeguridad.TabIndex = 5;
            this.gbSeguridad.TabStop = false;
            this.gbSeguridad.Text = "Opciones";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Resultado:";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(17, 79);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(34, 13);
            this.lblValor.TabIndex = 6;
            this.lblValor.Text = "Valor:";
            // 
            // tbResultado
            // 
            this.tbResultado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResultado.Location = new System.Drawing.Point(79, 104);
            this.tbResultado.Name = "tbResultado";
            this.tbResultado.Size = new System.Drawing.Size(393, 20);
            this.tbResultado.TabIndex = 9;
            // 
            // tbValor
            // 
            this.tbValor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbValor.Location = new System.Drawing.Point(79, 78);
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(393, 20);
            this.tbValor.TabIndex = 7;
            // 
            // lblKey
            // 
            this.lblKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(248, 28);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(31, 13);
            this.lblKey.TabIndex = 2;
            this.lblKey.Text = "KEY:";
            // 
            // tbKey
            // 
            this.tbKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbKey.Enabled = false;
            this.tbKey.Location = new System.Drawing.Point(285, 25);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(187, 20);
            this.tbKey.TabIndex = 3;
            // 
            // lblAlgoritmo
            // 
            this.lblAlgoritmo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlgoritmo.AutoSize = true;
            this.lblAlgoritmo.Location = new System.Drawing.Point(17, 28);
            this.lblAlgoritmo.Name = "lblAlgoritmo";
            this.lblAlgoritmo.Size = new System.Drawing.Size(53, 13);
            this.lblAlgoritmo.TabIndex = 0;
            this.lblAlgoritmo.Text = "Algoritmo:";
            // 
            // lbltipoPro
            // 
            this.lbltipoPro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltipoPro.AutoSize = true;
            this.lbltipoPro.Location = new System.Drawing.Point(17, 54);
            this.lbltipoPro.Name = "lbltipoPro";
            this.lbltipoPro.Size = new System.Drawing.Size(49, 13);
            this.lbltipoPro.TabIndex = 4;
            this.lbltipoPro.Text = "Proceso:";
            // 
            // cmbAlgoritmo
            // 
            this.cmbAlgoritmo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAlgoritmo.FormattingEnabled = true;
            this.cmbAlgoritmo.Location = new System.Drawing.Point(79, 24);
            this.cmbAlgoritmo.Name = "cmbAlgoritmo";
            this.cmbAlgoritmo.Size = new System.Drawing.Size(121, 21);
            this.cmbAlgoritmo.TabIndex = 1;
            this.cmbAlgoritmo.SelectedIndexChanged += new System.EventHandler(this.cmbAlgoritmo_SelectedIndexChanged);
            // 
            // cmbTipoPro
            // 
            this.cmbTipoPro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoPro.FormattingEnabled = true;
            this.cmbTipoPro.Location = new System.Drawing.Point(79, 51);
            this.cmbTipoPro.Name = "cmbTipoPro";
            this.cmbTipoPro.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoPro.TabIndex = 5;
            this.cmbTipoPro.SelectedIndexChanged += new System.EventHandler(this.cmbTipoPro_SelectedIndexChanged);
            // 
            // frmSecurity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 185);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnDo);
            this.Controls.Add(this.gbSeguridad);
            this.Name = "frmSecurity";
            this.Text = "frmSecurity";
            this.Load += new System.EventHandler(this.frmSecurity_Load);
            this.gbSeguridad.ResumeLayout(false);
            this.gbSeguridad.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnDo;
        private System.Windows.Forms.GroupBox gbSeguridad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox tbResultado;
        private System.Windows.Forms.TextBox tbValor;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label lblAlgoritmo;
        private System.Windows.Forms.Label lbltipoPro;
        private System.Windows.Forms.ComboBox cmbAlgoritmo;
        private System.Windows.Forms.ComboBox cmbTipoPro;
    }
}