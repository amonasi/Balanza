namespace Balanza.UC
{
    partial class UCPercentage
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
            this.tbValor = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // lbEtiqueta
            // 
            this.lbEtiqueta.AutoSize = true;
            this.lbEtiqueta.Location = new System.Drawing.Point(3, 6);
            this.lbEtiqueta.Name = "lbEtiqueta";
            this.lbEtiqueta.Size = new System.Drawing.Size(35, 13);
            this.lbEtiqueta.TabIndex = 2;
            this.lbEtiqueta.Text = "label1";
            // 
            // tbValor
            // 
            this.tbValor.Location = new System.Drawing.Point(73, 3);
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(51, 20);
            this.tbValor.TabIndex = 3;
            this.tbValor.Leave += new System.EventHandler(this.tbValor_Leave);
            // 
            // UCPercentage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbValor);
            this.Controls.Add(this.lbEtiqueta);
            this.Name = "UCPercentage";
            this.Size = new System.Drawing.Size(157, 25);
            this.Load += new System.EventHandler(this.UCPercentage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbEtiqueta;
        private System.Windows.Forms.MaskedTextBox tbValor;
    }
}
