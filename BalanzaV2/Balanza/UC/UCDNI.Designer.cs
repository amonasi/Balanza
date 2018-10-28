namespace Balanza.UC
{
    partial class UCDNI
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
            this.tbValor = new System.Windows.Forms.MaskedTextBox();
            this.lbEtiqueta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbValor
            // 
            this.tbValor.Location = new System.Drawing.Point(74, 1);
            this.tbValor.Mask = "99999999999";
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(83, 20);
            this.tbValor.TabIndex = 5;
            this.tbValor.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.tbValor_MaskInputRejected);
            this.tbValor.Leave += new System.EventHandler(this.tbValor_Leave);
            // 
            // lbEtiqueta
            // 
            this.lbEtiqueta.AutoSize = true;
            this.lbEtiqueta.Location = new System.Drawing.Point(4, 4);
            this.lbEtiqueta.Name = "lbEtiqueta";
            this.lbEtiqueta.Size = new System.Drawing.Size(35, 13);
            this.lbEtiqueta.TabIndex = 4;
            this.lbEtiqueta.Text = "label1";
            // 
            // UCDNI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbValor);
            this.Controls.Add(this.lbEtiqueta);
            this.Name = "UCDNI";
            this.Size = new System.Drawing.Size(210, 23);
            this.Load += new System.EventHandler(this.UCDNI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox tbValor;
        private System.Windows.Forms.Label lbEtiqueta;
    }
}
