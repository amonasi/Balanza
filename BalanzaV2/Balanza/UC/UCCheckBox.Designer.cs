namespace Balanza.UC
{
    partial class UCCheckBox
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
            this.cbValor = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbValor
            // 
            this.cbValor.AutoSize = true;
            this.cbValor.Location = new System.Drawing.Point(12, 3);
            this.cbValor.Name = "cbValor";
            this.cbValor.Size = new System.Drawing.Size(80, 17);
            this.cbValor.TabIndex = 2;
            this.cbValor.Text = "checkBox1";
            this.cbValor.UseVisualStyleBackColor = true;
            // 
            // UCCheckBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbValor);
            this.Name = "UCCheckBox";
            this.Size = new System.Drawing.Size(170, 22);
            this.Load += new System.EventHandler(this.UCCheckBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbValor;
    }
}
