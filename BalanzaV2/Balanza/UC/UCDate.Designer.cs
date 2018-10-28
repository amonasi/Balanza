namespace Balanza.UC
{
    partial class UCDate
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
            this.dtValor = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lbEtiqueta
            // 
            this.lbEtiqueta.AutoSize = true;
            this.lbEtiqueta.Location = new System.Drawing.Point(3, 3);
            this.lbEtiqueta.Name = "lbEtiqueta";
            this.lbEtiqueta.Size = new System.Drawing.Size(35, 13);
            this.lbEtiqueta.TabIndex = 1;
            this.lbEtiqueta.Text = "label1";
            // 
            // dtValor
            // 
            this.dtValor.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtValor.Location = new System.Drawing.Point(74, 0);
            this.dtValor.Name = "dtValor";
            this.dtValor.Size = new System.Drawing.Size(146, 20);
            this.dtValor.TabIndex = 2;
            // 
            // UCDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtValor);
            this.Controls.Add(this.lbEtiqueta);
            this.Name = "UCDate";
            this.Size = new System.Drawing.Size(223, 21);
            this.Load += new System.EventHandler(this.UCDate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbEtiqueta;
        private System.Windows.Forms.DateTimePicker dtValor;
    }
}
