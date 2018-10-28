namespace Balanza.UC
{
    partial class UCRadioButton
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
            this.rbValor = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rbValor
            // 
            this.rbValor.AutoSize = true;
            this.rbValor.Location = new System.Drawing.Point(12, 1);
            this.rbValor.Name = "rbValor";
            this.rbValor.Size = new System.Drawing.Size(85, 17);
            this.rbValor.TabIndex = 0;
            this.rbValor.TabStop = true;
            this.rbValor.Text = "radioButton1";
            this.rbValor.UseVisualStyleBackColor = true;
            // 
            // UCRadioButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbValor);
            this.Name = "UCRadioButton";
            this.Size = new System.Drawing.Size(198, 21);
            this.Load += new System.EventHandler(this.UCRadioButton_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbValor;
    }
}
