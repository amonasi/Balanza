using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Balanza.Configs;

namespace Balanza
{
    public partial class frmSecurity : Form
    {
        Logger log = new Logger();
        Security sec = new Security();

        public frmSecurity()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTipoPro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbAlgoritmo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAlgoritmo.Text.Equals("SHA1") || cmbAlgoritmo.Text.Equals("SHA2"))
            {
                cmbTipoPro.SelectedIndex = 0;
                cmbTipoPro.Enabled = false;
            }
            else
            {
                cmbTipoPro.Enabled = true;
            }
        }

        private void frmSecurity_Load(object sender, EventArgs e)
        {
            cmbTipoPro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAlgoritmo.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbTipoPro.Items.Add("Encriptar");
            cmbTipoPro.Items.Add("Desencriptar");

            cmbAlgoritmo.Items.Add("SHA1");
            cmbAlgoritmo.Items.Add("SHA2");
            cmbAlgoritmo.Items.Add("Rijndael");
            cmbAlgoritmo.Items.Add("TripleDES");

            tbKey.Text = Security.passPhrase;

            cmbAlgoritmo.Focus();

        }

        private void btnDo_Click(object sender, EventArgs e)
        {
            if (cmbAlgoritmo.Text == String.Empty)
            {
                MessageBox.Show("Elija un tipo de algoritmo", "Alerta");
                return;
            }

            if (cmbTipoPro.Text == String.Empty)
            {
                MessageBox.Show("Elija un tipo de Proceso", "Alerta");
                return;
            }

            tbResultado.Text = String.Empty;
            string resultado = string.Empty;
            try
            {
                if (cmbAlgoritmo.Text.Equals("SHA1"))
                {
                    sec.sha1Encrypt(tbValor.Text, ref resultado);
                    tbResultado.Text = resultado;
                }

                if (cmbAlgoritmo.Text.Equals("SHA2"))
                {
                    sec.sha2Encrypt(tbValor.Text, ref resultado);
                    tbResultado.Text = resultado;
                }

                if (cmbAlgoritmo.Text.Equals("Rijndael"))
                {

                    if (cmbTipoPro.Text.Equals("Encriptar"))
                    {
                        sec.SimpleEncrypt(tbValor.Text, ref resultado);
                        tbResultado.Text = resultado;
                    }

                    if (cmbTipoPro.Text.Equals("Desencriptar"))
                    {
                        sec.SimpleDecrypt(tbValor.Text, ref resultado);
                        tbResultado.Text = resultado;
                    }
                }

                if (cmbAlgoritmo.Text.Equals("TripleDES"))
                {

                    if (cmbTipoPro.Text.Equals("Encriptar"))
                    {
                        sec.ComplexEncrypt(tbValor.Text, tbKey.Text, true, ref resultado);
                        tbResultado.Text = resultado;
                    }

                    if (cmbTipoPro.Text.Equals("Desencriptar"))
                    {
                        sec.ComplexDecrypt(tbValor.Text, tbKey.Text, true, ref resultado);
                        tbResultado.Text = resultado;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + cmbTipoPro.Text + " Algoritmo: " + cmbAlgoritmo.Text + " Valor: " + tbValor + " mensaje: " + ex.Message);
                log.LogMessage("Error " + cmbTipoPro.Text + " Algoritmo: " + cmbAlgoritmo.Text + " Valor: " + tbValor + " mensaje: " + ex.Message);
            }
        }

    }
}
