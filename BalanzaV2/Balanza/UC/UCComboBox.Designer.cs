namespace Balanza.UC
{
    partial class UCComboBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbEtiqueta = new System.Windows.Forms.Label();
            this.cmbValor = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbEtiqueta
            // 
            this.lbEtiqueta.AutoSize = true;
            this.lbEtiqueta.Location = new System.Drawing.Point(4, 5);
            this.lbEtiqueta.Name = "lbEtiqueta";
            this.lbEtiqueta.Size = new System.Drawing.Size(35, 13);
            this.lbEtiqueta.TabIndex = 1;
            this.lbEtiqueta.Text = "label1";
            // 
            // cmbValor
            // 
            this.cmbValor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbValor.FormattingEnabled = true;
            this.cmbValor.Location = new System.Drawing.Point(72, 0);
            this.cmbValor.Name = "cmbValor";
            this.cmbValor.Size = new System.Drawing.Size(149, 21);
            this.cmbValor.TabIndex = 2;
            // 
            // UCComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbValor);
            this.Controls.Add(this.lbEtiqueta);
            this.Name = "UCComboBox";
            this.Size = new System.Drawing.Size(247, 21);
            this.Load += new System.EventHandler(this.UCComboBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbEtiqueta;
        private System.Windows.Forms.ComboBox cmbValor;
    }
}
