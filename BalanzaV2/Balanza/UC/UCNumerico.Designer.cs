namespace Balanza.UC
{
    partial class UCNumerico
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
            this.tbValor = new System.Windows.Forms.TextBox();
            this.lbEtiqueta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbValor
            // 
            this.tbValor.Location = new System.Drawing.Point(71, 0);
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(160, 20);
            this.tbValor.TabIndex = 3;
            this.tbValor.TextChanged += new System.EventHandler(this.tbValor_TextChanged);
            this.tbValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValor_KeyPress);
            // 
            // lbEtiqueta
            // 
            this.lbEtiqueta.AutoSize = true;
            this.lbEtiqueta.Location = new System.Drawing.Point(3, 3);
            this.lbEtiqueta.Name = "lbEtiqueta";
            this.lbEtiqueta.Size = new System.Drawing.Size(35, 13);
            this.lbEtiqueta.TabIndex = 2;
            this.lbEtiqueta.Text = "label1";
            // 
            // UCNumerico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbValor);
            this.Controls.Add(this.lbEtiqueta);
            this.Name = "UCNumerico";
            this.Size = new System.Drawing.Size(243, 21);
            this.Load += new System.EventHandler(this.UCNumerico_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbValor;
        private System.Windows.Forms.Label lbEtiqueta;
    }
}
