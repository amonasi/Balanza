namespace Balanza.UC
{
    partial class UCTickerHour
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
            this.tbTicker = new System.Windows.Forms.TextBox();
            this.lbEtiqueta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbTicker
            // 
            this.tbTicker.Location = new System.Drawing.Point(74, 0);
            this.tbTicker.Name = "tbTicker";
            this.tbTicker.ReadOnly = true;
            this.tbTicker.Size = new System.Drawing.Size(136, 20);
            this.tbTicker.TabIndex = 3;
            // 
            // lbEtiqueta
            // 
            this.lbEtiqueta.AutoSize = true;
            this.lbEtiqueta.Location = new System.Drawing.Point(2, 3);
            this.lbEtiqueta.Name = "lbEtiqueta";
            this.lbEtiqueta.Size = new System.Drawing.Size(35, 13);
            this.lbEtiqueta.TabIndex = 2;
            this.lbEtiqueta.Text = "label1";
            // 
            // UCTickerHour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbTicker);
            this.Controls.Add(this.lbEtiqueta);
            this.Name = "UCTickerHour";
            this.Size = new System.Drawing.Size(213, 22);
            this.Load += new System.EventHandler(this.UCTickerHour_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTicker;
        private System.Windows.Forms.Label lbEtiqueta;
    }
}
